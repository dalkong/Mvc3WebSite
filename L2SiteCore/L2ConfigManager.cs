using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
namespace L2SiteCore
{
    public class L2ConfigManager : ConfigurationSection
    {
        [ConfigurationProperty("host")]
        public HostElement Host
        {
            get { return (HostElement)base["host"]; }
        }

        public class HostElement : ConfigurationElement
        {
            [ConfigurationProperty("name")]
            public string name
            {
                get { return (string)base["name"]; }
                set { base["name"] = value; }
            }

            [ConfigurationProperty("port")]
            public string port
            {
                get { return (string)base["port"]; }
                set { base["port"] = value; }
            }

            [ConfigurationProperty("domain")]
            public string domain
            {
                get { return (string)base["domain"]; }
                set { base["domain"] = value; }
            }

            [ConfigurationProperty("ip")]
            public string ip
            {
                get { return (string)base["ip"]; }
                set { base["ip"] = value; }
            }
        }
    }

    public static class SiteManager
    {
        public readonly static L2ConfigManager Config = (L2ConfigManager)WebConfigurationManager.GetSection("SiteConfig");
    }
}
