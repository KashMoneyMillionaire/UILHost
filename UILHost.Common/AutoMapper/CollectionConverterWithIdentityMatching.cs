using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

//EX ----

//Mapper.CreateMap<UserModel, User>();
//var converter = CollectionConverterWithIdentityMatching<UserModel, User>.Instance(model => model.Id, user => user.Id, List<dest> => { <DELETE> });
//Mapper.CreateMap<List<UserModel>, List<User>>().ConvertUsing(converter);

public class CollectionConverterWithIdentityMatching<TSource, TDestination> : 
    ITypeConverter<List<TSource>, List<TDestination>> where TDestination : class
{
    private readonly Action<List<TDestination>> _destinationDeleteAction;
    private readonly Func<TSource, object> _sourcePrimaryKeyExpression;
    private readonly Func<TDestination, object> _destinationPrimaryKeyExpression;

    /// <summary>
    /// Instantiates a collection converter with identity matching
    /// The identity of the source element and the destination element can be defined in the constructor
    /// </summary>
    /// <param name="sourcePrimaryKey">The source primary key expression</param>
    /// <param name="destinationPrimaryKey">The destination primary key expression</param>
    /// <param name="destinationDeleteAction">The destination delete action - for items that do not exist in the source list, but do in the destination list. This parameter is optional</param>
    private CollectionConverterWithIdentityMatching(
        Expression<Func<TSource, object>> sourcePrimaryKey, 
        Expression<Func<TDestination, object>> destinationPrimaryKey,
        Action<List<TDestination>> destinationDeleteAction = null)
    {
        _destinationDeleteAction = destinationDeleteAction;
        this._sourcePrimaryKeyExpression = sourcePrimaryKey.Compile();
        this._destinationPrimaryKeyExpression = destinationPrimaryKey.Compile();
    }

    public static CollectionConverterWithIdentityMatching<TSource, TDestination> 
        Instance(Expression<Func<TSource, object>> sourcePrimaryKey, Expression<Func<TDestination, object>> destinationPrimaryKey)
   {
        return new CollectionConverterWithIdentityMatching<TSource, TDestination>(
            sourcePrimaryKey, destinationPrimaryKey);
    }

    public List<TDestination> Convert(ResolutionContext context)
    {
        var destinationCollection = (List<TDestination>)context.DestinationValue ?? new List<TDestination>();
        var sourceCollection = (List<TSource>)context.SourceValue;

        // from source to destination mapping

        foreach (var source in sourceCollection)
        {
            // find the matching destination object

            var transientDest =
                destinationCollection.FirstOrDefault(
                    d =>
                        GetPrimaryKey(d, _destinationPrimaryKeyExpression) ==
                        GetPrimaryKey(source, _sourcePrimaryKeyExpression));

            // if matched destination is still null at the end of the search, create a new object for the destination

            if (transientDest != null)
                Mapper.Map(source, transientDest);
            else
                destinationCollection.Add(Mapper.Map<TDestination>(source));
        }

        // find deletions from the destination list

        var toRemove = destinationCollection
            .Where(d => sourceCollection.All(
                s => GetPrimaryKey(s, _sourcePrimaryKeyExpression) != GetPrimaryKey(d, _destinationPrimaryKeyExpression) ))
                .ToList();

        foreach (var destItem in toRemove)
            destinationCollection.Remove(destItem);

        // send the removed items to the delete action

        if (_destinationDeleteAction != null)
            _destinationDeleteAction(toRemove);

        // return the final destination collection

        return destinationCollection;
    }

    private string GetPrimaryKey<TObject>(object entity, Func<TObject, object> expression)
    {
        var tempId = expression.Invoke((TObject)entity);
        var id = System.Convert.ToString(tempId);
        return id;
    }
}