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

        public void oyunBekasıKontrol(bool kumarMı = false)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;

            if (kumarMı && ortakErişim.OrtakListe.Para < 5 && ortakErişim.OrtakListe.Envanter.Count <= 1) //KUMARDA PARA BİTİRME
            {
                Yazİflas("Kumarbazlığın peşinde koştururken bütün paranı harcadın.");
                Yazİflas("Tüccar olacağım diyerek çıktığın köye bütün parasını kumarbaz halde yemiş biri olarak döndün.");
                Yazİflas("Köyde ailenizin nâmına bir kara leke olarak yapıştın.");
                Yazİflas("\n\n\n", 200, 500);
                Yazİflas("Kumarda bütün paranı kaybettin!");
                Yazİflas("\n\nOyun Bitti!");
                Yazİflas("Kumar Mağlubiyeti!");
                Thread.Sleep(4444);
                Environment.Exit(0);
            }

            if (ortakErişim.OrtakListe.Para < 5 && ortakErişim.OrtakListe.Envanter.Count <= 1)
            {
                Vakalar vakaCs = new Vakalar();
                Yazİflas("Beş paran kalmadı. Eşyan da yok.");
                Yazİflas("Etrafındaki herkes sayıp sövüp gitti.");
                vakaCs.VakaAyrıştırıcı("Son");
            }
            if (ortakErişim.OrtakListe.Para >= 1000 //Full kumarbaz zaferş
                && ortakErişim.OrtakListe.Olay.Contains("Kumar Parası") 
                && !ortakErişim.OrtakListe.Olay.Contains("Tüccariyet"))
            {
                Yazİflas("Tüccar olma niyetiyle çıktığın bu yolda kumarbazın teki oldun.");
                Yazİflas("Ama öyle olacak ki oyunu gene de kazanmayı becerdin!");
                Yazİflas("Paran 1000'i geçti, hem de ticaret yapmadan!");
                Yazİflas("Gerçek bir kumarbazsın.");
                Yazİflas("Oynadığın için teşekkürler.");
                Yazİflas("\n\n\n", 200, 500);
                Yazİflas("Kazandın!");
                Yazİflas("Kumarbaz Zaferi!");
                Thread.Sleep(4444);
                Environment.Exit(0);
            }
            else if (ortakErişim.OrtakListe.Para >= 1000 //Full kumarlı Ticaret zaferi.
                && ortakErişim.OrtakListe.Olay.Contains("Kumar Parası")
                && ortakErişim.OrtakListe.Olay.Contains("Tüccariyet"))
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
                Yazİflas("Gerçek bir tüccarsın ama kumara da bulaşmışsın.");
                Yazİflas("Oynadığın için teşekkürler.");
                Yazİflas("\n\n\n", 200, 500);
                Yazİflas("Kazandın!");
                Yazİflas("Kumarlı Tüccarlık Zaferi!");
                Thread.Sleep(4444);
                Environment.Exit(0);

            }
            else if (ortakErişim.OrtakListe.Para >= 1000 ) //
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
                Yazİflas("Tüccarlık Zaferi!");
                Thread.Sleep(4444);
                Environment.Exit(0);
            }
        }

        public void oyuncuHareket()
        {
            // Oyuncunun yönüne göre konumunu güncelle
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Eşyalar EşyalarCs = new Eşyalar();
            Şehir ŞehirCs = new Şehir();
            ŞehirCs.Erzak("Kontrol");
            Console.Write("(w-Yukarı, s-Aşağı, d-Sağa, a-Sola\n");
            Console.Write("1-Harita bilgilendirmesi, 2-Yerleşkeler (isimleri),\n3-Kendi bilgilerin, 4-İpucu Al, 5-Kaydedip çık, .)\n-> ");
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
                    Thread.Sleep(500);
                    haritaYazdır();
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
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            string konumdakiBlok = string.Concat(haritaListesi[konumY + ortakErişim.OrtakListe.oyuncuGlobalKonumY][konumX + ortakErişim.OrtakListe.oyuncuGlobalKonumX]);

            Şehir ŞehirCs = new Şehir();

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

        private void İpucu()
        {
            Random random = new Random();
            int rastgele = random.Next(1, 44); //44. şıkkı göstermeyeceğini biliyorum.
            Console.Write("\n\n" + rastgele + ".");
            switch (rastgele)
            {
                case 1: Console.Write("İpucu: Köylerden alıp şehirlerde satmak çok daha kârlıdır."); break;
                case 2: Console.Write("İpucu: Erzağınız biterse grubunuzdakiler size düşman kesilebilir."); break;
                case 3: Console.Write("İpucu: Garibe yemek vermek sevaptır."); break;
                case 4: Console.Write("İpucu: Tehlikeli arazide ilerlemek bir şey kaybetmeseniz bile zaman alacaktır."); break;
                case 5: Console.Write("İpucu: Şehirde kumar oynamak sadece bir sayı bulmaca oyunudur."); break;
                case 6: Console.Write("İpucu: Köylerden alamayacağınız elemanları (Koruma & Aşçı) Şehirlerden temin edebilirsiniz."); break;
                case 7: Console.Write("İpucu: Korumalar sizi tehlikeli durumlarda kalmaktan korur."); break;
                case 8: Console.Write("İpucu: Ekibinize Aşçı almak erzak kontrolünü sağlar ve erzağınız daha uzun gider."); break;
                case 9: Console.Write("İpucu: Bu oyunun yapıncısı Mushu'dur."); break;
                case 10: Console.Write("İpucu: Projenizi kaydetip istediğiniz zaman kaldığınız yerden devam edebilirsiniz.\n Ama dikkat edin, kayıt üstüne kayıt almak önceki kaydı silecektir."); break;
                case 11: Console.Write("İpucu: Kervan oyunu aslında bir Final Projesi olarak yapıldı."); break;
                case 12: Console.Write("İpucu: Tehlikeli araziden geçmeyi düşünüyorsanız et-balık almayın. Vahşi hayvanları çekebilir."); break;
                case 13: Console.Write("İpucu: Oyunda en çok kâr getiren eşya Elmas Yüzüktür (ve en nâdir bulunan)."); break;
                case 14: Console.Write("İpucu: Erzağınızın bitmemesi için Şehirlerden veya Köylerden alımda bulunabilirsiniz."); break;
                case 15: Console.Write("İpucu: Erzak bu oyunda önemlidir."); break;
                case 16: Console.Write("İpucu: Oyunda 0 koduna sahip Harabeler diye bir bölge olduğunu biliyor muydun?"); break; //bkn. Eşyalar.Eşya() -> ŞehirlerListesi
                case 17: Console.Write("İpucu: Haşin Koruma pahalı olabilir ama gerçekten de koruyor."); break;
                case 18: Console.Write("İpucu: Koyuncu Köylerinden Et ve Yün alıp en yakın Şehirde satmak oldukça kârlıdır."); break;
                case 19: Console.Write("İpucu: Hangi numara hangi şehri temsil ediyor öğrenmek için 'Yerleşkeler'in kodunu gir."); break;
                case 20: Console.Write("İpucu: 'iflas' yazarak iflas edebilirsin."); break;
                case 21: Console.Write("İpucu: Yün'ü Koyuncu köyünden alıp, Şehirlerde değil ama başka köylerde satmak daha kârlıdır."); break;
                case 22: Console.Write("İpucu: İçki'ye nedense buranın köylüleri daha düşkün, en çok ithal edeniyse 'Kuzey Limen Şehri'."); break;
                case 23: Console.Write("İpucu: 'Merkez Şehir'dekiler biraz içki düşkünü mü ne..."); break;
                case 24: Console.Write("İpucu: 24 güzel sayı."); break;
                case 25: Console.Write("İpucu: 'Madenciler Köyü' tuz ve demiri en ucuza alabileceğin yerdir."); break;
                case 26: Console.Write("İpucu: 'Kuzey Liman Şehri'nde tuza ihtiyaç var."); break;
                case 27: Console.Write("İpucu: 'Kuzey Liman Şehri'nde demire ihtiyaç var."); break;
                case 28: Console.Write("İpucu: Çömlekleri 'Merkez Şehir'den alıp 'Falanca Liman Şehri'nde satmak daha kârlıdır."); break;
                case 29: Console.Write("İpucu: Yağ'ı Kuzey Yerleşkelerden alıp Güney Yerleşkelerde satmak oldukça kârlı."); break;
                case 30: Console.Write("İpucu: Güney'den alıp Kuzey'de satmak İpek için oldukça kâr getiren bir hareket."); break;
                case 31: Console.Write("İpucu: 'Merkez Şehir'dekiler Baharat Düşkünü."); break;
                case 32: Console.Write("İp mi ucu?"); break;
                case 33: Console.Write("İpucu: Midye için en çok para verenler Köylülermiş."); break;
                case 34: Console.Write("İpucu: Midye ve Balığı liman Yerleşkelerden oldukça ucuza bulabilirsin."); break;
                case 35: Console.Write("İpucu: Merkez Şehir'de keten üretimi çokmuş."); break;
                case 36: Console.Write("İpucu: Merkez Şehir'de bal çokmuş."); break;
                case 37: Console.Write("İpucu: Kuzey Liman Şehri'nde bal kıtlığı varmış."); break;
                case 38: Console.Write("İpucu: Elmas Yüzük bulursan Kuzey Liman Şehri'ne git. Süse orada daha çok para harcanıyor."); break;
                case 39: Console.Write("İpucu: Bu oyuna 20'sinde başlanıp 25'inde oynanabilir bir versiyonun ulaşılmıştır."); break;
                case 40: Console.Write("İpucu: Mount and Blade Warband'ta en kârlı dükkan Reyvadin Şehrindeki Kadife Dokuma Atölyesidir."); break; //Bu oyuna da dükkan eklesek olurmuş bak
                case 41: Console.Write("İpucu: 41 kere Maşallah."); break;
                case 42: Console.Write("İpucu: The answer to life, the universe, and everything..."); break; //Göndermemizi de yapalım
                case 43: Console.Write("İpucu: Vedalar hep üzücüdür. Evine bir kervan kurmak için veda ettin. Buna değmesini sağla."); break;
                case 44: Console.Write("İpucu: Bu oyunu görsem yapımcısına 100 üzerinden 100 verirdim."); break;
            }
            Console.WriteLine();
            Thread.Sleep(2416);
            for (int i = 0; i < 180; i += 0)
            {
                Console.Write("-");
                Thread.Sleep(200 - i);
                i += (int)((200 - i) * 0.1);
            }
            Console.WriteLine();
        }
    }
}
