using System;
using System.Linq.Expressions;
using System.Reflection;

namespace UILHost.Common
{
    public static class ReflectionUtil
    {
        public static MemberInfo GetMember<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> memberExpression)
        {
            return ((MemberExpression)memberExpression.Body).Member;
        }
    }
}
