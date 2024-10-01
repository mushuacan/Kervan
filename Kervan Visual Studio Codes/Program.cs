using Kervan;
using System;
using System.ComponentModel.Design;

class Program
{
    public static void Main()
    {
        #region Gerekli Referanslar
        Şehir ŞehirCs = new Şehir();
        Harita haritaCs = new Harita();
        OL_Singleton ortakErişim = OL_Singleton.Instance;
        #endregion



        //En üstten aşağı gitmek nedense rahatsız edici geliyor. Direk aşağıdan başlaıyorum.
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        //ortakErişim.OrtakListe.Olay.Add("Dil: Türkçe");
        ortakErişim.OrtakListe.Olay.Add(VersiyonBul(2));

        if (VersiyonBul(2) == "Dil: Türkçe")
        {
            Language.SetLanguage("Türkçe.txt");
            DiliDeğiştir(2, "Dil: Türkçe");
        }
        else if (VersiyonBul(2) == "Dil: İngilizce")
        {
            Language.SetLanguage("English.txt");
            DiliDeğiştir(2, "Dil: İngilizce");
        }
        else
        {
            //eror
        }


        Sıfırla();
        ŞehirCs.BaşlarkenHazırlık();

        //Bu programı çalıştırıp direk çıkanlar için bir şakadır.
        #region Şaka
        if (!ortakErişim.OrtakListe.Olay.Contains("Çık"))
        { ortakErişim.OrtakListe.Olay.Add("Çıkış"); }
        #endregion 

        Menu();

        Console.WriteLine("\n\n\n\n\n\n\n\n\n");
        Harita harita = new Harita();
        harita.HaritaBilgilendirme("Harita");
        Thread.Sleep(1500);
        //Console.WriteLine(Language.GetText("Program.Main.BeforeStart")); //Buna gerek kalmadı.

        haritaCs.haritaHazırla();
        haritaCs.haritaYazdır();

        //Oyun başlayınca çıkarken şakalamayı kapatır.
        #region Şakayı Boz
        ortakErişim.OrtakListe.Olay.Remove("Çıkış");
        ortakErişim.OrtakListe.Olay.Add("Çık");
        #endregion

        //Oyun döngüsü
        while (true)
        {
            haritaCs.oyuncuHareketEtHaritaYazdır();
        }

        #region Asla Gözükmeyecek Çıktı
        Console.Write("\n\n\nProgram sonlanmıştır.\n"); //Aska gözükmeyecek.
        //Bunu dil dosyalarına bile yazmayacağım.
        //Çünkü bu burada unutlacak, kimse de görmeyecek.
        //Yapayalnız ve çok ıssız...
        //Gerçi Allah görür, Allah da bilirse
        //Başkasının bilmesine gerek kalmaz.
        //Gerçekten de Allah kimsesizlerin kimsesi...
        #endregion
    }

    public void Maincik() //Oyunu baştan başlat (Diğer scriptlerden başlatamadım böyle bir seçenek buldum.)
    {
        Sıfırla();
        Main();
    }

    public static void Sıfırla() //Bütün global bilgileri sıfırlar.
    {
        OL_Singleton ortakErişim = OL_Singleton.Instance;

        bool şakaHatasıDüzelt = false;
        if (ortakErişim.OrtakListe.Olay.Contains("Çık"))
        {
            şakaHatasıDüzelt = true;
        }

        ortakErişim.OrtakListe.Para = 100;
        ortakErişim.OrtakListe.Erzak = 44;
        ortakErişim.OrtakListe.Envanter.Clear();
        ortakErişim.OrtakListe.Grup.Clear();
        ortakErişim.OrtakListe.Olay.Clear();

        if (şakaHatasıDüzelt)
        {
            ortakErişim.OrtakListe.Olay.Add("Çık");
        }
    }

