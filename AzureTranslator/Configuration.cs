using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public class Configuration
    {
        public const string DEFAULT_FILE = "Config.xml";

        public List<string> DisabledLanguages { get; set; }
        public string AzureCognitiveServicesTextTranslationApiKey { get; set; }

        public static bool Exists(string file) => File.Exists(file);

        public static Configuration Load(string file)
        {
            var serializer = new DataContractSerializer(typeof(Configuration));
            var data = Encoding.UTF8.GetBytes(File.ReadAllText(file));
            using (var ms = new MemoryStream(data))
            {
                ms.Position = 0;
                return (Configuration)serializer.ReadObject(ms);
            }
        }

        public static void Save(string file, Configuration value)
        {
            var serializer = new DataContractSerializer(typeof(Configuration));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, value);
                File.WriteAllText(file, Encoding.UTF8.GetString(ms.GetBuffer().TakeWhile(x => x != (byte)0).ToArray()));
            }
        }
    }
}
