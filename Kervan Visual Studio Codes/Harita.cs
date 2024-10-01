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
        #region HARİTA
        // Verilen harita

        string[] harita = {
            "#####################",
            "####..8.........#####",
            "###......#.........##",
            "##?..7..??....6....##",
            "##??...??.........###",
            "###???###.5.....#####",
            "####???###.......####",
            "#####??#####......###",
            "###3...##.....#..4###",
            "##.....?..1.......###",
            "#?.................##",
            "########??.....2.####",
            "#####################"
        };
        /*
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
        */
        #endregion

        #region Tam olarak 2 adet değişken
        // Haritayı liste olarak temsil etmek için
        // (Listedeki oyuncunun konumu P ile değiştirilip print edilir.)
        List<List<char>> haritaListesi = new List<List<char>>();

        //Bunun ne olduğunu hatırlamıyorum
        bool iflasdenemesi = false;
        #endregion

        public void oyuncuHareketEtHaritaYazdır()
        {
            oyuncuHareket();
            oyunBekasıKontrol();
            haritaYazdır();
        }

        public void oyuncuHareket()
        {
            #region Gerekli Referanslar
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Eşyalar EşyalarCs = new Eşyalar();
            Şehir ŞehirCs = new Şehir();
            #endregion

            ŞehirCs.Erzak("Kontrol");
            Console.WriteLine(Language.GetText("Harita.Menu.1"));
            Console.WriteLine(Language.GetText("Harita.Menu.2"));
            Console.WriteLine(Language.GetText("Harita.Menu.3"));
            Console.Write(Language.GetText("Harita.Menu.4"));
            string yon = Console.ReadLine();

            #region Haritada Dolaşma
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
                    Thread.Sleep(500);
                    haritaYazdır();
                    oyuncuHareket();
                    Thread.Sleep(500);
                    break;
                case "3":
                    Console.WriteLine(Language.GetText("Harita.Menu.Case3.1") + $" {ortakErişim.OrtakListe.Para}");
                    Console.WriteLine(Language.GetText("Harita.Menu.Case3.2") + $" {ortakErişim.OrtakListe.Erzak / ortakErişim.OrtakListe.Grup.Count}");
                    Thread.Sleep( 1000 );
                    ŞehirCs.GrupYazdır();
                    Thread.Sleep( 1000 );
                    ŞehirCs.EnvanterYazdır();
                    Thread.Sleep(1000);
                    break;
                case "4":
                    İpucu();
                    break;
                case "5":
                    KaydetVeÇık();
                    break;
                case "konum":
                    Console.WriteLine($"Konumun: {ortakErişim.OrtakListe.oyuncuGlobalKonumX}, {ortakErişim.OrtakListe.oyuncuGlobalKonumY}");
                    oyuncuHareket();
                    break;
                case "şehir":
                    EşyalarCs.Print("Şehirler");
                    Thread.Sleep(500);
                    break;
                case "iflas":
                    #region İflas Konuşması
                    if(iflasdenemesi) { break; }
                    CiddiliYaz("O kadar acınasısın ki!");
                    CiddiliYaz("O kadar korkaksın ki!");
                    CiddiliYaz("Dayanamadan terk ediyorsun hemen.");
                    CiddiliYaz("Seninle kim bir yola çıksa yarıda kalır.");
                    CiddiliYaz("Hani diyarın en zengin tüccarı olacaktık?", 65, 120);
                    CiddiliYaz("Hani onlarca kervanımız olacaktı?", 90, 130);
                    Console.WriteLine();
                    CiddiliYaz("Vazgeçmişliğinle öğrendin bu hayat zor.");
                    CiddiliYaz("Devam eden herkes mücadeleyi sürdürüyor.");
                    CiddiliYaz("Sense korkaklık ettin. Bu kadar dedin.");
                    CiddiliYaz("Neyime yaracak ki bu köhne diyar dedin.");
                    CiddiliYaz("Adın çıkmadı merak etme ama korkaksın.");
                    CiddiliYaz("Geçmişe baktın mı hep hüzne bakacaksın.", 90, 130);
                    Console.WriteLine();
                    CiddiliYaz("Son bir şansın var, 'vazgeç'ecek misin? Yoksa 'terk' mi edeceksin?");
                    bool iflasDöngüsü = true;
                    do{ Console.Write(" -> ");
                        string cevap = Console.ReadLine();
                        if (cevap == "Vazgeç") { CiddiliYaz("Helal olsun, vazgeçmeyeceğini biliyordum."); iflasDöngüsü = false; }
                        else if (cevap == "Terk et") 
                        { 
                            CiddiliYaz("Tamam\n", 150, 160); 
                            Thread.Sleep(2000); 
                            CiddiliYaz("KORKAK", 300, 320); 
                            Thread.Sleep(200);
                            Thread.Sleep(2000);
                            KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                            kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.iflas.luz"); //Keyfi iflas mağlubiyeti
                            Environment.Exit(0);
                        }
                        else { CiddiliYaz("Anlayabilmem için 'Vazgeç' veya 'Terk et' yaz.", 15, 35); }
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
                    Console.WriteLine(Language.GetText("All.GeçersizYönlendirme"));
                    Thread.Sleep(500);
                    oyuncuHareket();
                    break;
            }
            #endregion
        }

        public void oyuncuKonumDeğişikliği(int konumX, int konumY)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Şehir ŞehirCs = new Şehir();

            //Konumdaki blok haritada ilerlediğimiz yöndeki bloğu öğrenir.
            string konumdakiBlok = string.Concat(haritaListesi[konumY + ortakErişim.OrtakListe.oyuncuGlobalKonumY][konumX + ortakErişim.OrtakListe.oyuncuGlobalKonumX]);

            //Haritada ilerlediğimiz konumdaki bloğa göre işlevler
            switch (konumdakiBlok)
            {
                case "#":
                    Console.WriteLine("\n\nGitmek istenen konumda engel var. Lütfen tekrar deneyin.\n\n");
                    haritaYazdır();
                    oyuncuHareket();
                    break;
                case ".":
                    ortakErişim.OrtakListe.oyuncuGlobalKonumX = konumX + ortakErişim.OrtakListe.oyuncuGlobalKonumX;
                    ortakErişim.OrtakListe.oyuncuGlobalKonumY = konumY + ortakErişim.OrtakListe.oyuncuGlobalKonumY;
                    OlayKontrolMakenizması();
                    ŞehirCs.Erzak("Arttır", -1);
                    break;
                case "?":
                    ortakErişim.OrtakListe.oyuncuGlobalKonumX = konumX + ortakErişim.OrtakListe.oyuncuGlobalKonumX;
                    ortakErişim.OrtakListe.oyuncuGlobalKonumY = konumY + ortakErişim.OrtakListe.oyuncuGlobalKonumY;
                    TehlikeliArazi();
                    ŞehirCs.Erzak("Arttır", -1);
                    break;
                default:

                    #region ŞEHİRLER veya KÖYLER'E GİRİŞ
                    if (int.TryParse(konumdakiBlok, out int sayı))
                    {
                        if (sayı == 2 || sayı == 5 || sayı == 8)
                        { ŞehirCs.Şehrinİçinde(sayı); }
                        else { ŞehirCs.Köyünİçinde(sayı); }
                    }
                    #endregion
                    else
                    {
                        Console.WriteLine("İlerleyeceğiniz yön saptanamadı. Lütfen o yöne gitmeyiniz.");
                        // Giriş geçerli bir tamsayı değilse, uygun bir hata mesajı verebilir veya programı sonlandırabilirsiniz.
                    }
                    break;
            }
        }


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
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            // Haritayı kopyala
            List<List<char>> haritaListeKopyası = KopyalaHaritayi(haritaListesi);

            // Kopyadaki oyuncunun konumunu 'P' ile değiştir
            haritaListeKopyası[ortakErişim.OrtakListe.oyuncuGlobalKonumY][ortakErişim.OrtakListe.oyuncuGlobalKonumX] = 'P';

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

            #region Hastalıktan ölme
            if (ortakErişim.OrtakListe.Olay.Contains("Doktor") && rastgele == 1)
            {
                CiddiliYaz("\n" + Language.GetText("Harita.Olay.Doktor.Ölüm.1"));
                CiddiliYaz(Language.GetText("Harita.Olay.Doktor.Ölüm.2"));
                CiddiliYaz(Language.GetText("Harita.Olay.Doktor.Ölüm.3"));
                CiddiliYaz(Language.GetText("Harita.Olay.Doktor.Ölüm.4"));
                CiddiliYaz(Language.GetText("Harita.Olay.Doktor.Ölüm.5"));
                CiddiliYaz("\n\n\n" + Language.GetText("Harita.Olay.Doktor.Ölüm.6") 
                                + "\n\n" + Language.GetText("Harita.Olay.Doktor.Ölüm.7"));
                Thread.Sleep(4444);
                KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.hasta.luz"); //Hastalıktan ölme mağlubiyeti
                Environment.Exit(0);
            }
            #endregion

            #region Erzak bitince dönen olaylar
            if (ortakErişim.OrtakListe.Erzak == 0)
            {
                vakaCs.VakaAyrıştırıcı("Hırsızlık");
                return;
            }
            #endregion

            #region Rastgele olaylar
            rastgele = random.Next(1, 1111);

            if (rastgele <= 4){vakaCs.VakaAyrıştırıcı("1"); }
            else if (rastgele <= 16) { vakaCs.VakaAyrıştırıcı("2"); }
            else if (rastgele <= 24) { vakaCs.VakaAyrıştırıcı("3"); }
            else if (rastgele <= 44) { vakaCs.VakaAyrıştırıcı("4"); }
            else if (rastgele <= 88 && ortakErişim.OrtakListe.Olay.Contains("Gariban")) { vakaCs.VakaAyrıştırıcı("5"); }
            #endregion
        }


        public void oyunBekasıKontrol(bool kumarMı = false)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;

            //Kumarda tüm parayı harcayınca gelen pişmanlık hissi
            if (kumarMı && ortakErişim.OrtakListe.Para < 5 && ortakErişim.OrtakListe.Envanter.Count <= 1) //KUMARDA PARA BİTİRME
            {
                CiddiliYaz(Language.GetText("Harita.Bitiş.Lose.Kumar.1"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Lose.Kumar.2"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Lose.Kumar.3"));
                CiddiliYaz("\n\n\n", 200, 500);
                CiddiliYaz(Language.GetText("Harita.Bitiş.Lose.Kumar.4"));
                CiddiliYaz("\n\n" + Language.GetText("Harita.Bitiş.Lose.Kumar.5"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Lose.Kumar.6"));
                Thread.Sleep(4444);
                KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.kumar.luz"); //Kumarbaz mağlubiyeti
                Environment.Exit(0);
            }
            //Para bitinceki Mağlubiyet
            if (ortakErişim.OrtakListe.Para < 5 && ortakErişim.OrtakListe.Envanter.Count <= 1)
            {
                Vakalar vakaCs = new Vakalar();
                CiddiliYaz(Language.GetText("Harita.Bitiş.Lose.1"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Lose.2"));
                vakaCs.VakaAyrıştırıcı("Son");
                Thread.Sleep(4444);
                KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.tacir.luz"); //Tüccar Mağlubiyeti
                Environment.Exit(0);
            }

            //Kumarbaz Zaferi
            if (ortakErişim.OrtakListe.Para >= 1000 
                && ortakErişim.OrtakListe.Olay.Contains("Kumar Parası")
                && !ortakErişim.OrtakListe.Olay.Contains("Tüccariyet"))
            {
                CiddiliYaz(Language.GetText("Harita.Bitiş.Kumarbaz.1"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Kumarbaz.2"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Kumarbaz.3"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Kumarbaz.4"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Kumarbaz.5"));
                CiddiliYaz("\n\n\n", 200, 500);
                CiddiliYaz(Language.GetText("Harita.Bitiş.Kumarbaz.6"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Kumarbaz.7"));
                Thread.Sleep(4444);
                KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.kb.win"); //Kumarbaz zaferi
                Environment.Exit(0);
            }
            //Kumarbaz Tüccar Zaferi
            else if (ortakErişim.OrtakListe.Para >= 1000 
                && ortakErişim.OrtakListe.Olay.Contains("Kumar Parası")
                && ortakErişim.OrtakListe.Olay.Contains("Tüccariyet"))
            {
                Vakalar vakaCs = new Vakalar();
                Şehir ŞehirCs = new Şehir();
                CiddiliYaz(Language.GetText("Harita.Bitiş.KumarbazTüccar.1"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.KumarbazTüccar.2"));
                Console.WriteLine(Language.GetText("All.Para") + $" {ortakErişim.OrtakListe.Para}");
                Console.WriteLine(Language.GetText("All.Erzak") + $" {ortakErişim.OrtakListe.Erzak / ortakErişim.OrtakListe.Grup.Count}");
                Thread.Sleep(1000);
                ŞehirCs.GrupYazdır();
                Thread.Sleep(1000);
                ŞehirCs.EnvanterYazdır();
                Thread.Sleep(2000);
                CiddiliYaz(Language.GetText("Harita.Bitiş.KumarbazTüccar.3"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.KumarbazTüccar.4"));
                CiddiliYaz("\n\n\n", 200, 500);
                CiddiliYaz(Language.GetText("Harita.Bitiş.KumarbazTüccar.5"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.KumarbazTüccar.6"));
                Thread.Sleep(4444);
                KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.kbtc.win"); //Kumarbaz Tüccar Zaferi
                Environment.Exit(0);

            }
            //Tüccar Zaferi
            else if (ortakErişim.OrtakListe.Para >= 1000
                && !ortakErişim.OrtakListe.Olay.Contains("Kumar Parası")
                && ortakErişim.OrtakListe.Olay.Contains("Tüccariyet")) //
            {
                Vakalar vakaCs = new Vakalar();
                Şehir ŞehirCs = new Şehir();
                CiddiliYaz(Language.GetText("Harita.Bitiş.Tüccar.1"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Tüccar.2"));
                Console.WriteLine(Language.GetText("All.Para") + $" {ortakErişim.OrtakListe.Para}");
                Console.WriteLine(Language.GetText("All.Erzak") + $" {ortakErişim.OrtakListe.Erzak / ortakErişim.OrtakListe.Grup.Count} günlük erzağın var.");
                Thread.Sleep(1000);
                ŞehirCs.GrupYazdır();
                Thread.Sleep(1000);
                ŞehirCs.EnvanterYazdır();
                Thread.Sleep(2000);
                CiddiliYaz(Language.GetText("Harita.Bitiş.Tüccar.3"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Tüccar.4"));
                CiddiliYaz("\n\n\n", 200, 500);
                CiddiliYaz(Language.GetText("Harita.Bitiş.Tüccar.5"));
                CiddiliYaz(Language.GetText("Harita.Bitiş.Tüccar.6"));
                Thread.Sleep(4444);
                KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.tc.win"); //Tüccar zaferi
                Environment.Exit(0);
            }
            //Hilebaz zaferi
            else if (ortakErişim.OrtakListe.Para >= 1000
                && !ortakErişim.OrtakListe.Olay.Contains("Kumar Parası")
                && !ortakErişim.OrtakListe.Olay.Contains("Tüccariyet"))
            {
                for(int i = 1; i < 8; i++)
                {
                    CiddiliYaz(Language.GetText("Harita.Bitiş.Hilebaz." + i));
                }
                Thread.Sleep(4444);
                KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.hile.win"); //Hilebaz zaferi
                Environment.Exit(0);
            }
        }

        static void TehlikeliArazi()
        {
            //Harita üzerinde Tehlikeli Arazi'den "?" üzerinden geçerken çalışır
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
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            if (xy == "x")
            {
                return ortakErişim.OrtakListe.oyuncuGlobalKonumX;
            }
            else if (xy == "y")
            {
                return ortakErişim.OrtakListe.oyuncuGlobalKonumY;
            }
            else { Console.WriteLine("Konum kaydedilirken bir sıkıntı meydana gelebilir."); return ortakErişim.OrtakListe.oyuncuGlobalKonumX; }
        }

        public void KonumIşınlan(string konum, int değer)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            if (konum == "x")
            {
                ortakErişim.OrtakListe.oyuncuGlobalKonumX = değer;
            }
            else
            {
                ortakErişim.OrtakListe.oyuncuGlobalKonumY = değer;
            }
        }

        public void HaritaBilgilendirme(string bildiri)
        {
            if (bildiri == "Harita")
            {
                Console.WriteLine(Language.GetText("Harita.Bilgilendirme.1"));
                Thread.Sleep(444);
                Console.WriteLine(Language.GetText("Harita.Bilgilendirme.2"));
                Thread.Sleep(444);
                Console.WriteLine(Language.GetText("Harita.Bilgilendirme.3"));
                Thread.Sleep(444);
                Console.WriteLine(Language.GetText("Harita.Bilgilendirme.4"));
                Thread.Sleep(444);
                Console.WriteLine(Language.GetText("Harita.Bilgilendirme.5"));
                Console.WriteLine("\n");
            }
            else if (bildiri == "Yerleşke")
            {
                Eşyalar EşyalarCs = new Eşyalar();
                EşyalarCs.Print("Şehirler");
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

        private void İpucu()
        {
            Random random = new Random();
            int rastgele = random.Next(1, 44); //44. şıkkı göstermeyeceğini biliyorum.
            Console.Write("\n\n" + rastgele + Language.GetText("Harita.İpucu") + " ");
            Console.Write(Language.GetText($"Harita.İpucu.{rastgele}"));
            
            #region İpucunun havalı şekilde geçilmesini sağlayan kod dizini
            Console.WriteLine();
            Thread.Sleep(2416);
            for (int i = 0; i < 180; i += 0)
            {
                Console.Write("-");
                Thread.Sleep(200 - i);
                i += (int)((200 - i) * 0.1);
            }
            Console.WriteLine();
            #endregion
        }
    }
}