    private static void Menu()
    {
        OL_Singleton ortakErişim = OL_Singleton.Instance;
        Console.WriteLine("\n\n" + Language.GetText("Program.Menu.Selam.1") + "\n\n" + Language.GetText("Program.Menu.Selam.2"));
        Thread.Sleep(2000);
        Console.WriteLine( "\n\n" + Language.GetText("versiyon") + " " + VersiyonBul(0) + "\n" + Language.GetText("versiyonTarihi") + " " + VersiyonBul(1));
        Thread.Sleep(1000);
        while (true)
        {
            #region Menü Yazıları
            Console.WriteLine("\n\n\n");
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine(Language.GetText($"Program.Menu.Menu.{i}"));
            }
            #endregion

            string girdi = Console.ReadLine();

            if (int.TryParse(girdi, out int sayi))
            {
                Console.WriteLine("\n\n\n");
                switch (sayi)
                {
                    //Oyunu başlat
                    case 1:
                        Console.WriteLine(Language.GetText("Program.Menu.Case1"));
                        Thread.Sleep(450);
                        Console.Write(".");
                        Thread.Sleep(450);
                        Console.Write(".");
                        Thread.Sleep(450);
                        Console.Write(".");
                        Thread.Sleep(150);
                        Hikaye();
                        return;

                    //Kaydedilmiş Son Oyunu Açar
                    case 2: 
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                        Console.WriteLine(Language.GetText("Program.Menu.Case2") + "\n\n\n");
                        Şehir ŞehirCs = new Şehir();
                        Kayıt KayıtCs = new Kayıt();
                        KayıtCs.KayıtDosyası("yükle");
                        return;

                    //Dil Seçeneği
                    case 3:
                        Console.WriteLine(Language.GetText("Program.Menu.Case3"));
                        Thread.Sleep(400);
                        Console.WriteLine(Language.GetText("Program.Menu.Case3.1"));
                        Console.WriteLine(Language.GetText("Program.Menu.Case3.2"));
                        Console.WriteLine(Language.GetText("Program.Menu.Case3.3"));
                        Console.Write(Language.GetText("Program.Menu.Case3.4"));
                        while (true)
                        {
                            // Kullanıcının seçimini al
                            string dilSeçimi = Console.ReadLine();

                            // Kullanıcının seçimine göre dil dosyasını ayarla
                            if (dilSeçimi == "1")
                            {
                                Language.SetLanguage("Türkçe.txt");
                                DiliDeğiştir(2, "Dil: Türkçe");
                                break;
                            }
                            else if (dilSeçimi == "2")
                            {
                                Language.SetLanguage("English.txt");
                                DiliDeğiştir(2, "Dil: İngilizce");
                                break;
                            }
                            else
                            {
                                Console.WriteLine(Language.GetText("All.GeçersizGirdiSayıGir"));
                            }
                        }
                        Thread.Sleep(400);
                        break;

                    //Kazanım kodları
                    case 4:
                        KazanımlarVeSonlar kazanımYönetimi = new KazanımlarVeSonlar();
                        //kazanımYönetimi.KazanımlarıListele();
                        Console.WriteLine();
                        kazanımYönetimi.BitirilenSonlarıListele();
                        Console.WriteLine();
                        kazanımYönetimi.TümKazanımVeSonlarıListele();
                        break;

                    // Oyun hakkında bilgi
                    case 5: 
                        for (int i = 1;  i < 10; i++)
                        {
                            Console.WriteLine(Language.GetText($"Program.Menu.Case5.{i}"));
                            Thread.Sleep(123);
                        }
                        Thread.Sleep(177);
                        break;

                    //Yapımcı Hakkında Bilgi
                    case 6:
                        Console.WriteLine(Language.GetText("Program.Menu.Case6.1"));
                        Thread.Sleep(444);
                        Console.WriteLine(Language.GetText("Program.Menu.Case6.2"));
                        Thread.Sleep(1000);
                        Console.WriteLine("\n" + Language.GetText("Program.Menu.Case6.3"));
                        Thread.Sleep(700);
                        Console.WriteLine(Language.GetText("Program.Menu.Case6.4"));
                        Thread.Sleep(700);
                        Console.Write(Language.GetText("Program.Menu.Case6.5"));
                        Thread.Sleep(400);
                        Console.Write("\n" + Language.GetText("Program.Menu.Case6.6"));
                        Console.Write(Language.GetText("Program.Menu.Case6.7"));
                        break;

                    // Çıkış
                    case 7:
                        //Bu if programı başlatıp oyuna girmeden çıkanlara yazılmıştır.
                        if (ortakErişim.OrtakListe.Olay.Contains("Çıkış")) //Şaka bu if'in içinde
                        {
                            CiddiliYaz(Language.GetText("Program.Menu.Case7.1"));
                            Thread.Sleep(1000);
                            CiddiliYaz(Language.GetText("Program.Menu.Case7.2"));
                            Thread.Sleep(1000);
                        }
                        Environment.Exit(0); // Çıkış kodu 0 (Evet tabii ki de chat GPT'den aldım.)
                        break;

                    default:

                        Console.WriteLine(Language.GetText("Program.Menu.CaseDefault"));
                        break;
                }
            }
            else
            {
                if (girdi == "Hileciyim ben")
                {
                    Console.WriteLine("Hile kodu: 1 50");
                    Console.WriteLine(Language.GetText("Program.Menu.Case4.Hile1"));
                    Console.WriteLine("Hile kodu: 1 150");
                    Console.WriteLine(Language.GetText("Program.Menu.Case4.Hile1"));
                    Console.WriteLine("Hile kodu: 2 10");
                    Console.WriteLine(Language.GetText("Program.Menu.Case4.Hile2"));
                    Console.WriteLine("Hile kodu: 2 50");
                    Console.WriteLine(Language.GetText("Program.Menu.Case4.Hile2"));
                    Console.WriteLine("Hile kodu: 3 1");
                    Console.WriteLine(Language.GetText("Program.Menu.Case4.Hile31"));
                    Console.WriteLine("Hile kodu: 3 2");
                    Console.WriteLine(Language.GetText("Program.Menu.Case4.Hile32"));
                    Console.WriteLine("Hile kodu: 3 3");
                    Console.WriteLine(Language.GetText("Program.Menu.Case4.Hile33"));
                    Console.WriteLine(Language.GetText("Program.Menu.Case41"));
                    Console.WriteLine(Language.GetText("Program.Menu.Case42"));
                }
                else
                {
                    Console.WriteLine(Language.GetText("All.GeçersizGirdiSayıGir"));
                }
            }
        }
        
    }

    static string VersiyonBul(int sıraNo)
    {
        // Okunacak dosyanın yolunu belirtin
        string dosyaYolu = "SaveData//Bilgiler.txt";

        // Satırları saklamak için bir liste oluşturun
        List<string> satırlar = new List<string>();

        try
        {
            // Dosyayı StreamReader ile açın
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                string satır;
                // Dosyanın sonuna kadar satırları okuyun
                while ((satır = sr.ReadLine()) != null)
                {
                    // Okunan satırı listeye ekleyin
                    satırlar.Add(satır);
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }

        return satırlar[sıraNo];
    }

    static void DiliDeğiştir(int sıraNo, string yeniSatır)
    {
        // Dosya yolunu belirtin
        string dosyaYolu = "SaveData//Bilgiler.txt";

        // Satırları saklamak için bir liste oluşturun
        List<string> satırlar = new List<string>();

        try
        {
            // Dosyayı okuyun ve satırları listeye ekleyin
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                string satır;
                while ((satır = sr.ReadLine()) != null)
                {
                    satırlar.Add(satır);
                }
            }

            // Listeyi kontrol et, eğer sıraNo geçerli değilse hata döndür
            if (sıraNo < 0 || sıraNo >= satırlar.Count)
            {
                Console.WriteLine("Geçersiz sıra numarası!");
                return;
            }

            // İlgili satırı değiştir
            satırlar[sıraNo] = yeniSatır;

            // Dosyayı tekrar yazın
            using (StreamWriter sw = new StreamWriter(dosyaYolu))
            {
                foreach (string s in satırlar)
                {
                    sw.WriteLine(s);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }


    static void CiddiliYaz(string metin, int minDeğer = 25, int maxDeğer = 105)
    {
        Random random = new Random();
        int rastgele;
        foreach (char harf in metin)
        {
            rastgele = random.Next(minDeğer, maxDeğer);
            Console.Write(harf);
            Thread.Sleep(rastgele);
        }
        Thread.Sleep(444);
        Console.Write("\n");
    }


    static void Hikaye()
    {
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

        Console.WriteLine(Language.GetText("HikayeGösterelimMi"));
        Console.WriteLine(Language.GetText("HikayeGösterelimMi.Açıklama"));
        string cevap = Console.ReadLine();
        if (cevap == "1")
        {
            //Hikâyeyi anlat
            for (int i = 1; i < 10; i++)
            {
                CiddiliYaz(Language.GetText("Hikaye" + "." + i));
            }
        }
        else if (cevap == "0")
        {
            //direk oyunu başlatır
            CiddiliYaz(Language.GetText("Hikaye.red"));
        }
        else
        {
            //Hiç bekletmeden başlat
        }

    }
}
