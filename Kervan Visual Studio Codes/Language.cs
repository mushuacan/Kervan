using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kervan
{
    public static class Language
    {
        private static Dictionary<string, string> languageDictionary;

        static Language()
        {
            // Varsayılan olarak Türkçe dil dosyasını yükle
            LoadLanguage("Türkçe.txt");
        }

        public static void SetLanguage(string languageFile)
        {
            // Belirtilen dil dosyasını yükle
            LoadLanguage(languageFile);
        }

        public static string GetText(string key)
        {
            // Anahtar kelimeye karşılık gelen metni döndür
            if (languageDictionary.ContainsKey(key))
                return languageDictionary[key];
            else if (GetText("Dil") == null)
                return "\nHata kodu:" + key; //Kelime gibi dil de mevcut değil (?)
            else
                return "\nHata kodu:" + key + "\nDil: " + GetText("Dil") + "\n"; //Kelime mevcut değil
        }

        private static void LoadLanguage(string languageFile)
        {
            languageDictionary = new Dictionary<string, string>();

            string workingDirectory = Environment.CurrentDirectory;
            //string projectDirectory = Directory.GetParent(workingDirectory).FullName;
            string filePath = Path.Combine(workingDirectory, "Diller", languageFile);

            if (File.Exists(filePath))
            {
                // Dil dosyasını oku ve içeriğini dictionary'e yükle
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            languageDictionary[key] = value;
                        }
                    }
                }
            }
            else
            {
                // Dosya bulunamazsa uyarı ver
                Console.WriteLine($"'{languageFile}' dosyası bulunamadı.");
                Thread.Sleep( 100000 );
            }
        }
    }
}
