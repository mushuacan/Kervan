using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kervan
{
    internal class Harita
    {
        // Verilen harita
        string[] harita = {
            "#####################",
            "####..8.........#####",
            "###........7.......##",
            "##?.....##.....6...##",
            "##??...##.........###",
            "##????###..5....#####",
            "####????##.......####",
            "#####???####......###",
            "###....?##3...#..4###",
            "#...1....#........###",
            "#..................##",
            "########..2......####",
            "#####################"
        };

        // Haritayı liste olarak temsil etmek için
        List<List<char>> haritaListesi = new List<List<char>>();

        public int oyuncuKonumX = 4;
        public int oyuncuKonumY = 10;

        bool iflasdenemesi = false;

        void HaritaBilgilendirme(string bildiri)
        {
            if (bildiri == "Harita")
            {
                Console.WriteLine(" P -> Bulunduğunuz konumu gösterir.");
                Console.WriteLine(" # -> Engebeli arazi veya deniz (üzerinden geçilemez.)");
                Console.WriteLine(" . -> Boş arazi. Geçilebilir.");
                Console.WriteLine(" ? -> Tehlikeli arazi. Geçenlerden haber alınamıyor.");
                Console.WriteLine(" 1-2 gibi sayılar -> Şehirleri veya köyleri (Yerleşkeleri) ifade eder.");
                //Console.WriteLine(" S -> Oyunu save almak için gitmeniz gereken yer.");
                Console.WriteLine("\n");
            }else if (bildiri == "Yerleşke")
            {
                Eşyalar EşyalarCs = new Eşyalar();
                EşyalarCs.Print("Şehirler");
            }
        }



        public void oyuncuHareketEtHaritaYazdır()
        {
            oyuncuHareket();
            oyunBekasıKontrol();
            haritaYazdır();
        }

        public void oyunBekasıKontrol()
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            if (ortakErişim.OrtakListe.Para < 5 && ortakErişim.OrtakListe.Envanter.Count <= 1)
            {
                Vakalar vakaCs = new Vakalar();
                Yazİflas("Beş paran kalmadı. Eşyan da yok.");
                Yazİflas("Etrafındaki herkes sayıp sövüp gitti.");
                vakaCs.VakaAyrıştırıcı("Son");
            }
            if (ortakErişim.OrtakListe.Para >= 1000 )
            {
                Vakalar vakaCs = new Vakalar();
                Şehir ŞehirCs = new Şehir();
                Yazİflas("Şanlı oyuncu!");
                Yazİflas("Paran 1000'i geçti.");
                Console.WriteLine($"Paran: {ortakErişim.OrtakListe.Para}");
                Console.WriteLine($"{ortakErişim.OrtakListe.Erzak / ortakErişim.OrtakListe.Grup.Count} günlük erzağın var.");
                Thread.Sleep(1000);
                ŞehirCs.GrupYazdır();
                Thread.Sleep(1000);
                ŞehirCs.EnvanterYazdır();
                Thread.Sleep(2000);
                Yazİflas("Gerçek bir tüccarsın.");
                Yazİflas("Oynadığın için teşekkürler.");
                Yazİflas("\n\n\n", 200, 500);
                Yazİflas("Kazandın!");
                Program program = new Program();
                program.Maincik();
            }
        }

        public void oyuncuHareket()
        {
            // Oyuncunun yönüne göre konumunu güncelle
            Eşyalar EşyalarCs = new Eşyalar();
            Şehir ŞehirCs = new Şehir();
            ŞehirCs.Erzak("Kontrol");
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Console.Write("Yön Seçimi (w-Yukarı, d-Sağa, s-Aşağı, a-Sola");
            Console.Write(", 1-Harita bilgilendirmesi, 2-Yerleşkeler,\n 3-Kendi bilgilerin, 4-Kaydedip çıkmak için)\n-> ");
            string yon = Console.ReadLine();

            switch (yon)
            {
                case "w":
                    oyuncuKonumDeğişikliği(0, -1);
                    break;
                case "d":
                    oyuncuKonumDeğişikliği(1, 0);
                    break;
                case "s":
                    oyuncuKonumDeğişikliği(0, 1);
                    break;
                case "a":
                    oyuncuKonumDeğişikliği(-1, 0);
                    break;
                case "1":
                    HaritaBilgilendirme("Harita");
                    oyuncuHareket();
                    Thread.Sleep(500);
                    break;
                case "2":
                    HaritaBilgilendirme("Yerleşke");
                    oyuncuHareket();
                    Thread.Sleep(500);
                    break;
                case "3":
                    Console.WriteLine($"Paran: {ortakErişim.OrtakListe.Para}");
                    Console.WriteLine($"{ortakErişim.OrtakListe.Erzak / ortakErişim.OrtakListe.Grup.Count} günlük erzağın var.");
                    Thread.Sleep( 1000 );
                    ŞehirCs.GrupYazdır();
                    Thread.Sleep( 1000 );
                    ŞehirCs.EnvanterYazdır();
                    Thread.Sleep(1000);
                    break;
                case "4":
                    KaydetVeÇık();
                    break;
                case "konum":
                    Console.WriteLine($"Konumun: {oyuncuKonumX}, {oyuncuKonumY}");
                    oyuncuHareket();
                    break;
                case "şehir":
                    EşyalarCs.Print("Şehirler");
                    Thread.Sleep(500);
                    break;
                case "iflas":
                    #region İflas Konuşması
                    if(iflasdenemesi) { break; }
                    Yazİflas("O kadar acınasısın ki!");
                    Yazİflas("O kadar korkaksın ki!");
                    Yazİflas("Dayanamadan terk ediyorsun hemen.");
                    Yazİflas("Seninle kim bir yola çıksa yarıda kalır.");
                    Yazİflas("Hani diyarın en zengin tüccarı olacaktık?", 65, 120);
                    Yazİflas("Hani onlarca kervanımız olacaktı?", 90, 130);
                    Console.WriteLine();
                    Yazİflas("Vazgeçmişliğinle öğrendin bu hayat zor.");
                    Yazİflas("Devam eden herkes mücadeleyi sürdürüyor.");
                    Yazİflas("Sense korkaklık ettin. Bu kadar dedin.");
                    Yazİflas("Neyime yaracak ki bu köhne diyar dedin.");
                    Yazİflas("Adın çıkmadı merak etme ama korkaksın.");
                    Yazİflas("Geçmişe baktın mı hep hüzne bakacaksın.", 90, 130);
                    Console.WriteLine();
                    Yazİflas("Son bir şansın var, 'vazgeç'ecek misin? Yoksa 'terk' mi edeceksin?");
                    bool iflasDöngüsü = true;
                    do{ Console.Write(" -> ");
                        string cevap = Console.ReadLine();
                        if (cevap == "Vazgeç") { Yazİflas("Helal olsun, vazgeçmeyeceğini biliyordum."); iflasDöngüsü = false; }
                        else if (cevap == "Terk et") { Yazİflas("Tamam\n", 150, 160); Thread.Sleep(2000); Yazİflas("KORKAK", 300, 320); Thread.Sleep(200); Environment.Exit(0); }
                        else { Yazİflas("Anlayabilmem için 'Vazgeç' veya 'Terk et' yaz.", 15, 35); }
                    } while (iflasDöngüsü);
                    iflasdenemesi = true;
                    #endregion
                    break;
                case "Hile kodu: 1 50":
                    ortakErişim.OrtakListe.Para += 50;
                    break;
                case "Hile kodu: 1 150":
                    ortakErişim.OrtakListe.Para += 150;
                    break;
                case "Hile kodu: 2 10":
                    ortakErişim.OrtakListe.Erzak += 10 * ortakErişim.OrtakListe.Grup.Count;
                    break;
                case "Hile kodu: 2 50":
                    ortakErişim.OrtakListe.Erzak += 50 * ortakErişim.OrtakListe.Grup.Count;
                    break;
                case "Hile kodu: 3 1":
                    EşyalarCs.Print("Şehirler+Eşyalar");
                    break;

                case "Hile kodu: 3 2":
                    EşyalarCs.Print("Şehirler");
                    break;

                case "Hile kodu: 3 3":
                    EşyalarCs.Print("Eşyalar");
                    break;

                default:
                    Console.WriteLine("Geçersiz yönlendirme.");
                    Thread.Sleep(500);
                    oyuncuHareket();
                    break;
            }
        }

        #region iflas efekti
        static void Yazİflas(string metin, int minDeğer = 25, int maxDeğer = 105)
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
        #endregion

        #region OYUNCU HAREKETİ ALAKADAR

        public void oyuncuKonumDeğişikliği(int konumX, int konumY)
        {
            string konumdakiBlok = string.Concat(haritaListesi[konumY + oyuncuKonumY][konumX + oyuncuKonumX]);

            Şehir ŞehirCs = new Şehir();

            switch (konumdakiBlok)
            {
                case "#":
                    haritaYazdır();
                    Console.WriteLine("Gitmek istenen konumda engel var. Lütfen tekrar deneyin.");
                    oyuncuHareket();
                    break;
                case ".":
                    oyuncuKonumX = konumX + oyuncuKonumX;
                    oyuncuKonumY = konumY + oyuncuKonumY;
                    OlayKontrolMakenizması();
                    ŞehirCs.Erzak("Arttır", -1);
                    break;
                case "?":
                    oyuncuKonumX = konumX + oyuncuKonumX;
                    oyuncuKonumY = konumY + oyuncuKonumY;
                    TehlikeliArazi();
                    ŞehirCs.Erzak("Arttır", -1);
                    break;
                default:

                    // Girişi bir tamsayıya dönüştürme
                    if (int.TryParse(konumdakiBlok, out int sayı))
                    {
                        if (sayı == 2 || sayı == 5 || sayı == 8)
                        { ŞehirCs.Şehrinİçinde(sayı); }
                        else { ŞehirCs.Köyünİçinde(sayı); }
                    }
                    else
                    {
                        Console.WriteLine("İlerleyeceğiniz yön saptanamadı. Lütfen o yöne gitmeyiniz.");
                        // Giriş geçerli bir tamsayı değilse, uygun bir hata mesajı verebilir veya programı sonlandırabilirsiniz.
                    }
                    break;
            }

        }




        #endregion


        #region HARİTA ALAKADAR

        public void haritaHazırla()
        {
            // Her satırı dön
            foreach (var satir in harita)
            {
                // Satırdaki her karakteri liste olarak ekle
                List<char> satirListesi = new List<char>();
                foreach (var karakter in satir)
                {
                    satirListesi.Add(karakter);
                }

                // Satır listesini harita listesine ekle
                haritaListesi.Add(satirListesi);
            }
        }

        public void haritaYazdır()
        {
            // Haritayı kopyala
            List<List<char>> haritaListeKopyası = KopyalaHaritayi(haritaListesi);

            // Kopyadaki oyuncunun konumunu 'P' ile değiştir
            haritaListeKopyası[oyuncuKonumY][oyuncuKonumX] = 'P';

            // Haritayı yazdır
            Yazdir(haritaListeKopyası);

        }

        static List<List<char>> KopyalaHaritayi(List<List<char>> orijinalHarita)
        {
            // Yeni bir liste oluştur ve orijinal haritayı derin kopyala
            List<List<char>> kopyaHarita = new List<List<char>>();
            foreach (var satir in orijinalHarita)
            {
                kopyaHarita.Add(new List<char>(satir));
            }
            return kopyaHarita;
        }

        

        static void Yazdir(List<List<char>> haritalık)
        {
            // Harita listesini yazdır
            foreach (var satirListesi in haritalık)
            {
                foreach (var karakter in satirListesi)
                {
                    Console.Write(karakter + "");
                }
                Console.WriteLine();
            }
        }
        #endregion



        static void OlayKontrolMakenizması()
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Random random = new Random();
            Vakalar vakaCs = new Vakalar();
            int rastgele = random.Next(1, 11);

            if (ortakErişim.OrtakListe.Olay.Contains("Doktor") && rastgele == 1)
            {
                Yazİflas("\nYolda hastalığın iyice ağırlaştı.");
                Yazİflas("Kervanı şehirde doktor görmek için terk ettin.");
                Yazİflas("Ancak yanındaki kişinin ısrarı üzere bir ağaç gölgesinde durdun.");
                Yazİflas("Doktoru buraya çağırmak için gitti.");
                Yazİflas("Dönmesini beklerken uyanamayacağın bir uykuya daldın.");
                Yazİflas("\n\n\nOyun Bitti.\n\nOynadığınız için teşekkürler.");
                Program program = new Program();
                program.Maincik();
                Environment.Exit(0);
            }

            if (ortakErişim.OrtakListe.Erzak == 0)
            {
                vakaCs.VakaAyrıştırıcı("Hırsızlık");
                return;
            }

            rastgele = random.Next(1, 1111);

            if (rastgele <= 4){vakaCs.VakaAyrıştırıcı("1"); }
            else if (rastgele <= 16) { vakaCs.VakaAyrıştırıcı("2"); }
            else if (rastgele <= 24) { vakaCs.VakaAyrıştırıcı("3"); }
            else if (rastgele <= 44) { vakaCs.VakaAyrıştırıcı("4"); }
            else if (rastgele <= 88 && ortakErişim.OrtakListe.Olay.Contains("Gariban")) { vakaCs.VakaAyrıştırıcı("5"); }
        }
        static void TehlikeliArazi()
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Random random = new Random();
            Vakalar vakaCs = new Vakalar();
            int rastgele = random.Next(1, 11);
            vakaCs.VakaAyrıştırıcı("TehlikeliArazi", rastgele);
        }

        static void KaydetVeÇık()
        {
            Kayıt kayıtCs = new Kayıt();
            kayıtCs.KayıtDosyası("kaydet");
        }



        public int KonumGöster(string xy)
        {
            if (xy == "x")
            {
                return oyuncuKonumX;
            }
            else if (xy == "y")
            {
                return oyuncuKonumY;
            }
            else { Console.WriteLine("Konum kaydedilirken bir sıkıntı meydana gelebilir."); return oyuncuKonumX; }
        }

        public void KonumIşınlan(string konum, int değer)
        {
            if (konum == "x")
            {
                oyuncuKonumX = değer;
            }
            else
            {
                oyuncuKonumY = değer;
            }
        }
    }
}
