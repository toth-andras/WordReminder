using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

namespace WRApp_PC.UserSettings
{
    class SettingsIOManager
    {
        // Файл для сохранения.
        private readonly string path;

        public SettingsIOManager(string path)
        {
            this.path = path;
        }

        public SettingsIOModel Read()
        {
            try
            {
                using (var reader = File.OpenText(path))
                {
                    var fileText = reader.ReadToEnd();
                    SettingsIOModel model = JsonConvert.DeserializeObject<SettingsIOModel>(fileText);

                    return model;
                }
            }
            catch (Exception e)
            {
                throw new SettingsIOException(e);
            }
        }

        public void Write(SettingsIOModel model)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    string output = JsonConvert.SerializeObject(model);
                    writer.Write(output);
                }
            }
            catch (Exception e)
            {
                throw new SettingsIOException(e);
            }
        }
    }
}
