using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Common.AutoMapper
{
    /// <summary>
    /// Marker interface for helping with AutoMapper mapping in view models
    /// </summary>
    /// <typeparam name="T">The source type for mapping with AutoMapper</typeparam>
    public interface IMapFrom<T>
    {
    }
}
