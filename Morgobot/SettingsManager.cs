using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace Morgobot
{
    public class SettingsManager
    {
        private readonly JsonConfigurationProvider _configurationProvider;

        public SettingsManager()
        {
            _configurationProvider = new JsonConfigurationProvider(new JsonConfigurationSource());
            _configurationProvider.Load(new FileStream("appSettings.json", FileMode.Open));
        }

        public string GetSetting(string name)
        {
            string value;
            if(_configurationProvider.TryGet("botToken", out value))
            {
                return value;
            }
            else
            {
                throw new Exception($"Can't get setting '{name}'");
            }
        }
    }
}
