using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Infrastructure.ChangeDataCapture
{
    /// <summary>
    /// When added to an entity, any changes to the entities properties 
    /// will be logged.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class HideFromChangeDataCaptureAttribute : Attribute { }
}
