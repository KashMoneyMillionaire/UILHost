using AutoMapper;

namespace UILHost.Common.AutoMapper
{
    public static class Extensions
    {
        public static DuplexPropertyMapper<TSource, TDestination> DuplexPropertyMapper<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> sourceExpression,
            IMappingExpression<TDestination, TSource> destExpression = null)
        {
            return new DuplexPropertyMapper<TSource, TDestination>(sourceExpression, destExpression);
        }

        public static DuplexPropertyMapper<TSource, TDestination> DuplexPropertyMapper<TSource, TDestination>(
            this IConfiguration configuration)
        {
            return new DuplexPropertyMapper<TSource, TDestination>();
        }
    }
}
