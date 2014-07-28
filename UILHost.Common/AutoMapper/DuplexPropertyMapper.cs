using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace UILHost.Common.AutoMapper
{
    public class DuplexPropertyMapper<TSource, TDestination>
    {
        private readonly IMappingExpression<TSource, TDestination> _sourceExpression;
        private readonly IMappingExpression<TDestination, TSource> _destinationExpression;

        public DuplexPropertyMapper(
            IMappingExpression<TSource, TDestination> sourceExpression = null,
            IMappingExpression<TDestination, TSource> destinationExpression = null)
        {
            _sourceExpression = sourceExpression ?? Mapper.CreateMap<TSource, TDestination>();
            _destinationExpression = destinationExpression ?? Mapper.CreateMap<TDestination, TSource>();
        }

        public DuplexPropertyMapper<TSource, TDestination> Map<TSourceProperty, TDestinationProperty>(
            Expression<Func<TSource, TSourceProperty>> sourceProperty,
            Expression<Func<TDestination, TDestinationProperty>> destinationProperty)
        {

            var sourceName = ((MemberExpression)sourceProperty.Body).Member.Name;
            var destinationName = ((MemberExpression)destinationProperty.Body).Member.Name;

            //var sourceName = GetCorrectPropertyName<TSource>(_sourceExpression);

            _sourceExpression.ForMember(destinationName, opt => opt.MapFrom(sourceProperty));
            _destinationExpression.ForMember(sourceName, opt => opt.MapFrom(destinationProperty));

            return this;
        }

        //public string GetCorrectPropertyName<T>(Expression<Func<T, Object>> expression)
        //{
        //    if (expression.Body is MemberExpression)
        //    {
        //        return ((MemberExpression)expression.Body).Member.Name;
        //    }
        //    else
        //    {
        //        var op = ((UnaryExpression)expression.Body).Operand;
        //        return ((MemberExpression)op).Member.Name;
        //    }
        //}

    }
}
