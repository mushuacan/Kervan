using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kervan
{

    #region SINGLETON INSCTANCE // GLOBAL BÜTÜN DEĞİŞKENLER
    public class OrtakListe
    {
        public List<string> Olay { get; set; } = new List<string>();
        public List<string> Grup { get; set; } = new List<string>();
        public List<string> Envanter { get; set; } = new List<string>();
        public int Para { get; set; }
        public int Erzak { get; set; }
        public int oyuncuGlobalKonumX { get; set; }
        public int oyuncuGlobalKonumY { get; set; }
    }

    //Buranın altındaki kodları zerre anlamadım, gpt yazdı ben de kullandım.
    public class OL_Singleton //OL -> Ortak Liste
    {
        private static OL_Singleton instance;
        public OrtakListe OrtakListe { get; private set; }

        private OL_Singleton()
        {
            OrtakListe = new OrtakListe();
        }

        public static OL_Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OL_Singleton();
                }
                return instance;
            }
        }
    }
    #endregion

    internal class Şehir
    {
        public void BaşlarkenHazırlık()
        {
            // OrtakListe'yi kullanmak için OrtakListeSingleton.Instance'dan bir örnek alın
            OL_Singleton ortakErişim = OL_Singleton.Instance;

            // Gruba eleman eklemek
            ortakErişim.OrtakListe.Grup.Add("Eleman");
            ortakErişim.OrtakListe.Grup.Add("Eleman");
            ortakErişim.OrtakListe.Para = 100;
            ortakErişim.OrtakListe.Erzak = 44;
            ortakErişim.OrtakListe.oyuncuGlobalKonumX = 4;
            ortakErişim.OrtakListe.oyuncuGlobalKonumY = 10;
            ortakErişim.OrtakListe.Envanter.Add("Aile Yâdigârı Gümüş Kolye");
        }

        public void GrupYazdır()
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            // Grubun içeriğini yazdırmak
            Console.WriteLine("\nGrup Elemanların:");
            foreach (var eleman in ortakErişim.OrtakListe.Grup)
            {
                Console.WriteLine(eleman);
            }
            Thread.Sleep(500);
        }

        public void EnvanterYazdır()
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            // Grubun içeriğini yazdırmak
            Console.WriteLine("\nEnvanterindekiler:");
            foreach (var item in ortakErişim.OrtakListe.Envanter)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
            Thread.Sleep(500);
        }


        public void Şehrinİçinde(int bölgeKodu)
        {
            {
                //Niye iki tane {{ var hiç bir fikrim yok silemeycem şimdi

                #region Gerekli Referanslar
                OL_Singleton ortakErişim = OL_Singleton.Instance;
                Eşyalar EşyalarCs = new Eşyalar();
                string bölge = "Şehir";
                #endregion

                #region Yerleşkenin İsmini Yazdır
                Console.WriteLine($"\n\n{EşyalarCs.ŞehirlerListesi[bölgeKodu].Name}");
                Thread.Sleep(200);
                #endregion

                while (true)
                {
                    #region Menü
                    Console.WriteLine("1-Ticaret yap");
                    Console.WriteLine("2-Eleman alma");
                    Console.WriteLine("3-Kumar oynama");
                    Console.WriteLine("4-Gecele");
                    Console.WriteLine("5-Erzak alma");
                    Console.WriteLine("6-Şehirden ayrılma");
                    // ... istediğiniz kadar seçenek ekleyebilirsiniz
                    Thread.Sleep(100);
                    if (ortakErişim.OrtakListe.Olay.Contains("Doktor"))
                    {
                        Console.WriteLine("\nDoktor görmek için dc yaz.");
                        Console.Write("\nLütfen bir seçenek girin (1-6 veya dc): ");
                    }
                    else
                    {
                        Console.Write("\nLütfen bir seçenek girin (1-6): ");
                    }
                    #endregion

                    #region Girdi Değerlendirmesi
                    // Kullanıcının seçimini al
                    string userInput = Console.ReadLine();

                    // Kullanıcının girdisini değerlendir
                    switch (userInput)
                    {
                        //Ticaret
                        case "1":
                            Console.WriteLine("\nTicaret yapılıyor...\n");
                            Thread.Sleep(600);
                            İşlem(bölge, "Ticaret", bölgeKodu);
                            Thread.Sleep(1000);
                            break;

                        //Eleman
                        case "2":
                            Console.WriteLine("\nEleman alınıyor...\n");
                            Thread.Sleep(600);
                            İşlem(bölge, "Eleman");
                            Thread.Sleep(1000);
                            break;

                        //Kumar
                        case "3":
                            Console.WriteLine("\nKumar oynanıyor...\n");
                            Thread.Sleep(600);
                            Kumar KumarCs = new Kumar();
                            int kumarParası = KumarCs.coinEnter();
                            if (kumarParası == 0)
                            { Console.WriteLine($"Helal olsun dostum! Doğru olanı yaptın ve bu illete bulaşmadın."); }
                            else if (kumarParası <= 4)
                            {Console.WriteLine($"Bu kadar az para yatıracaksan kumar oynamanın ne manası var?");}
                            else{KumarCs.Gamble(kumarParası, kumarParası); }
                            Thread.Sleep(1000);
                            break;

                        //Geceleme (Ne işe yarıyorsa artık)
                        case "4":
                            Console.WriteLine("\nGeceleniyor...");
                            Thread.Sleep(600);
                            Console.WriteLine("(Gecelemek ne işe yarıyorsa artık...)\n");
                            İşlem(bölge, "Gecele");
                            Thread.Sleep(1000);
                            break;

                        //Erzak
                        case "5":
                            Console.WriteLine("\nErzak alınıyor...\n");
                            Thread.Sleep(600);
                            İşlem(bölge, "Erzak");
                            Thread.Sleep(1000);
                            break;

                        //Çıkış
                        case "6":
                            Console.WriteLine("\nŞehirden ayrılma...");
                            Thread.Sleep(600);
                            Console.WriteLine("Çıkış yapılıyor...\n");
                            Thread.Sleep(600);
                            return; // while döngüsünü kır
                                    // break; // return kullanıldığı için break kullanmaya gerek yok

                        //Doktor
                        case "dc":
                            Console.WriteLine("\nDoktor görmeye gittin.");
                            Console.WriteLine("Tedavi parası: 20");
                            Console.WriteLine("(Ödemek için -> 1, çıkmak için 0)");
                            // Kullanıcının seçimini al
                            userInput = Console.ReadLine();
                            if (userInput == "1")
                            {
                                if (ortakErişim.OrtakListe.Para >= 20)
                                {
                                    for (int i = ortakErişim.OrtakListe.Olay.Count - 1; i >= 0 ; i--)
                                    {
                                        if (ortakErişim.OrtakListe.Olay[i] == "Doktor")
                                        {
                                            ortakErişim.OrtakListe.Olay.RemoveAt(i);
                                        }
                                    }
                                    Console.WriteLine("Tedavi oldun.");
                                }else
                                {
                                    Console.WriteLine($"Yeterli para bulamadın. Cebinden sadece {ortakErişim.OrtakListe.Para} çıktı.");
                                }
                            }else
                            {
                                Console.WriteLine("Şifahaneyi terk ettin.");
                                Thread.Sleep(1000);
                            }
                            break;

                        default:
                            Console.WriteLine("Geçersiz seçenek!");
                            Thread.Sleep(600);
                            Console.WriteLine("Lütfen 1 ile 6 arasında bir sayı girin.");
                            break;
                    }
                    #endregion

                    Console.WriteLine(); // Bir boş satır ekleyerek okunabilirliği artır
                }
            }
        }

        //Şehirdekilerin aynısı ama Köyün içinde olan kısıtlamalarla birlikte
        public void Köyünİçinde(int bölgeKodu)
        {
            {
                Eşyalar EşyalarCs = new Eşyalar();
                Console.WriteLine($"\n\n{EşyalarCs.ŞehirlerListesi[bölgeKodu].Name}");
                Thread.Sleep(200);
                string bölge = "Köy";
                while (true)
                {
                    Console.WriteLine("1-Ticaret yap");
                    Console.WriteLine("2-Eleman alma");
                    Console.WriteLine("3-Erzak alma");
                    Console.WriteLine("4-Köyden ayrılma");
                    // ... istediğiniz kadar seçenek ekleyebilirsiniz
                    Thread.Sleep(100);

                    Console.Write("\nLütfen bir seçenek girin (1-4): ");

                    // Kullanıcının seçimini al
                    string userInput = Console.ReadLine();

                    // Kullanıcının girdisini değerlendir
                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("\nTicaret yapılıyor...\n");
                            Thread.Sleep(600);
                            İşlem(bölge, "Ticaret", bölgeKodu);
                            Thread.Sleep(1000);
                            break;

                        case "2":
                            Console.WriteLine("\nEleman alınıyor...\n");
                            Thread.Sleep(600);
                            İşlem(bölge, "Eleman");
                            Thread.Sleep(1000);
                            break;

                        case "3":
                            Console.WriteLine("\nErzak alınıyor...\n");
                            Thread.Sleep(600);
                            İşlem(bölge, "Erzak");
                            Thread.Sleep(1000);
                            break;

                        case "4":
                            Console.WriteLine("\nKöyden ayrılma...");
                            Thread.Sleep(600);
                            Console.WriteLine("Çıkış yapılıyor...\n");
                            Thread.Sleep(600);
                            return; // while döngüsünü kır
                                    // break; // return kullanıldığı için break kullanmaya gerek yok


                        default:
                            Console.WriteLine("Geçersiz seçenek!");
                            Thread.Sleep(600);
                            Console.WriteLine("Lütfen 1 ile 4 arasında bir sayı girin.");
                            break;
                    }

                    Console.WriteLine(); // Bir boş satır ekleyerek okunabilirliği artırın
                }
            }
        }

        //Erzakla ilgili işlemler
        public void Erzak(string işlem, int artış = 0)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;

            //Azaltmak için eksili değer girilip gene Arttır yazalır
            if (işlem == "Arttır") 
            {
                if (ortakErişim.OrtakListe.Grup.Contains("Aşçı") && artış == -1)
                {
                    ortakErişim.OrtakListe.Erzak = (int)(ortakErişim.OrtakListe.Erzak + artış * (ortakErişim.OrtakListe.Grup.Count / 1.5f)); //Aşçı varsa erzak daha fazla dayanır.
                }
                else
                {
                    ortakErişim.OrtakListe.Erzak = ortakErişim.OrtakListe.Erzak + artış * ortakErişim.OrtakListe.Grup.Count;
                }
                if(ortakErişim.OrtakListe.Erzak < 0){ ortakErişim.OrtakListe.Erzak = 0;}
            }
            else if (işlem == "Kontrol")
            {
                int günlükErzak = 5;
                Console.WriteLine($"Gruptakilerin sayısı: {ortakErişim.OrtakListe.Grup.Count}");
                if (ortakErişim.OrtakListe.Erzak > 0 && ortakErişim.OrtakListe.Grup.Contains("Aşçı"))
                {
                    günlükErzak = (int)(ortakErişim.OrtakListe.Erzak / (ortakErişim.OrtakListe.Grup.Count / 1.5f));
                    Console.WriteLine($"{günlükErzak} günlük erzağın var. (Aşçı var)");
                    if (günlükErzak <= 4 && günlükErzak != 0)
                    {
                        Console.WriteLine("\n E R Z A Ğ I N I Z   B İ T İ Y O R ! ! ! \n");
                    }
                }
                else if (ortakErişim.OrtakListe.Erzak > 0)
                {
                    günlükErzak = ortakErişim.OrtakListe.Erzak / ortakErişim.OrtakListe.Grup.Count;
                    Console.WriteLine($"{günlükErzak} günlük erzağın var.");
                    if (günlükErzak <= 4 && günlükErzak != 0)
                    {
                        Console.WriteLine("\n E R Z A Ğ I N I Z   B İ T İ Y O R ! ! ! \n");
                    }
                }
                else
                {
                    Console.WriteLine("\n E R Z A Ğ I N I Z   B İ T T İ \n");
                }
            }
        }

        private void İşlem(string bölge, string iş, int bölgeKodu = 0)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;

            //Erzak Alma Menüsü
            if (iş == "Erzak")
            {
                Console.WriteLine($"{ortakErişim.OrtakListe.Erzak/ortakErişim.OrtakListe.Grup.Count} günlük erzağın var.");
                int erzakGünlükFiyat = ortakErişim.OrtakListe.Grup.Count;
                Console.WriteLine($"Gün başına {erzakGünlükFiyat} para ödeyeceksin.");
                Console.WriteLine($"{ortakErişim.OrtakListe.Para} kadar paran var.");

                bool alışveriş = true;
                do
                {
                    Console.Write("Kaç günlük yiyecek almak istiyorsunuz? \n -> ");
                    string kullaniciGirdisi = Console.ReadLine();
                    if (int.TryParse(kullaniciGirdisi, out int gunlukYiyecek))
                    {
                        int tutar = gunlukYiyecek * erzakGünlükFiyat;
                        if (ortakErişim.OrtakListe.Para >= tutar)
                        {
                            Console.WriteLine($"Günlük yiyecek alımınız: {gunlukYiyecek} gün");
                            ortakErişim.OrtakListe.Para -= tutar;
                            Console.WriteLine($"Güncel paranız {ortakErişim.OrtakListe.Para}");
                            Erzak("Arttır", gunlukYiyecek);
                            int günlükErzak = ortakErişim.OrtakListe.Erzak / ortakErişim.OrtakListe.Grup.Count;
                            Console.WriteLine($"Günlük erzak stoğunuz ise {günlükErzak}");
                            alışveriş = false;
                            if (ortakErişim.OrtakListe.Olay.Contains("Avcı Koruma Bahşiş İsyanı"))
                            {
                                ortakErişim.OrtakListe.Olay.Remove("Avcı Koruma Bahşiş İsyanı");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Lütfen paranız yeten bir değer seçin, bay fakir.");
                            Console.WriteLine($"{gunlukYiyecek} gün çarpı {erzakGünlükFiyat} para, {tutar} para eder.");
                            Console.WriteLine($"Oysa senin {ortakErişim.OrtakListe.Para} paran var.");
                            alışveriş = false;
                        }
                    }
                    else
                    {
                        // Eğer dönüştürme başarısız olduysa, kullanıcıya hata mesajı gönder
                        Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    }
                } while (alışveriş);
            }
            
            //Eleman Alma Menüsü
            else if (iş == "Eleman")
            {
                List<string> alinabileceklerListesi = new List<string>();
                List<int> alinabileceklerListesiFiyat = new List<int>();

                GrupYazdır();

                int fiyatEleman = 10 + (ortakErişim.OrtakListe.Grup.Count * 5);
                Console.WriteLine($"\n{fiyatEleman} paraya 1 Eleman alabilirsin");
                alinabileceklerListesi.Add("Eleman");
                alinabileceklerListesiFiyat.Add(fiyatEleman);

                if (bölge == "Şehir")
                {
                    if (!ortakErişim.OrtakListe.Grup.Contains("Aşçı"))
                    {
                        int fiyatAşçı = 30;
                        Console.WriteLine($"{fiyatAşçı} paraya 1 Aşçı alabilirsin");
                        alinabileceklerListesi.Add("Aşçı");
                        alinabileceklerListesiFiyat.Add(fiyatAşçı);
                    }

                    if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma"))
                    {
                        if (!ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                        {
                            int fiyatKoruma = 50;
                            Console.WriteLine($"{fiyatKoruma} paraya Haşin Koruma alabilirsin.");
                            Console.WriteLine("(Haşin koruma en üst korumadır.)");
                            alinabileceklerListesi.Add("Haşin Koruma");
                            alinabileceklerListesiFiyat.Add(fiyatKoruma);
                        }
                    }else
                    {
                        int fiyatKoruma = 20;
                        Console.WriteLine($"{fiyatKoruma} paraya Basit Koruma alabilirsin.");
                        alinabileceklerListesi.Add("Basit Koruma");
                        alinabileceklerListesiFiyat.Add(fiyatKoruma);
                    }
                }

                alinabileceklerListesi.Add("Alma");
                alinabileceklerListesiFiyat.Add(0);
                Thread.Sleep(1000);

                // Kullanıcıya ne almak istediğini sorun
                Console.WriteLine("\n");
                for (int i = 0; i < alinabileceklerListesi.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {alinabileceklerListesi[i]}");
                }

                bool Continue = true;
                string secilenEleman = "Boş";
                int fiyatÖde = 0;
                do
                {
                    // Kullanıcının seçimini alın
                    Console.Write("Seçiminizi yapınız (sayı giriniz): ");
                    int kullaniciSecimi;

                    // Kullanıcının girdiği değeri kontrol etmek için TryParse kullanın
                    if (int.TryParse(Console.ReadLine(), out kullaniciSecimi) && kullaniciSecimi >= 1 && kullaniciSecimi <= alinabileceklerListesi.Count)
                    {
                        // Kullanıcının seçtiği elemanı alın
                        secilenEleman = alinabileceklerListesi[kullaniciSecimi - 1];
                        fiyatÖde = alinabileceklerListesiFiyat[kullaniciSecimi - 1];
                        Continue = false;
                        Console.WriteLine($"Seçiminiz: {secilenEleman}");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz bir seçim yaptınız.");
                    }
                } while (Continue);
                
                if(secilenEleman == "Alma")
                {
                    Console.WriteLine("Bir şey almadınız.");
                }
                else
                {
                    if (ortakErişim.OrtakListe.Para >= fiyatÖde)
                    {
                        ortakErişim.OrtakListe.Grup.Add(secilenEleman);
                        ortakErişim.OrtakListe.Para -= fiyatÖde;
                    }
                    else
                    {
                        Console.WriteLine("Paran yetersiz.");
                    }
                }
                Console.WriteLine($"Paran: {ortakErişim.OrtakListe.Para}");
            }
            
            //Ticaret Menüsü
            else if (iş == "Ticaret")
            {
                do
                {
                    Console.WriteLine($"{ortakErişim.OrtakListe.Para} paran var.");
                    Console.Write("\nAlmak için 1, satmak için 2, çıkmak için 3 gir.\n->");
                    string cevap = Console.ReadLine();

                    switch (cevap)
                    {
                        case "1":
                            TicaretAl(bölgeKodu, bölge);
                            Thread.Sleep(100);
                            break;

                        case "2":
                            TicaretSat(bölgeKodu, bölge);
                            Thread.Sleep(100);
                            break;

                        case "3":
                            Console.WriteLine("Pazardan çıktınız.");
                            return;

                        default:
                            Console.WriteLine("Geçersiz giriş. Lütfen '1', '2' veya '3' yazın.");
                            break;
                    }
                }while (true);
            }
        }


        private void TicaretSat(int bölgeKodu, string bölge)
        {
            #region Gerekli Referanslar
            Random random = new Random();
            Eşyalar EşyalarCs = new Eşyalar();
            OL_Singleton ortakErişim = OL_Singleton.Instance;

            List<string> satılacakEşyaListesi = new List<string>();
            List<int> satılacakEşyaFiyatları = new List<int>();
            List<int> tahminiFiyat = new List<int>();
            #endregion

            #region Şehir Kodu doğru mu kontrol
            var şehir = EşyalarCs.ŞehirlerListesi[bölgeKodu];
            if (şehir != null && şehir.AvailableItems != null)
            {
                foreach (var item in şehir.AvailableItems)
                {
                    if (item != null)
                    {
                        satılacakEşyaListesi.Add(item.Name);
                        satılacakEşyaFiyatları.Add(item.GetFinalPrice(EşyalarCs.ŞehirlerListesi[bölgeKodu].Name));
                    }
                }
            }
            else
            {
                Console.WriteLine("Beklenmeyen bir hatayla karşılaştık.");
                Console.WriteLine("System.ArgumentOutOfRangeException: 'Index was out of range. Must be non-negative and less than the size of the collection. Arg_ParamName_Name'");
                Console.WriteLine("Lütfen daha sonra tekrar deneyin.");
                Thread.Sleep(1000);
                return;
            }
            #endregion

            #region Oyundaki tek eşsiz eşyanın fiyatı
            if (ortakErişim.OrtakListe.Envanter.Contains("Aile Yâdigârı Gümüş Kolye"))
            {
                tahminiFiyat.Add(80);
            }
            #endregion

            #region Envanterdeki Eşyaları Fiyatlandırma
            for (int itemCount = 0; itemCount < ortakErişim.OrtakListe.Envanter.Count; itemCount++)
            {
                foreach (var item in satılacakEşyaListesi)
                {
                    if (ortakErişim.OrtakListe.Envanter[itemCount] == item)
                    {
                        //Console.WriteLine($"Envanterde aranan: {ortakErişim.OrtakListe.Envanter[itemCount]}, item: {item}, sayı {satılacakEşyaListesi.IndexOf(item)}, Fiyat {satılacakEşyaFiyatları[satılacakEşyaListesi.IndexOf(item)]}");
                        tahminiFiyat.Add(satılacakEşyaFiyatları[satılacakEşyaListesi.IndexOf(item)]);
                    }
                }
            }
            #endregion

            #region Eşya Fiyatlarıyla oynama
            double minDeger = 0.9;
            double maxDeger = 1.1;
            if (bölge == "Köy") //Köyde eşya satmak daha az kârlı
            {
                minDeger = 0.4;
                maxDeger = 0.9;
            }else if (bölge == "Şehir") //Şehirde eşya satmak çok daha kârlı
            {
                minDeger = 0.7;
                maxDeger = 1.1;
            }
            for (int i = 0; i < tahminiFiyat.Count; i++) //Bütün eşyaların fiyatlarını değiştir
            {
                double rastgelen = minDeger + (random.NextDouble() * (maxDeger - minDeger));
                tahminiFiyat[i] = (int)(tahminiFiyat[i] * rastgelen);
            }
            #endregion

            Thread.Sleep(1000);

            #region Eşya Satma Menüsü
            while (true)
            {
                #region Envanterdeki eşyaları yazdır
                Console.WriteLine($"\nParan: {ortakErişim.OrtakListe.Para}\n\nEnvanterin:");
                for (int i = 0; i < ortakErişim.OrtakListe.Envanter.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{ortakErişim.OrtakListe.Envanter[i]} için {tahminiFiyat[i]} ödeniyor.");
                }
                Thread.Sleep(100);
                Console.Write($"{tahminiFiyat.Count + 1}.Çıkış\n->");
                #endregion

                #region Sat
                while (true)
                {
                    string kullanıcıGirdisi = Console.ReadLine();

                    // Girdi kontrolü
                    if (int.TryParse(kullanıcıGirdisi, out int sayı))
                    {
                        Console.WriteLine("\nGirilen sayı: " + sayı);
                        // Girdi sayıya dönüştürülebiliyorsa
                        if (sayı <= tahminiFiyat.Count)
                        {
                            string eşyaSat = ortakErişim.OrtakListe.Envanter[sayı - 1];
                            int fiyatSat = tahminiFiyat[sayı - 1];
                            Console.WriteLine("Seçilen eşya: " + eşyaSat);
                            Console.WriteLine("Eşyanın fiyatı: " + fiyatSat);
                            ortakErişim.OrtakListe.Para += fiyatSat;
                            ortakErişim.OrtakListe.Envanter.RemoveAt(sayı - 1);
                            tahminiFiyat.RemoveAt(sayı - 1);

                            if (!ortakErişim.OrtakListe.Olay.Contains("Tüccariyet"))
                            {
                                ortakErişim.OrtakListe.Olay.Add("Tüccariyet");
                            }
                            break;
                        }
                        else if (sayı == tahminiFiyat.Count + 1)
                        {
                            Console.WriteLine("Çıkış yaptın.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Lütfen listedeki sayıları girin.\n->");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    }
                }
                #endregion
            }
            #endregion
        }

        private void TicaretAl(int bölgeKodu, string bölge)
        {
            #region Gerekli Referanslar
            Random random = new Random();
            Eşyalar EşyalarCs = new Eşyalar();
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            List<string> seçilenEşyalar = new List<string>();
            List<int> seçilenEşyalarFiyatları = new List<int>();
            List<string> alınacakEşyaListesi = new List<string>();
            List<int> alınacakEşyaFiyatları = new List<int>();
            List<int> alınacakEşyaNadirlikleri = new List<int>();
            #endregion

            #region RASTGELE EŞYA ÜRETİMİ
            foreach (var item in EşyalarCs.ŞehirlerListesi[bölgeKodu].AvailableItems)
            {
                alınacakEşyaListesi.Add(item.Name);
                alınacakEşyaFiyatları.Add(item.GetFinalPrice(EşyalarCs.ŞehirlerListesi[bölgeKodu].Name));
                alınacakEşyaNadirlikleri.Add(item.GetFinalRarity(EşyalarCs.ŞehirlerListesi[bölgeKodu].Name));
            }

            // Bütün eşya sayılarının toplandığı değişken
            int toplamEşyaSayısı = alınacakEşyaNadirlikleri.Sum();

            int minEşyaSayısı = 5;
            int maxEşyaSayısı = 10;
            if (bölge == "Şehir")
            {
                minEşyaSayısı = 8;
                maxEşyaSayısı = 16;
            }else if (bölge == "Köy")
            {
                minEşyaSayısı = 3;
                maxEşyaSayısı = 8;
            }
            int EşyaSayısıForDöngü = random.Next(minEşyaSayısı, maxEşyaSayısı + 1);

            // Seçilen eşyayı bir listeye ekleme
            for (int döngüEşya = 0; döngüEşya < EşyaSayısıForDöngü; döngüEşya++)
            {
                // Rastgele sayı seçimi
                int rastgeleSayı = random.Next(1, toplamEşyaSayısı + 1);

                // Seçilen sayıya göre eşya seçimi
                int toplam = 0;
                string seçilenEşya = "";
                int seçilenEşyaFiyatı = 0;
                for (int i = 0; i < alınacakEşyaListesi.Count; i++)
                {
                    toplam += alınacakEşyaNadirlikleri[i];
                    if (rastgeleSayı <= toplam)
                    {
                        seçilenEşya = alınacakEşyaListesi[i];
                        seçilenEşyaFiyatı = alınacakEşyaFiyatları[i];
                        break;
                    }
                }
                seçilenEşyalar.Add(seçilenEşya); 
                double faktör = random.NextDouble() * (1.15 - 0.85) + 0.85;
                seçilenEşyalarFiyatları.Add((int)(seçilenEşyaFiyatı * faktör));
            }
            #endregion

            #region EŞYA ALIMI
            while (true)
            {
                // Sonuçları yazdırma
                Console.WriteLine($"\nParan: {ortakErişim.OrtakListe.Para}\nEşyalar:");
                for (int i = 0; i < seçilenEşyalar.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{seçilenEşyalar[i]}: {seçilenEşyalarFiyatları[i]}");
                }
                Thread.Sleep(100);

                Console.Write($"{seçilenEşyalar.Count + 1}.Çıkış\n->");
                while (true)
                {
                    string kullanıcıGirdisi = Console.ReadLine();

                    // Girdi kontrolü
                    if (int.TryParse(kullanıcıGirdisi, out int sayı))
                    {
                        Console.WriteLine("\nGirilen sayı: " + sayı);
                        // Girdi sayıya dönüştürülebiliyorsa
                        string arananEleman = "Eleman";
                        int elemanSayısı = ortakErişim.OrtakListe.Grup.Count(e => e == arananEleman);
                        int envanterdekilerinSayısı = ortakErişim.OrtakListe.Envanter.Count();
                        //Console.WriteLine($"{elemanSayısı}, {envanterdekilerinSayısı}");
                        if (sayı <= seçilenEşyalar.Count)
                        {
                            string eşyaAl = seçilenEşyalar[sayı - 1];
                            int fiyatAl = seçilenEşyalarFiyatları[sayı - 1];
                            Console.WriteLine("Seçilen eşya: " + eşyaAl);
                            Console.WriteLine("Eşyanın fiyatı: " + fiyatAl);
                            if (fiyatAl > ortakErişim.OrtakListe.Para)
                            {
                                Console.WriteLine($"Bu eşyaya paran ({ortakErişim.OrtakListe.Para}) yetmedi.");
                                Thread.Sleep(724);
                            }
                            else if (!(elemanSayısı * 4 > envanterdekilerinSayısı))
                            {
                                Console.WriteLine($"\nDaha fazla eşya alabilmek için 'Eleman' alman lazım.");
                                Thread.Sleep(2000);
                                return;
                            }
                            else
                            {
                                ortakErişim.OrtakListe.Envanter.Add(eşyaAl);
                                ortakErişim.OrtakListe.Para -= fiyatAl;
                                seçilenEşyalar.RemoveAt(sayı - 1);
                                seçilenEşyalarFiyatları.RemoveAt(sayı - 1);
                            }
                            break;
                        }
                        else if (sayı == seçilenEşyalar.Count + 1)
                        {
                            Console.WriteLine("Çıkış yaptın.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Lütfen listedeki sayıları girin.\n->");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                    }
                }
            }

            #endregion
        }
    }
}
