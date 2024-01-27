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
                CiddiliYaz("Mağlubiyet!");
                Program program = new Program();
                program.Maincik();
            }

            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Random random = new Random();
            int rastgele;

            CiddiliYaz("\n\nVAKA\n\n", 35, 115);
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
                    rastgele = random.Next(0, 10);
                    if (rastgele == 6)
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
                    }else
                    {
                        CiddiliYaz("Kaç gündür aç acına dolaştırdığın elemanın grubu terk etti.");
                        CiddiliYaz("Eşyaları taşıyacak kimse kalmadı.");
                    }
                    CiddiliYaz("Yolda gördüğün garibanlardan farkın kalmadı.");
                    VakaAyrıştırıcı("Son");
                }
                if (ortakErişim.OrtakListe.Olay.Contains("Avcı Koruma Bahşiş İsyanı")
                    && ortakErişim.OrtakListe.Grup.Contains("Basit Koruma")
                    || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                {
                    CiddiliYaz("Av yapıp ava çıkan korumaların verdiğin paradan mutlu değillerdi.");
                    CiddiliYaz("Bütün korumalar grubu terk etti.");
                    CiddiliYaz("Giderken yaygara çıkardılar.");
                    CiddiliYaz("Yanlarında bir kaç kişi daha gitti.");
                    ortakErişim.OrtakListe.Grup.Remove("Basit Koruma");
                    ortakErişim.OrtakListe.Grup.Remove("Haşin Koruma");
                    ortakErişim.OrtakListe.Grup.Remove("Aşçı");
                    ortakErişim.OrtakListe.Grup.Remove("Eleman");
                    ortakErişim.OrtakListe.Grup.Remove("Eleman");
                    ortakErişim.OrtakListe.Grup.Remove("Eleman");
                    ortakErişim.OrtakListe.Olay.Remove("Avcı Koruma Bahşiş İsyanı");
                    CiddiliYaz("Grubunda kalanlar:");
                    Şehir ŞehirCs = new Şehir();
                    ŞehirCs.GrupYazdır();
                    Thread.Sleep(2000); 

                    string arananEleman = "Eleman";
                    int elemanSayısı = ortakErişim.OrtakListe.Grup.Count(e => e == arananEleman);
                    int envanterdekilerinSayısı = ortakErişim.OrtakListe.Envanter.Count();
                    if (!(elemanSayısı * 4 > envanterdekilerinSayısı))
                    {
                        CiddiliYaz("Kalan elemanlarının bütün eşyaları taşıyacak gücü yok.");
                        CiddiliYaz("Eşyaların bir kısmını bırakmalısın.");
                        while (true)
                        {
                            envanterdekilerinSayısı = ortakErişim.OrtakListe.Envanter.Count();
                            if (elemanSayısı * 4 + 3 > envanterdekilerinSayısı)
                            {
                                CiddiliYaz("Daha fazla eşya bırakmadan, yükleri sırtlandınız ve yola çıktınız.");
                                CiddiliYaz("Ama diğer elemanlarını doyurmadığın müddetçe onlar da gider mi kalır mı bilemiyorsun.");
                                return;
                            }
                            //Console.WriteLine($"Envanterde {ortakErişim.OrtakListe.Envanter.Count()}, tahminde {tahminiFiyat.Count()} eleman var.");
                            // Sonuçları yazdırma
                            Console.WriteLine($"Envanterin:");
                            for (int i = 0; i < ortakErişim.OrtakListe.Envanter.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{ortakErişim.OrtakListe.Envanter[i]}");
                            }
                            Thread.Sleep(100);
                            while (true)
                            {
                                string kullanıcıGirdisi = Console.ReadLine();

                                // Girdi kontrolü
                                if (int.TryParse(kullanıcıGirdisi, out int girdi))
                                {
                                    Console.WriteLine("\nGirilen sayı: " + girdi);
                                    // Girdi sayıya dönüştürülebiliyorsa
                                    if (girdi <= ortakErişim.OrtakListe.Envanter.Count)
                                    {
                                        string eşyaSat = ortakErişim.OrtakListe.Envanter[girdi - 1];
                                        Console.WriteLine("Bırakılan eşya: " + eşyaSat);
                                        ortakErişim.OrtakListe.Envanter.RemoveAt(girdi - 1);
                                        break;
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
                    }

                    return;
                }
                rastgele = random.Next(0, 35);
                if (rastgele <3) //<3
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
                else if (rastgele < 6 && ortakErişim.OrtakListe.Grup.Count >= 5 && !ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                {
                    rastgele = random.Next(10, 25);
                    CiddiliYaz("Hırsızlık");
                    CiddiliYaz("Paranı bulamıyorsun ancak yoldaşlarını suçlayabilecek durumda değilsin.");
                    CiddiliYaz("Erzak olmadığından dolayı herkes zaten çok gergin.");
                    CiddiliYaz("Kervandaki elemanlar sana karşı olan güvenlerini kaybettiler.");
                    ortakErişim.OrtakListe.Para -= rastgele;
                    CiddiliYaz($"{rastgele} paran artık gitti.");
                }
                else if (rastgele < 7 && ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                {
                    CiddiliYaz("Haşin Koruma senin otoritene saygısı kalmadığını belirtti.");
                    CiddiliYaz("Erzak bittiği için seni kınadı.");
                    CiddiliYaz("Haşin Koruma gruptan ayrıldı.");
                    ortakErişim.OrtakListe.Grup.Remove("Haşin Koruma");
                }
                else if (rastgele < 30 && ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma")
                        || rastgele < 20 && ortakErişim.OrtakListe.Grup.Contains("Basit Koruma"))
                {
                    CiddiliYaz("Koruman avdan döndü.");
                    Thread.Sleep(1000);
                    rastgele = random.Next(0, 6);
                    if(rastgele == 0)
                    {
                        CiddiliYaz("Bir tavşan avlamış.");
                        CiddiliYaz("Yiyecek bir şeyiniz oldu.");
                        ortakErişim.OrtakListe.Erzak += 3;
                        Bahşiş(4, 8, 2);
                    }
                    else if (rastgele == 1)
                    {
                        CiddiliYaz("Bir Ceylan avlamış.");
                        CiddiliYaz("Grubunuzdakiler duruma mutlu oldu.");
                        ortakErişim.OrtakListe.Erzak += 14;
                        Bahşiş(8, 15, 5);

                    }
                    else if (rastgele == 2)
                    {
                        CiddiliYaz("Bıldırcın avlamış.");
                        ortakErişim.OrtakListe.Erzak += 1;
                        Bahşiş(1, 4, 3);
                    }
                    else if (rastgele == 3)
                    {
                        CiddiliYaz("İki kuş avlamış.");
                        CiddiliYaz("Bölüşüp doymasanız da açlığınızı geçirdiniz.");
                        ortakErişim.OrtakListe.Erzak += 4;
                        Bahşiş(4, 10, 2);
                    }else
                    {
                        CiddiliYaz("Bir şey avlayamamış.");

                    }
                }
                else if (rastgele < 20)
                {
                    CiddiliYaz("Bir elemanın sana hakaretler ederek kervandan ayrıldı.");
                    CiddiliYaz("Erzağın yok. Ya herkes teker teker grubu terk edecek ya da açlıktan öleceksiniz.");
                    rastgele = random.Next(0, ortakErişim.OrtakListe.Grup.Count - 1);
                    CiddiliYaz($"Grubu terk eden: {ortakErişim.OrtakListe.Grup[rastgele]}.");
                    ortakErişim.OrtakListe.Grup.RemoveAt(rastgele);
                }
                else
                {
                    CiddiliYaz("Yoldaşların erzakların bitmesinden rahatsız olduğunu dillendiriyor.");
                }
            }

            if (olay == "kumarÇıkış") //Benim oyunumda kumar oynamayın lan! Neden mi koydum oyuna o mu zaman mı? E sizi kazıklamak için olm. Kumar kötü bi şe.
            {
                if(sayıGirdisi1 > 300)
                {
                    CiddiliYaz("\n\nGece evine yüklü miktarda kumar parasıyla dönerken ");
                    CiddiliYaz("Ansızın ensene inen acı verici bir sopayla bayıldın.");
                    rastgele = random.Next(1, 5);
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
                        case 4:
                            CiddiliYaz("Adamın teki üzerini karıştırıyordu.");
                            CiddiliYaz("Kendine geldin ve adamın kafasına şamarı yapıştırdın.");
                            CiddiliYaz("Adam şaşkınlıkla sendeledi ve adamı dönüp sen üzerindeki bütün parayı aldın.");
                            CiddiliYaz("Hana dönerken keyfin yerindeydi ama handa biraz ağrın olduğunu fark ettin.");
                            CiddiliYaz("Doktora görünsen iyi olacak.");
                            ortakErişim.OrtakListe.Olay.Add("Doktor");
                            sayıGirdisi1 = sayıGirdisi1 + random.Next(1, 15);
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


        private void Bahşiş(int min = 5, int max = 15, int aralık = 3)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Random random = new Random();
            int bahşişİstekMiktar;
            CiddiliYaz("Koruman bahşiş vermeni bekliyor.");
            CiddiliYaz($"(Kesinkez mutlu etmek için ödemen gereken miktar -> {max + aralık})");
            CiddiliYaz("Vereceksen tutarı gir, vermeyeceksen 0 -> ");
            bahşişİstekMiktar = random.Next(min, max); //Korumanın istediği para.
            while (true)
            {
                string girilenMiktar = Console.ReadLine();
                // Girişi bir tamsayıya dönüştürme
                if (int.TryParse(girilenMiktar, out int verilenPara))
                {
                    if (verilenPara <= ortakErişim.OrtakListe.Para)
                    {
                        CiddiliYaz($"Korumana {verilenPara} kadar para verdin.");
                        if (verilenPara < bahşişİstekMiktar - aralık)
                        {
                            CiddiliYaz("Koruman verdiğin miktarı beğenmedi.");
                            ortakErişim.OrtakListe.Olay.Add("Avcı Koruma Bahşiş İsyanı");
                        }else if (verilenPara > bahşişİstekMiktar + aralık)
                        {
                            CiddiliYaz("Koruman verdiğin miktardan ziyadesiyle mutlu oldu.");
                            CiddiliYaz("Emeğinin karşılığının verildiğini hissediyor.");
                        }else
                        {
                            CiddiliYaz("Koruman biraz daha fazla versen daha hoşnut olurdu gibi bir ifade takındı.");
                            CiddiliYaz("Ama bu miktar da kesinlikle ona yetmiş.");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("O kadar paran yok.\n -> ");
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen bir tamsayı girin.\n -> ");
                    // Giriş geçerli bir tamsayı değilse, uygun bir hata mesajı verebilir veya programı sonlandırabilirsiniz.
                }
            }
        }
    }
}
