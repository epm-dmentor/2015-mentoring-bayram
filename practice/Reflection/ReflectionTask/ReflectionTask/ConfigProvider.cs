using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetMentoring.Epam.ReflectionTask
{
    public class ConfigProvider:IConfigProvider
    {
        private string _location;

        public string ConfigFile
        {
            get { return _location; }
            set { _location = value; }
        }


        public ConfigProvider()
        {
            _location=ConfigurationSettings.AppSettings["ConfigLocationDev"];
        }
        
        public T GetSettings<T>() where T : new()
        {
            var instanceType = typeof(T);
            var name = instanceType.Name;
            var parsedList = GetParsedList(GetConfigList(_location));

            var currentPropertyValues = parsedList.
                Where(x => x.Name.Equals(name)).
                Select(x => x.Properties).FirstOrDefault();
            
            var currentTypeProperties = instanceType.GetProperties();
          
            if (currentPropertyValues.Count!=currentTypeProperties.Count()) 
                throw new Exception("Property Count does not match Property values parsed from file.");

            var instance = (T)Activator.CreateInstance(instanceType);
 
            foreach (var property in currentTypeProperties)
            {
               property.SetValue(instance,currentPropertyValues[property.Name]);
            }
            return (T)instance;
        }

        IEnumerable<string> GetConfigList(string location)
        {
            List<string> list;
            try
            {
                list = File.ReadAllLines(location).ToList();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Cannot find file provided. Exception - {0}", ex.Message);
                throw;
            }
            return list;
        }

        IEnumerable<ConfigEntity> GetParsedList(IEnumerable<string> list)
        {
            const string pattern = @"'(.*?)'";
            var parsedList = new List<ConfigEntity>();
            foreach (var s in list.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct())
            {
                var splitted = s.Split(new char[] { '{', '}' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                var parsed = new ConfigEntity();
                var matchFullName = Regex.Match(splitted[0], pattern);
                var matchName = Regex.Match(splitted[1], pattern);

                parsed.NameSpace = matchFullName.Groups[1].Value;
                parsed.Name = matchName.Groups[1].Value;
                var pair = new Dictionary<string, string>();
                for (var i = 2; i < splitted.Length; i++)
                {
                    var propertyKey = SubString(splitted[i]);
                    var matchProperty = Regex.Match(splitted[i], pattern);
                    pair.Add(propertyKey, matchProperty.Groups[1].Value);
                  
                }
                parsed.Properties = pair;
                parsedList.Add(parsed);
            }
            return parsedList;
        }

        string SubString(string value)
        {
            var length = value.IndexOf("=", StringComparison.Ordinal);
            return length > 0 ? value.Substring(0, length) : "";
        }

    }
}
