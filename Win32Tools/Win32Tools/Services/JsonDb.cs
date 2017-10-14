﻿using System;
using System.IO;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Win32Tools
{
    public class JsonDb : IDisposable
    {
        public JsonDb(string fileName)
        {
            FileName = fileName;
            Initialize();
            Deserialize();
        }

        [JsonIgnore]
        public string FileName { get; }
        [JsonIgnore]

        public Formatting Formatting { get; set; } = Formatting.Indented;

        private void Initialize()
        {
            var properties = this.GetType().GetTypeInfo().DeclaredProperties;
            foreach (var property in properties)
            {
                if (property.PropertyType.GetConstructor(Type.EmptyTypes) != null)
                {
                    property.SetValue(this, Activator.CreateInstance(property.PropertyType));
                }
            }
        }

        public void SaveChanges()
        {
            Serialize();
        }

        private void Serialize()
        {
            string json = JsonConvert.SerializeObject(this, Formatting);
            File.WriteAllText(FileName, json);
        }

        private void Deserialize()
        {
            if (File.Exists(FileName))
            {
                string json = File.ReadAllText(FileName);
                var jObject = JObject.Parse(json);

                var properties = this.GetType().GetTypeInfo().DeclaredProperties;
                foreach (var property in properties)
                {
                    if (jObject.TryGetValue(property.Name, out JToken token))
                    {
                        var value = token.ToObject(property.PropertyType);
                        property.SetValue(this, value);
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
