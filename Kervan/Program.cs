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

        Sıfırla();
        ŞehirCs.BaşlarkenHazırlık();

        //Bu programı çalıştırıp direk çıkanlar için bir şakadır.
        #region Şaka
        if (!ortakErişim.OrtakListe.Olay.Contains("Çık"))
        { ortakErişim.OrtakListe.Olay.Add("Çıkış"); }
        #endregion 

        Menu();

        Console.WriteLine("\n\n\n\n\n\n\n\n\n");
        Console.WriteLine("P haritadaki sizin bulunduğunuz konumu gösterir.\n\n\n");

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
        Console.WriteLine("\n\nSelamlar!\n\nKervan oyununa hoşgeldin!");
        Thread.Sleep(2000);
        while (true)
        {
            #region Menü Yazıları
            Console.WriteLine("\n\n\n1.Oyuna Başla");
            Console.WriteLine("2.Son Kaydı Oyna");
            Console.WriteLine("3.Dil Seçeneklerini Gör");
            Console.WriteLine("4.Hile Kodlarını Gör");
            Console.WriteLine("5.Oyun Hakkında Bilgi Al");
            Console.WriteLine("6.Yapımcıları Hakkında Bilgi Al");
            Console.WriteLine("7.Çıkış Yap");
            Console.WriteLine("Lütfen 1-7 arası bir sayı girin: ");
            #endregion

            if (int.TryParse(Console.ReadLine(), out int sayi))
            {
                Console.WriteLine("\n\n\n");
                switch (sayi)
                {
                    //Oyunu başlat
                    case 1: 
                        Console.WriteLine("Oyun Başlatılıyor");
                        Thread.Sleep(450);
                        Console.Write(".");
                        Thread.Sleep(450);
                        Console.Write(".");
                        Thread.Sleep(450);
                        Console.Write(".");
                        return;

                    //Kaydedilmiş Son Oyunu Açar
                    case 2: 
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n");
                        Console.WriteLine("P haritadaki sizin bulunduğunuz konumu gösterir.\n\n\n");
                        Şehir ŞehirCs = new Şehir();
                        Kayıt KayıtCs = new Kayıt();
                        KayıtCs.KayıtDosyası("yükle");
                        return;

                    //Dil Seçeneği
                    case 3: 
                        CiddiliYaz("Kısıtlı zamandan mütevellit başka bir dil eklenememiştir.", 35, 100);
                        Thread.Sleep(400);
                        break;

                    //Hile kodları
                    case 4: 
                        Console.WriteLine("Hile kodu: 1 50");
                        Console.WriteLine("(Para ekler)");
                        Console.WriteLine("Hile kodu: 1 150");
                        Console.WriteLine("(Para ekler)");
                        Console.WriteLine("Hile kodu: 2 10");
                        Console.WriteLine("(Erzak ekler)");
                        Console.WriteLine("Hile kodu: 2 50");
                        Console.WriteLine("(Erzak ekler)");
                        Console.WriteLine("Hile kodu: 3 1");
                        Console.WriteLine("(Alakasız)");
                        Console.WriteLine("Hile kodu: 3 2");
                        Console.WriteLine("(Alakasız)");
                        Console.WriteLine("Hile kodu: 3 3");
                        Console.WriteLine("(Alakasız)");
                        Console.WriteLine("(Bu kodların çalışması için haritada w-a-s-d girebildiğiniz kısma yazmanız gerekmektedir.)");
                        Console.WriteLine("Ayrıca kumarhanede sayı bilmeye çalışırken 'kumarbaz' yazmak sayıyı ifşalar.");
                        break;

                    // Oyun hakkında bilgi
                    case 5: 
                        Console.WriteLine("Oyun Mount&Blade Warband oyunundaki ticaret kervanlarından esinlenilmiştir.");
                        Thread.Sleep(123);
                        Console.WriteLine("Amacımız Şehirler ve Köyler arasında dolaşarak eşya alıp satmak ve para kazanmaktır.");
                        Thread.Sleep(123);
                        Console.WriteLine("1000 parayı geçince oyunu bitirmiş ve kazanmış olursunuz.");
                        Thread.Sleep(123);
                        Console.WriteLine("5 Paranız kalmazsa ve envanterinizde eşyanız da yoksa, iflas etmiş olursunuz ve kaybedersiniz.");
                        Thread.Sleep(123);
                        Console.WriteLine("Oyunda 8 yerleşke bulunup 3'ü Şehir 5'i Köydür.");
                        Thread.Sleep(123);
                        Console.WriteLine("Köylerden alıp Şehirlerde satmak görece kârlıdır (tavsiyedir)");
                        Thread.Sleep(123);
                        Console.WriteLine("Köylerin isimleri yoğunluklu üretimi göstermektedir. ");
                        Thread.Sleep(123);
                        Console.WriteLine("Mesela Koyuncular Köyünde Yün'ü ve Et'i daha fazla bulabilirsiniz.");
                        Thread.Sleep(123);
                        Console.WriteLine("İyi oyunlar!");
                        Thread.Sleep(300);
                        break;

                    //Yapımcı Hakkında Bilgi
                    case 6: 
                        Console.WriteLine("Yapımcı, bendeniz Mushu");
                        Thread.Sleep(444);
                        Console.WriteLine("''Muhammet Şua Can''");
                        Thread.Sleep(1000);
                        Console.WriteLine("\nProjenin yapımında büyük oranda 'GPT-3.5 tabanlı dil modeli'nden yardım görülmüştür.");
                        Thread.Sleep(700);
                        Console.WriteLine("Kodların %75'ini ona yazdırdım ama bütünde bir oyun olabilmesi için %70'ını falan değiştirmek durumunda,");
                        Thread.Sleep(700);
                        Console.Write("ayarlamak durumunda kaldım.");
                        Thread.Sleep(400);
                        Console.Write("\n%60 derken %75'in %70'ı yani bütün kodlara oranladığımızda %25 kendim yazdım %52,5'ını gpt'den lıp değiştirdim.");
                        Console.Write("Geri kalan da gpt'nin kodu. Mesela Instance'ı pek anlamadım. Ama çalışıyor yani.");
                        break;

                    // Çıkış
                    case 7:
                        //Bu if programı başlatıp oyuna girmeden çıkanlara yazılmıştır.
                        if (ortakErişim.OrtakListe.Olay.Contains("Çıkış")) //Şaka bu if'in içinde
                        {
                            CiddiliYaz("Oyunu kapatmak için mi açtın?");
                            Thread.Sleep(1000);
                            CiddiliYaz("Neyse tamam kapatıyorum.");
                            Thread.Sleep(1000);
                        }
                        Environment.Exit(0); // Çıkış kodu 0 (Evet tabii ki de chat GPT'den aldım.)
                        break;

                    default:
                        Console.WriteLine("Geçersiz giriş. Lütfen 1-5 arası bir sayı girin.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
            }
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
}
