using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetMentoring.Epam.ReflectionTask
{
    public class ConfigProviderProd : IConfigProvider
    {
        public string ConfigFile { get; set; }

        public ConfigProviderProd()
        {
            ConfigFile = ConfigurationSettings.AppSettings["ConfigLocationProd"];
        }

        public T GetSettings<T>() where T : new()
        {
            var instanceType = typeof(T);
            var name = instanceType.Name;
            var fullName = instanceType.FullName;
            IEnumerable<ConfigEntity> parsedList;
            try
            {
              parsedList = GetParsedList(GetConfigList(ConfigFile));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during parsing. {0}",ex.Message);
                throw;
            }
            
            var currentPropertyValues = parsedList.
                Where(x => x.FullName.Equals(fullName) || x.Name.Equals(name)).
                Select(x => x.Properties).FirstOrDefault();

            var currentTypeProperties = instanceType.GetProperties();

            if (currentPropertyValues.Count != currentTypeProperties.Count())
                throw new Exception("Property Count does not match Property values parsed from file.");

            var instance = (T)Activator.CreateInstance(instanceType);

            foreach (var property in currentTypeProperties)
            {
                property.SetValue(instance, currentPropertyValues[property.Name]);
            }
            return (T)instance;
        }

        public IEnumerable<string> GetConfigList(string location)
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

        public IEnumerable<ConfigEntity> GetParsedList(IEnumerable<string> list)
        {
            var parsedList = new List<ConfigEntity>();
            const string pattern = @"'(.*?)'";
            foreach (var s in list.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct())
            {
                var splitted = s.Split(new char[] { '.', '=' },
                StringSplitOptions.RemoveEmptyEntries);

                var value = Regex.Match(splitted[splitted.Length - 1], pattern).Groups[1].Value;
                var property = splitted[splitted.Length - 2];
                var name = splitted[splitted.Length - 3];
                var fullname = string.Join(".", splitted, 0, splitted.Length - 2);
                var cached = parsedList.Where(x => x.Name.Equals(name)).Select(x => x.Properties).FirstOrDefault();
                var configEntity = new ConfigEntity();

                if (cached != null)
                {
                    cached.Add(property, value);
                    configEntity.Name = name;
                    configEntity.FullName = fullname;
                    configEntity.Properties = cached;
                    parsedList.Add(configEntity);
                }
                else
                {
                    var pair = new Dictionary<string, string> { { property, value } };
                    configEntity.Name = name;
                    configEntity.FullName = fullname;
                    configEntity.Properties = pair;
                    parsedList.Add(configEntity);

                }

            }
            return parsedList;
        }

    }
}
