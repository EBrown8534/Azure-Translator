using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AzureTranslator
{
    class AzureTranslateApi
    {
        public static async Task<string> TranslateText(string key, string text, string toLanguage, string fromLanguage = null)
        {
            fromLanguage = fromLanguage != null ? $"&from={fromLanguage}" : "";

            using (var wc = new WebClient())
            {
                wc.Headers.Add("Ocp-Apim-Subscription-Key", key);
                var response =  await wc.DownloadDataTaskAsync($"https://api.microsofttranslator.com/V2/Http.svc/Translate?text={Uri.EscapeDataString(text)}&to={toLanguage}{fromLanguage}");
                var dc = new DataContractSerializer(typeof(string));
                return (string)dc.ReadObject(new MemoryStream(response));
            }
        }
    }
}
