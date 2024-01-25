using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kervan
{
    internal class Vakalar
    {
        static void CiddiliYaz(string metin, int minDeğer = 15, int maxDeğer = 45)
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

        public void VakaAyrıştırıcı(string girdi, int sayıGirdisi1 = 0)
        {
            Vaka( girdi, sayıGirdisi1);
        }


        private void Vaka(string olay, int sayıGirdisi1 = 0)
        {

            if (olay == "Son")
            {
                CiddiliYaz("Açlık hissini artık yatıştıracak ekmek bulmakta zorlanıyorsun.");
                CiddiliYaz("Kutlu olduğunu düşündüğün yolda, beş parasız kaldın.");
                CiddiliYaz("Baba evine, ana ocağına dönmek istiyorsun");
                CiddiliYaz("Ama ne yol gösterenin var, ne yemeğin, ne gücün.");
                CiddiliYaz("\n\n\n", 500, 600);
                CiddiliYaz("Oyunu Kaybettin!");
                Program program = new Program();
                program.Maincik();
            }

            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Random random = new Random();
            int rastgele;

            CiddiliYaz("VAKA\n\n", 35, 115);
            Thread.Sleep(500);
            

            //CiddiliYaz($"Vaka kodu: {olay}, numarası: {sayıGirdisi1}");

            if (olay == "TehlikeliArazi")
            {
                if (sayıGirdisi1 == 5)
                {
                    CiddiliYaz("Bir harabelikten geçiyorsunuz.");
                    CiddiliYaz("Harabelikte bazı evlerin içi çiçek açmış.");
                    if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma") || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz("Korumaların harabeyi keşfedebileceklerini söylüyorlar.");
                        CiddiliYaz("Göndermek istiyor musun? (Göndermek için 1 gir, göndermemek için 0) ->");
                        while (true)
                        {
                            string girdi = Console.ReadLine();
                            if (girdi == "1")
                            {
                                CiddiliYaz("Korumaların ve bir meraklı eleman, harabelerde etrafı araştırmaya gitti.");
                                rastgele = random.Next(1, 10);
                                if (rastgele == 4)
                                {
                                    CiddiliYaz("Elemanların etrafta dolaşırken, birisi Elmas Yüzük bulmuş.");
                                    CiddiliYaz("Sana teslim etti.");
                                    ortakErişim.OrtakListe.Envanter.Add("Elmas Yüzük");
                                }
                                if (rastgele == 7)
                                {
                                    CiddiliYaz("Askerlerin etrafta kimsenin olmadığını beyan ettiler.");
                                    CiddiliYaz("Meraklı elemanın ise iki çömlek bulmuş ve onları getirdi.");
                                    ortakErişim.OrtakListe.Envanter.Add("Çömlek");
                                    ortakErişim.OrtakListe.Envanter.Add("Çömlek");
                                }
                                break;
                            }
                            else if (girdi == "2")
                            {
                                CiddiliYaz("Girmeme kararı alıyorsunuz.");
                                break;
                            }
                            else
                            {
                                CiddiliYaz("Lütfen 1 veya 0 yazınız.");
                            }
                        }
                    }
                    else
                    {
                        CiddiliYaz("Hiçkimse burada daha fazla kalmak istemiyor.");
                        CiddiliYaz("Herkesin içerisine bir huzursuzluk çökmüş durumda.");
                    }
                }
                else if (sayıGirdisi1 == 6)
                {
                    CiddiliYaz("Bir mağaranın yakınından geçerken uzaklardan bir kükreme duydunuz.");
                    CiddiliYaz("Kervana doğru koşan sinirli bir AYI var.");
                    if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma") || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz("Korumalarınız öne atıldı ve ayıyla mücadele etti.");
                        if (ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                        {
                            CiddiliYaz("Haşin koruman sayesinde ayıyı alt ettiniz.");
                            CiddiliYaz("Kimse yaralanmadı.");
                            CiddiliYaz("Ayrıca ayının etini doğradınız ve derisini yüzdünüz.");
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Et");
                            ortakErişim.OrtakListe.Envanter.Add("Et");
                            CiddiliYaz("Elde ettiniz: 3 Deri & 2 Et");
                        }
                        else
                        {
                            CiddiliYaz("Ayıyla mücadele eden koruman ağır yaralandı ama ayıyı korkutmayı başardı.");
                            CiddiliYaz("Ayı arkasını dönmüş topallayarak kaçarken siz de hızlıca yer değiştirdiniz.");
                            CiddiliYaz("Ancak korumanız gün batarken kanamadan dolayı vefat etti.");
                        }
                    }
                    else
                    {
                        CiddiliYaz("Ayı ortalığı kırdı geçirdi.");
                        CiddiliYaz("Bir korumaya da sahip olmadığınızdan karşı koyamadınız.");
                        CiddiliYaz("Çokça eşya ve birkaç elemanın telef oldu.");
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Grup.Count - 1);
                        CiddiliYaz($"{ortakErişim.OrtakListe.Grup[rastgele]} öldü.");
                        ortakErişim.OrtakListe.Grup.RemoveAt(rastgele);
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                        CiddiliYaz($"{ortakErişim.OrtakListe.Envanter[rastgele]} satılamaz halde.");
                        ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                        CiddiliYaz($"{ortakErişim.OrtakListe.Envanter[rastgele]} satılamaz halde.");
                        ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                    }
                }
                else if (sayıGirdisi1 == 7)
                {
                    CiddiliYaz("Eşkiya gurubu size doğru iki cihetten yaklaşıyor.");
                    if (ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz("Korumalarınız öne çıktı ve geri basmalarını söylediler.");
                        CiddiliYaz("Eşkiyaların öyle bir niyeti yok gibi görünüyor.");
                        CiddiliYaz("Arbede başladı.");
                        CiddiliYaz("...", 300, 400);
                        CiddiliYaz("Haşin koruma'nız savaşırken öldü.");
                        ortakErişim.OrtakListe.Grup.Remove("Haşin Koruma");
                        CiddiliYaz("Ama eşkiyalardan korunmuş oldunuz ve eşkiyanın tekinden Elmas Yüzük çıktı.");
                        ortakErişim.OrtakListe.Envanter.Add("Elmas Yüzük");
                        CiddiliYaz("Kimden çaldı bilmiyordunuz ancak yüzüğü alıp bu lanetli diyarda yürümeye devam ettiniz.");
                    }
                    else if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma"))
                    {
                        CiddiliYaz("Korumanızın başa çıkmayacağı kadar çoktular.");
                        ortakErişim.OrtakListe.Grup.Remove("Basit Koruma");
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Grup.Count - 1);
                        CiddiliYaz($"Koruma ve {ortakErişim.OrtakListe.Grup[rastgele]}, öldürüldüler.");
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                        CiddiliYaz($"{ortakErişim.OrtakListe.Envanter[rastgele]} çalındı.");
                        ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                        CiddiliYaz($"{ortakErişim.OrtakListe.Envanter[rastgele]} çalındı.");
                        ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Para);
                        CiddiliYaz($"Paran {rastgele} kadar çalındı.");
                        ortakErişim.OrtakListe.Para -= rastgele;
                    }else
                    {
                        CiddiliYaz("Karşı koyan herkesi kılıçtan geçirdiler.");
                        CiddiliYaz("Ve üzerine kılıcıyla gelen adamın ayaklarına bakarken sen...");
                        CiddiliYaz("Bu lanetsiz topraklardan neden geçtiğini sorguladın.");
                        CiddiliYaz("Ama nafile. Son pişmanlık fayda vermedi.");
                        CiddiliYaz("Para keseni uzak köşeye fırlatıp aksi yönde koşmaya başladın.");
                        CiddiliYaz("Koşuyor olman eşkiyaların umrunda bile olmadı.");
                        CiddiliYaz("Sadece para kesene yöneldiler.");
                        CiddiliYaz("Koştun, koştun ve durmadan koştun.", 200, 300);
                        CiddiliYaz("Artık ayaklarına kramplar girmeye başladığı için koşamaz hâle geldin.");
                        CiddiliYaz("Medeniyete geri dönmeye çalışıyorsun, ama nereden?");
                        VakaAyrıştırıcı("Son");
                    }
                }
                else if (sayıGirdisi1 == 8)
                {
                    CiddiliYaz("Kurt ulumalarından oldukça ürktünüz.");
                    if (ortakErişim.OrtakListe.Envanter.Contains("Et") || ortakErişim.OrtakListe.Envanter.Contains("Balık"))
                    {
                        CiddiliYaz("Mecburiyetten yola devam ettiniz.");
                        CiddiliYaz("Gece bastırınca sesler çoğaldı.");
                        CiddiliYaz("Ne olduğunu anlayamadan etrafınızda beliren kurtlar üzerinize saldırmaya başladı.");
                        if(ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                        {
                            CiddiliYaz("Korumalarınız mücadele etti ve hızlıca meşaleler yaktılar.");
                            CiddiliYaz("Etlerinize göz diken kurtları uzaklaştırmayı başardılar.");
                            CiddiliYaz("Kurdun birini de öldürdünüz.");
                            CiddiliYaz("Et ve Deri elde ettin.");
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Et");
                        }
                        else if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma"))
                        {
                            CiddiliYaz("Korumanın başa çıkabileceğinden daha fazla kurt var.");
                            CiddiliYaz("Kurtlar size hışımla saldırdılar.");
                            if(ortakErişim.OrtakListe.Envanter.Contains("Aile Yâdigârı Gümüş Kolye"))
                            {
                                CiddiliYaz("Kurt öyle bir hamle yaptı ki öleceksin sandın.");
                                CiddiliYaz("Ölmedin ama Aile Yadigarı Gümüş Kolye'n parçalandı.");
                                ortakErişim.OrtakListe.Envanter.Remove("Aile Yâdigârı Gümüş Kolye");
                            }
                            CiddiliYaz("Mücadeleye yorulan koruman telef oldu.");
                            CiddiliYaz("Kurtlar bir parça et kaçırdılar.");
                            ortakErişim.OrtakListe.Grup.Remove("Basit Koruma");
                            if (ortakErişim.OrtakListe.Envanter.Contains("Et"))
                            {
                                ortakErişim.OrtakListe.Envanter.Remove("Et");
                            }else
                            {
                                ortakErişim.OrtakListe.Envanter.Remove("Balık");
                            }
                        }
                        else
                        {
                            CiddiliYaz("Grubunda koruma olmadığından dolayı karşı koyamadınız.");
                            CiddiliYaz("Kurtlar et-balık ne vardıysa hepsini alıp kaçtılar.");
                            CiddiliYaz("Gündüz sayım yaptınız.");
                            while (ortakErişim.OrtakListe.Envanter.Contains("Et") || ortakErişim.OrtakListe.Envanter.Contains("Balık"))
                            {
                                if (ortakErişim.OrtakListe.Envanter.Contains("Et"))
                                {
                                    ortakErişim.OrtakListe.Envanter.Remove("Et");
                                    CiddiliYaz("1 parça et gitmiş.", 20, 50);
                                }
                                else
                                {
                                    ortakErişim.OrtakListe.Envanter.Remove("Balık");
                                    CiddiliYaz("1 parça balık gitmiş.", 20, 50);
                                }
                            }
                        }
                    }
                    else
                    {
                        CiddiliYaz("Saldırmalarından korktunuz ancak bir saldırı olmadı.");
                    }
                }
                else if (sayıGirdisi1 == 9)
                {
                    CiddiliYaz("Sizi takip eden bir adam fark ettiniz.");
                    if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma") || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz("Sürekli uzaklardan izleniyorsunuz.");
                        CiddiliYaz("Korumalarınız gece ayakta kaldı.");
                    }
                    else
                    {
                        CiddiliYaz("Gece olduğunda uyumamak üzere bir elemanını görevlendirdin.");
                        CiddiliYaz("Sabah erkenden uyandın ve baktın ki elemanın da uyuyor.");
                        if (ortakErişim.OrtakListe.Envanter.Contains("Aile Yâdigârı Gümüş Kolye"))
                        {
                            CiddiliYaz("Paranı kontrol ettin, yerinde ancak sinirle fark ettin ki");
                            CiddiliYaz("Aile Yâdigârı Gümüş Kolye'n çalınmış.");
                            ortakErişim.OrtakListe.Envanter.Remove("Aile Yâdigârı Gümüş Kolye");
                        }
                        else
                        {
                            rastgele = random.Next(1, ortakErişim.OrtakListe.Para);
                            CiddiliYaz($"Paranı kontrol ettin, {rastgele} kadar paran çalınmış.");
                            ortakErişim.OrtakListe.Para -= rastgele;
                        }
                    }
                }
                else if (sayıGirdisi1 == 10)
                {
                    CiddiliYaz("Bir elemanın kendini kötü hissediyordu.");
                    if(ortakErişim.OrtakListe.Envanter.Contains("Çömlek"))
                    {
                        CiddiliYaz("İlginç bir şekilde bir çömlek kırıldı.");
                        ortakErişim.OrtakListe.Envanter.Remove("Çömlek");
                    }else
                    {
                        CiddiliYaz("İyileşmesini umuyorsun.");
                    }
                }else
                {
                    CiddiliYaz("Uğuldayan ve çınlayan mekanlardan geçiyorsunuz.", 20, 30);
                    CiddiliYaz("Ekibinizdekiler bu bölgede ilerlemekten rahatsız.", 20, 30);
                    CiddiliYaz("Geri dönmek istiyorlar.", 20, 30);

                }
            }


            if (olay == "Hırsızlık")
            {
                if (ortakErişim.OrtakListe.Grup.Count <= 1)
                {
                    CiddiliYaz("Hırsızlık");
                    CiddiliYaz("Yanında son kalan kişi de seni tehdit etti.");
                    CiddiliYaz("Bulduğu kesici alet karşısında yapabileceklerin sınırlıydı.");
                    CiddiliYaz("Günlerdir aç susuz dolaştırdığın için sana sayıp sövdü.");
                    if (ortakErişim.OrtakListe.Envanter.Contains("Aile Yâdigârı Gümüş Kolye"))
                    {
                        CiddiliYaz("Aile Yâdigârı Gümüş Kolye'n gasp edildi.");
                    }
                    CiddiliYaz("Beş paran yok.");
                    if (ortakErişim.OrtakListe.Envanter.Count > 3)
                    {
                        CiddiliYaz("Eşyalarını taşıyacak, kimse kalmadı.");
                    }
                    else
                    {
                        CiddiliYaz("Zaten doğru düzgün eşyân da kalmadı.");
                    }
                    CiddiliYaz("Yolda gördüğün garibanlardan farkın kalmadı.");
                    VakaAyrıştırıcı("Son");
                }
                rastgele = random.Next(1,15);
                if (rastgele <3)
                {
                    rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                    int rastgele2 = random.Next(0, ortakErişim.OrtakListe.Grup.Count - 1);
                    CiddiliYaz("Hırsızlık");
                    CiddiliYaz("Elemanlarından biri gece bir eşyanı çalarak kaçmış.");
                    CiddiliYaz($"Çalınan eşyân: {ortakErişim.OrtakListe.Envanter[rastgele]}.");
                    CiddiliYaz($"Çalan: {ortakErişim.OrtakListe.Grup[rastgele2]}.");
                    ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                    ortakErişim.OrtakListe.Grup.RemoveAt(rastgele2);
                }
                else if (rastgele < 6)
                {
                    rastgele = random.Next(10, 25);
                    CiddiliYaz("Hırsızlık");
                    CiddiliYaz("Paranı bulamıyorsun ancak suçlayabileceğin de kimse yok.");
                    CiddiliYaz("Kervandaki elemanlar sana karşı olan güvenlerini kaybettiler.");
                    ortakErişim.OrtakListe.Para -= rastgele;
                    CiddiliYaz($"{rastgele} paran artık gitti.");
                }
                else
                {
                    CiddiliYaz("Yoldaşların erzakların bitmesinden rahatsız olduğunu dillendiriyor.");
                }
            }

            if (olay == "kumarÇıkış")
            {
                if(sayıGirdisi1 > 300)
                {
                    CiddiliYaz("\n\nGece evine yüklü miktarda kumar parasıyla dönerken ");
                    CiddiliYaz("Ansızın ensene inen acı verici bir sopayla bayıldın.");
                    rastgele = random.Next(1, 4);
                    switch (rastgele)
                    {
                        case 1:
                            CiddiliYaz("Kendine geldiğinde çoktan sabah olmuştu.");
                            CiddiliYaz("Ve üzerinde zırnık para yoktu.");
                            break;
                        case 2:
                            CiddiliYaz("Yüzüne şapırdayan su damlacıklarıyla ayılmaya başladın.");
                            CiddiliYaz("Kervanındaki biri senin neden bu kadar uzun süre gelmediğine bakmış.");
                            CiddiliYaz("Üzerini kontrol ettiğindeyse kazandığın paraların yanında olmadığını fark ettin.");
                            break;
                        case 3:
                            CiddiliYaz("Anlık bir baygınlıktan, üzerini yoklayan elleri hissettin.");
                            CiddiliYaz("Karşı koymaya çalışırken darbe aldın.");
                            CiddiliYaz("Kayan ve sisli görüntüyle gaspçıların arkasından baktın.");
                            CiddiliYaz("Elinden hiçbir şey gelmedi.");
                            CiddiliYaz("Gece yarısı, sokaklarda tedirginlikle süründün.");
                            CiddiliYaz("Sağsağlim eve vardın ancak bir doktor görmen gerek.");
                            ortakErişim.OrtakListe.Olay.Add("Doktor");
                            break;
                        default:
                            Console.WriteLine("#Hata: Vakalar.Vaka()");
                            break;
                    }
                    CiddiliYaz("");
                }else if (sayıGirdisi1 > 100)
                {
                    rastgele = random.Next(1, 5) * 10;
                    CiddiliYaz("Arkadan bir koşma sesi duydun.");
                    CiddiliYaz("Gelen adam üzerine saldırdı.");
                    CiddiliYaz("Adamı bir yana sen bir yana düştün.");
                    CiddiliYaz("Sen ayağa kalktın koşmaya başladın ki adam para keseni tuttu.");
                    CiddiliYaz("Keselerini birbirine bağlayan ip çekiştirmenizde koptu.");
                    CiddiliYaz("Koşturarak barındığın hana koştun.");
                    CiddiliYaz($"Kesenin içinde {rastgele} para vardı.");
                    ortakErişim.OrtakListe.Para = sayıGirdisi1 - rastgele;
                }
            }
            if (olay == "1" || olay == "3")
            {
                CiddiliYaz("İki üç gün önce başlayan hapşurma ve tıksırmaların şiddetlendi.");
                CiddiliYaz("Artık bir doktor görmen gerektiğine ikna olmuş vaziyettesin.");
                ortakErişim.OrtakListe.Olay.Add("Doktor");
            }
            else if (olay == "2")
            {
                rastgele = random.Next(1,9);
                if (rastgele == 1) { CiddiliYaz("Hapşurmaya ve tıksırmaya başladın ama doktor görmene gerek yok gibi."); }
                if (rastgele == 2) { CiddiliYaz("O kadar çok hapşurdun ki başın döndü."); }
                if (rastgele == 3) { CiddiliYaz("Tıksıra tıksıra bir hâl oldun ama doktor görmene gerek yok gibi."); }
                if (rastgele == 4) { CiddiliYaz("Hayatında ilk defa o kadar büyük bir böcek gördün. HEM DE SENİ ISIRIRKEN"); }
                if (rastgele == 5) { CiddiliYaz("Kervandaki bir adam çok öksürmeye başladı."); }
                if (rastgele == 6) { CiddiliYaz("Etrafta salgın var söylentisini çok sık duymaya başladın."); }
                if (rastgele == 7) { CiddiliYaz("Gez göz arpacık"); }
                if (rastgele == 8) { CiddiliYaz("Burnun salya sümük akıyor."); }
            }
            else if (olay == "4")
            {
                CiddiliYaz("Yolda bir garip, aç olduğunu ve bir erzak istediğini söylüyor.");
                CiddiliYaz("Vereceksen 1, yoksa 0 gir -> ");
                while (true)
                {
                    string cevap = Console.ReadLine();
                    if (cevap == "1")
                    {
                        CiddiliYaz("Garibana bir parça yemek verdin.");
                        ortakErişim.OrtakListe.Erzak--;
                        ortakErişim.OrtakListe.Olay.Add("Gariban");
                        break;
                    }else if (cevap == "0")
                    {
                        CiddiliYaz("Garibanı öylece bıraktın,");
                        CiddiliYaz("Aç...", 100, 400);
                        CiddiliYaz("Susuz...", 100, 400);
                        CiddiliYaz("Umursamazca...", 100, 300);
                        break;
                    }
                    else
                    {
                        CiddiliYaz("Lütfen 1 veya 0 gir.");
                    }
                }
            }
            else if (olay == "5" && ortakErişim.OrtakListe.Olay.Contains("Gariban"))
            {
                CiddiliYaz("Yolda giderken bir kervanla karşılaştınız.");
                CiddiliYaz("Kervanlarda gidenler arasında bir arbede yaşandı.");
                CiddiliYaz("Olayı engellemeye giderken birinin çoktan olaya el attığını gördün.");
                CiddiliYaz("Ahaliyi sakinleştiren adamla göz göze geldin.");
                CiddiliYaz("Adamın yüzünde canayakın bir gülümseme belirdi.");
                CiddiliYaz("Adam yaklaştı ve konuşmaya başladınız.");
                CiddiliYaz("Adam falanca yerden falanca kişinin soyundanmış.");
                CiddiliYaz("Kendine olan güveninden dolayı gelen tehditi görememiş.");
                CiddiliYaz("Yolda aç, susuz garibâne dolaşmış.");
                CiddiliYaz("Tam vazgeçtiği anda sen adamla ekmeğini paylaşmışsın.");
                CiddiliYaz("Adamı birden hatırladın.");
                CiddiliYaz("Uzunca sohbet ettiniz.");
                CiddiliYaz("Adam soyunun da etkisiyle kısa sürede zenginliğe erişmiş.");
                CiddiliYaz("Sana da teşekkür mahiyetinde bir Elmas yüzük verdi.");
                ortakErişim.OrtakListe.Envanter.Add("Elmas Yüzük");
                ortakErişim.OrtakListe.Olay.Remove("Gariban");
                ortakErişim.OrtakListe.Olay.Add("GaribandıArtıkZengin");
            }
            else if (olay == "5" && ortakErişim.OrtakListe.Olay.Contains("GaribandıArtıkZengin"))
            {
                CiddiliYaz("Kervanla karşılaştınız.");
                CiddiliYaz("Zamanında sana Elmas Yüzük hediye eden adam bu sefer de iki çuval baharat verdi.");
                ortakErişim.OrtakListe.Envanter.Add("Baharat");
                ortakErişim.OrtakListe.Envanter.Add("Baharat");
                ortakErişim.OrtakListe.Olay.Remove("GaribandıArtıkZengin");
                ortakErişim.OrtakListe.Olay.Add("Zengin");
            }
        }

    }
}
