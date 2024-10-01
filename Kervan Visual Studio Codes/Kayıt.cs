using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kervan
{
    internal class Kayıt
    {
        // KayıtDosyası() -> dosyaYolu'nu belirler
        public void KayıtDosyası(string işlem)
        {
            string klasorYolu = Path.Combine(Environment.CurrentDirectory,  "SaveData");

            // Eğer SaveData klasörü yoksa oluştur
            if (!Directory.Exists(klasorYolu))
            {
                Directory.CreateDirectory(klasorYolu);
            }

            // Ardından dosya yolunu belirler
            string dosyaYolu = Path.Combine(klasorYolu, "oyun_durumu.txt");

            if (işlem == "kaydet")
            {
                KaydetTxt(dosyaYolu);
            }else if (işlem == "yükle")
            {
                YükleTxt(dosyaYolu);
            }
        }

        public void KaydetTxt(string dosyaYolu)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            using (StreamWriter writer = new StreamWriter(dosyaYolu))
            {
                Console.WriteLine(Language.GetText("Kayıt.Kaydet.1"));
                foreach (string item in ortakErişim.OrtakListe.Olay)
                {
                    writer.WriteLine("Olay:" + item);
                }
                Thread.Sleep(44);

                Console.WriteLine(Language.GetText("Kayıt.Kaydet.2"));
                foreach (string item in ortakErişim.OrtakListe.Grup)
                {
                    writer.WriteLine("Grup:" + item);
                }
                Thread.Sleep(44);

                Console.WriteLine(Language.GetText("Kayıt.Kaydet.3"));
                foreach (string item in ortakErişim.OrtakListe.Envanter)
                {
                    writer.WriteLine("Envanter:" + item);
                }
                Thread.Sleep(44);
                Harita haritaCs = new Harita();
                writer.WriteLine("Para:" + ortakErişim.OrtakListe.Para);
                writer.WriteLine("Erzak:" + ortakErişim.OrtakListe.Erzak);
                writer.WriteLine("OyuncuKonumX:" + haritaCs.KonumGöster("x"));
                Console.WriteLine(haritaCs.KonumGöster("x") + " X konumu");
                writer.WriteLine("OyuncuKonumY:" + haritaCs.KonumGöster("y"));
                Console.WriteLine(haritaCs.KonumGöster("y") + " Y konumu");
                Thread.Sleep(44);
            }
            Console.WriteLine(Language.GetText("Kayıt.Kaydet.Son"));
            Environment.Exit(0);
        }

        public void YükleTxt(string dosyaYolu)
        {
            Console.WriteLine("Kayıt Dosyası yükleniyor ama hiçbir oyuncu dönüp bunu okumayacak çünkü ->\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            if (File.Exists(dosyaYolu))
            {
                OL_Singleton ortakErişim = OL_Singleton.Instance;
                Harita haritaCs = new Harita();
                ortakErişim.OrtakListe.Olay.Clear();
                ortakErişim.OrtakListe.Grup.Clear();
                ortakErişim.OrtakListe.Envanter.Clear();
                ortakErişim.OrtakListe.Para = 0;
                ortakErişim.OrtakListe.Erzak = 0;
                int sayı;

                using (StreamReader reader = new StreamReader(dosyaYolu))
                {
                    string satır;
                    while ((satır = reader.ReadLine()) != null)
                    {
                        string[] parçalar = satır.Split(':');
                        string anahtar = parçalar[0];
                        string değer = parçalar[1];

                        switch (anahtar)
                        {
                            case "Olay":
                                ortakErişim.OrtakListe.Olay.Add(değer);
                                break;
                            case "Grup":
                                ortakErişim.OrtakListe.Grup.Add(değer);
                                break;
                            case "Envanter":
                                ortakErişim.OrtakListe.Envanter.Add(değer);
                                break;
                            case "Para":
                                ortakErişim.OrtakListe.Para = int.Parse(değer);
                                break;
                            case "Erzak":
                                ortakErişim.OrtakListe.Erzak = int.Parse(değer);
                                break;
                            case "OyuncuKonumX":
                                sayı = int.Parse(değer);
                                haritaCs.KonumIşınlan("x", sayı);
                                break;
                            case "OyuncuKonumY":
                                sayı = int.Parse(değer);
                                haritaCs.KonumIşınlan("y", sayı);
                                break;
                            default:
                                Console.WriteLine("Bilinmeyen anahtar: " + anahtar);
                                break;
                        }
                    }
                }
                Console.WriteLine(Language.GetText("Kayıt.Yükle.1"));
                Thread.Sleep(2000);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                haritaCs.haritaHazırla();
                haritaCs.haritaYazdır();
            }
            else
            {
                // Dosya mevcut değil
                Console.WriteLine(Language.GetText("Kayıt.Yükle.Hata.1"));
                Thread.Sleep(1000);
                Console.WriteLine(Language.GetText("Kayıt.Yükle.Hata.2"));
                Thread.Sleep(2000);
                for (int i = 0; i < 180; i += 0)
                {
                    Console.Write(".");
                    Thread.Sleep(200 - i);
                    i += (int)((200 - i) * 0.1);
                }
            }
        }
    }
}

