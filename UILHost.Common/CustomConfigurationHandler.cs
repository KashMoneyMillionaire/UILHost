using System;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace UILHost.Common
{
    public class CustomConfigurationHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var xNav = section.CreateNavigator();

            var configurationObjectTypeName = (string)xNav.Evaluate("string(@type)");
            var configurationType = Type.GetType(configurationObjectTypeName);
            
            var xRoot = new XmlRootAttribute { ElementName = xNav.Name, IsNullable = true };

            var ser = new XmlSerializer(configurationType, xRoot);
            var xNodeReader = new XmlNodeReader(section);

            return ser.Deserialize(xNodeReader);
        }
    }
}
