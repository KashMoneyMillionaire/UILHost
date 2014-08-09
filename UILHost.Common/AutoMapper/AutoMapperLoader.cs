using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UILHost.Common.AutoMapper
{
    public static class AutoMapperLoader
    {
        public static void Execute(params string[] assemblyNames)
        {
            var types = new List<Type>();
            foreach (var name in assemblyNames)
                types.AddRange(System.Reflection.Assembly.Load(name).GetExportedTypes());
            Execute(types.ToArray());        
        }

        public static void Execute(Type[] types)
        {
            LoadOneWayMappings(types);
            LoadTwoWayMappings(types);
            LoadCustomMappings(types);
            LoadGlobalMappings();
          
        }

        private static void LoadOneWayMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !t.IsAbstract &&
                        !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadTwoWayMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IMap<>) &&
                        !t.IsAbstract &&
                        !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
                Mapper.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                        !t.IsAbstract &&
                        !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)
                        ).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }

        private static void LoadGlobalMappings() {
            Mapper.CreateMap<string, DateTime?>().ConvertUsing(new StringToNullableDateTimeTypeConverter());
            Mapper.CreateMap<string, DateTime>().ConvertUsing(new StringToDateTimeTypeConverter());
            Mapper.CreateMap<DateTime, string>().ConvertUsing(new DateTimeToStringTypeConverter());
            Mapper.CreateMap<string, Boolean>().ConvertUsing(new StringToBooleanTypeConverter());
            Mapper.CreateMap<Boolean, string>().ConvertUsing(new BooleanToStringTypeConverter());
            Mapper.CreateMap<string[], decimal[]>().ConvertUsing(new StringArrayToDecimalArrayTypeConverter());
            Mapper.CreateMap<decimal[], string[]>().ConvertUsing(new DecimalArrayToStringArrayTypeConverter());
            Mapper.CreateMap<string, decimal>().ConvertUsing(new StringToDecimalTypeConverter());
            Mapper.CreateMap<decimal, string>().ConvertUsing(new DecimalToStringTypeConverter());
            Mapper.CreateMap<int, string>().ConvertUsing(new IntToStringTypeConverter());
            Mapper.CreateMap<string, int>().ConvertUsing(new StringToIntTypeConverter());

            Mapper.CreateMap<bool?, BooleanCode>().ConvertUsing(b =>
            {
                if (b.HasValue)
                    return b.Value
                        ? BooleanCode.Yes
                        : BooleanCode.No;
                
                return BooleanCode.Undefined;
            });

            Mapper.CreateMap<bool, BooleanCode>().ConvertUsing(b => b ? BooleanCode.Yes : BooleanCode.No);

            Mapper.CreateMap<BooleanCode, bool?>().ConvertUsing(bln =>
            {
                switch (bln)
                {
                    case BooleanCode.Undefined:
                        return null;
                    case BooleanCode.Yes:
                        return true;
                    case BooleanCode.No:
                        return false;
                    default:
                        throw new ArgumentOutOfRangeException("bln");
                }
            });

            Mapper.CreateMap<BooleanCode, bool>().ConvertUsing(code =>
            {
                switch (code)
                {
                    case BooleanCode.Undefined:
                        throw new ArgumentException(string.Format("{0}.{1} cannot be mapped to a primitive bool",
                            typeof (BooleanCode).Name, code));
                    case BooleanCode.Yes:
                        return true;
                    case BooleanCode.No:
                        return false;
                    default:
                        throw new ArgumentOutOfRangeException("code");
                }
            });



        }

    }
}