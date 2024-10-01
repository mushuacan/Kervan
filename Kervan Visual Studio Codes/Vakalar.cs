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
            //Bu ne gereksiz bir ayrıştırıcı ağzımı kırayım
        }

        private void Vaka(string olay, int sayıGirdisi1 = 0)
        {
            //Son olduğundan dolayı diğer şeyleri kontrol etmeden önce çalışıp programı bitirse de olur.
            if (olay == "Son")
            {
                CiddiliYaz(Language.GetText("Vakalar.Vaka-1.1"));
                CiddiliYaz(Language.GetText("Vakalar.Vaka-1.2"));
                CiddiliYaz(Language.GetText("Vakalar.Vaka-1.3"));
                CiddiliYaz(Language.GetText("Vakalar.Vaka-1.4"));
                CiddiliYaz("\n\n\n", 500, 600);
                CiddiliYaz(Language.GetText("Vakalar.Vaka-1.5"));
                CiddiliYaz(Language.GetText("Vakalar.Vaka-1.6"));
                return;
            }

            #region Gerekli Referanslar
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Random random = new Random();
            int rastgele;
            #endregion

            CiddiliYaz("\n\n" + Language.GetText("Vakalar.Yaz(Vaka)") + "\n\n", 35, 115);
            Thread.Sleep(500);

            // Haritada ? üzerinde ilerlerken
            if (olay == "TehlikeliArazi") //T.A. -> Tehlikeli Arazi
            {
                if (sayıGirdisi1 == 5) //Harabelik
                {
                    CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.1"));
                    CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.2")); 
                    if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma") || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.1"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.2"));
                        while (true)
                        {
                            string girdi = Console.ReadLine();
                            if (girdi == "1") //Harabeliğe koruma gönderme
                            {
                                CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.2.Girdi.1"));
                                rastgele = random.Next(1, 10);
                                if (rastgele == 4) //Harabelikte Yüzük bulma
                                {
                                    CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.2.Girdi.1.Rand.4.1"));
                                    CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.2.Girdi.1.Rand.4.2"));
                                    ortakErişim.OrtakListe.Envanter.Add("Elmas Yüzük");
                                }
                                if (rastgele == 7) //Harabelikte Çömlek bulma
                                {
                                    CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.2.Girdi.1.Rand.7.1"));
                                    CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.2.Girdi.1.Rand.7.2"));
                                    ortakErişim.OrtakListe.Envanter.Add("Çömlek");
                                    ortakErişim.OrtakListe.Envanter.Add("Çömlek");
                                }
                                break;
                            }
                            else if (girdi == "0") //Harabeliğe koruma göndermeme
                            {
                                CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.Koruma.2.Girdi.0"));
                                break;
                            }
                            else
                            {
                                CiddiliYaz(Language.GetText("All.1/0"));
                            }
                        }
                    }
                    else //Harabeliğe geldin ama koruman yok
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.KorumaYok.1"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Harabelik.KorumaYok.2"));
                    }
                }
                else if (sayıGirdisi1 == 6) //Ayı saldırısı
                {
                    CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.1"));
                    CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.2"));
                    if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma") || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.1"));
                        if (ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                        {
                            CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.Haşin.1"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.Haşin.2"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.Haşin.3"));
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Et");
                            ortakErişim.OrtakListe.Envanter.Add("Et");
                            CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.Haşin.4"));
                        }
                        else
                        {
                            CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.Basit.1"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.Basit.2"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Koruma.Basit.3"));
                        }
                    }
                    else
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Korumasız.1"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Korumasız.2"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Ayı.Korumasız.3"));
                        if (ortakErişim.OrtakListe.Grup.Count > 1)
                        {
                            rastgele = random.Next(0, ortakErişim.OrtakListe.Grup.Count - 1);
                            CiddiliYaz(Language.GetText($"Şehir.İş.{ortakErişim.OrtakListe.Grup[rastgele]}")
                               + " " + Language.GetText("Vaka.T.A.Ayı.Korumasız.ElemanÖldü"));
                            ortakErişim.OrtakListe.Grup.RemoveAt(rastgele);
                        }
                        if (ortakErişim.OrtakListe.Envanter.Count > 1)
                        {
                            rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                            CiddiliYaz(Language.GetText($"Eşyalar.item.{ortakErişim.OrtakListe.Envanter[rastgele]}")
                               + " " + Language.GetText("Vaka.T.A.Ayı.Korumasız.EşyaKırıldı"));
                            ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                        }
                        if (ortakErişim.OrtakListe.Envanter.Count > 1)
                        {
                            rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                            CiddiliYaz(Language.GetText($"Eşyalar.item.{ortakErişim.OrtakListe.Envanter[rastgele]}")
                               + " " + Language.GetText("Vaka.T.A.Ayı.Korumasız.EşyaKırıldı"));
                            ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                        }
                    }
                }
                else if (sayıGirdisi1 == 7) //Eşkiya baskını
                {
                    CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.1"));
                    if (ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Haşin.1"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Haşin.2"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Haşin.3"));
                        CiddiliYaz(".....", 300, 800);
                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Haşin.4"));
                        ortakErişim.OrtakListe.Grup.Remove("Haşin Koruma");
                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Haşin.5"));
                        ortakErişim.OrtakListe.Envanter.Add("Elmas Yüzük");
                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Haşin.6"));
                    }
                    else if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma"))
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Basit.1"));
                        ortakErişim.OrtakListe.Grup.Remove("Basit Koruma");
                        rastgele = random.Next(0, ortakErişim.OrtakListe.Grup.Count - 1);

                        CiddiliYaz(Language.GetText("Vaka.T.A.Eşkiya.Basit.Yitti.koruma.baş") 
                            + Language.GetText($"Şehir.İş.{ortakErişim.OrtakListe.Grup[rastgele]}")
                            + Language.GetText("Vaka.T.A.Eşkiya.Basit.Yitti.koruma.son"));

                        if (ortakErişim.OrtakListe.Envanter.Count > 1)
                        {
                            rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                            CiddiliYaz(Language.GetText($"Eşyalar.item.{ortakErişim.OrtakListe.Envanter[rastgele]}")
                                + Language.GetText("Vaka.T.A.Eşkiya.Çalındı"));
                            ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                        }
                        if (ortakErişim.OrtakListe.Envanter.Count > 1)
                        {
                            rastgele = random.Next(0, ortakErişim.OrtakListe.Envanter.Count - 1);
                            CiddiliYaz(Language.GetText($"Eşyalar.item.{ortakErişim.OrtakListe.Envanter[rastgele]}")
                                + Language.GetText("Vaka.T.A.Eşkiya.Çalındı"));
                            ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                        }

                        rastgele = random.Next(0, ortakErişim.OrtakListe.Para);
                        CiddiliYaz($"{rastgele} " + Language.GetText("Vaka.T.A.Eşkiya.Çalındı2"));
                        ortakErişim.OrtakListe.Para -= rastgele;
                    }else
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.1"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.2"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.3"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.4"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.5"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.6"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.7"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.8"), 200, 300);
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.9"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.EşkiyaBaskını.10"));
                        VakaAyrıştırıcı("Son");
                        Thread.Sleep(4444);
                        KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                        kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.eşkiy.luz"); //Eşkiya mağlubiyeti
                        Environment.Exit(0);
                    }
                }
                else if (sayıGirdisi1 == 8) //Kurdun gelişi
                {
                    CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.1"));
                    if (ortakErişim.OrtakListe.Envanter.Contains("Et") || ortakErişim.OrtakListe.Envanter.Contains("Balık"))
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.2"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.3"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.4"));
                        if(ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                        {
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Haşin.1"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Haşin.2"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Haşin.3"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Haşin.4"));
                            ortakErişim.OrtakListe.Envanter.Add("Deri");
                            ortakErişim.OrtakListe.Envanter.Add("Et");
                        }
                        else if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma"))
                        {
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Basit.1"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Basit.2"));
                            if(ortakErişim.OrtakListe.Envanter.Contains("Aile Yâdigârı Gümüş Kolye"))
                            {
                                CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Yadigar.1"));
                                CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Yadigar.2"));
                                ortakErişim.OrtakListe.Envanter.Remove("Aile Yâdigârı Gümüş Kolye");
                            }
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Basit.3"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Basit.4"));
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
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Korumasız.1"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Korumasız.2"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Korumasız.3"));
                            while (ortakErişim.OrtakListe.Envanter.Contains("Et") || ortakErişim.OrtakListe.Envanter.Contains("Balık"))
                            {
                                if (ortakErişim.OrtakListe.Envanter.Contains("Et"))
                                {
                                    ortakErişim.OrtakListe.Envanter.Remove("Et");
                                    CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Korumasız.Et.Gitmiş"), 20, 50);
                                }
                                else
                                {
                                    ortakErişim.OrtakListe.Envanter.Remove("Balık");
                                    CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Korumasız.Balık.Gitmiş"), 20, 50);
                                }
                            }
                        }
                    }
                    else
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Kurt.Saldırmadı"));
                    }
                }
                else if (sayıGirdisi1 == 9) //Adamın teki kervanı takip ediyor.
                {
                    CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.1"));
                    if (ortakErişim.OrtakListe.Grup.Contains("Basit Koruma") || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.2"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.3")); //Korumalar ayakta kaldılar
                    }
                    else
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.4"));
                        CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.5")); //Rastgele eleman ayakta kaldı
                        if (ortakErişim.OrtakListe.Envanter.Contains("Aile Yâdigârı Gümüş Kolye"))
                        {
                            CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.6"));
                            CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.7")); //Yadigar çalınmış
                            ortakErişim.OrtakListe.Envanter.Remove("Aile Yâdigârı Gümüş Kolye");
                        }
                        else
                        {
                            rastgele = random.Next(1, ortakErişim.OrtakListe.Para); // Para çalınmış
                            CiddiliYaz(Language.GetText("Vaka.T.A.Tekinsiz.Adam.8.baş") + $" {rastgele} " 
                                + Language.GetText("Vaka.T.A.Tekinsiz.Adam.8.son"));
                            ortakErişim.OrtakListe.Para -= rastgele;
                        }
                    }
                }
                else if (sayıGirdisi1 == 10) // ?
                {
                    CiddiliYaz(Language.GetText("Vaka.T.A.Giz.1"));
                    if (ortakErişim.OrtakListe.Envanter.Contains("Çömlek"))
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Giz.2"));
                        ortakErişim.OrtakListe.Envanter.Remove("Çömlek");
                    }else
                    {
                        CiddiliYaz(Language.GetText("Vaka.T.A.Giz.3"));
                    }
                }else
                {
                    CiddiliYaz(Language.GetText("Vaka.T.A.olaysız.1"), 20, 30);
                    CiddiliYaz(Language.GetText("Vaka.T.A.olaysız.2"), 20, 30);
                    CiddiliYaz(Language.GetText("Vaka.T.A.olaysız.3"), 20, 30);

                }
            }

            // Erzak bitmişken
            if (olay == "Hırsızlık")
            {
                if (ortakErişim.OrtakListe.Grup.Count <= 1)
                {
                    rastgele = random.Next(0, 10);
                    if (rastgele == 6)
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.1"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.2"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.3"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.4"));
                        if (ortakErişim.OrtakListe.Envanter.Contains("Aile Yâdigârı Gümüş Kolye"))
                        {
                            CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.5"));
                        }
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.6"));
                        if (ortakErişim.OrtakListe.Envanter.Count > 3)
                        {
                            CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.7"));
                        }
                        else
                        {
                            CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.8"));
                        }
                    }else
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.9"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.10"));
                    }
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.iflas.11"));
                    VakaAyrıştırıcı("Son");
                    Thread.Sleep(4444);
                    KazanımlarVeSonlar kazanımlarVeSonlar = new KazanımlarVeSonlar();
                    kazanımlarVeSonlar.YeniBitirilenSonEkle("kznm.sn.yolda.luz"); //Yolda Kalma mağlubiyeti
                    Environment.Exit(0);
                }
                // Avcı Koruma Bahşiş İsyanı -> AKBİ
                if (ortakErişim.OrtakListe.Olay.Contains("Avcı Koruma Bahşiş İsyanı")
                    && ortakErişim.OrtakListe.Grup.Contains("Basit Koruma")
                    || ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                {
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.1"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.2"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.3"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.4"));
                    ortakErişim.OrtakListe.Grup.Remove("Basit Koruma");
                    ortakErişim.OrtakListe.Grup.Remove("Haşin Koruma");
                    ortakErişim.OrtakListe.Grup.Remove("Aşçı");
                    ortakErişim.OrtakListe.Grup.Remove("Eleman");
                    ortakErişim.OrtakListe.Grup.Remove("Eleman");
                    ortakErişim.OrtakListe.Grup.Remove("Eleman");
                    ortakErişim.OrtakListe.Olay.Remove("Avcı Koruma Bahşiş İsyanı");
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.5"));
                    Şehir ŞehirCs = new Şehir();
                    ŞehirCs.GrupYazdır();
                    Thread.Sleep(2000); //Çokça kişi grubu terk etti

                    string arananEleman = "Eleman";
                    int elemanSayısı = ortakErişim.OrtakListe.Grup.Count(e => e == arananEleman);
                    int envanterdekilerinSayısı = ortakErişim.OrtakListe.Envanter.Count();
                    if (!(elemanSayısı * 4 > envanterdekilerinSayısı))
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.Envanter.1"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.Envanter.2"));
                        while (true)
                        {
                            envanterdekilerinSayısı = ortakErişim.OrtakListe.Envanter.Count();
                            if (elemanSayısı * 4 + 3 > envanterdekilerinSayısı)
                            {
                                CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.Yol.1"));
                                CiddiliYaz(Language.GetText("Vaka.Hırsızlık.AKBİ.Yol.2"));
                                return;
                            }
                            //Console.WriteLine($"Envanterde {ortakErişim.OrtakListe.Envanter.Count()}, tahminde {tahminiFiyat.Count()} eleman var.");
                            // Sonuçları yazdırma
                            Console.WriteLine(Language.GetText("Vaka.Hırsızlık.AKBİ.Envanterin"));
                            for (int i = 0; i < ortakErişim.OrtakListe.Envanter.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{Language.GetText($"Eşyalar.item.{ortakErişim.OrtakListe.Envanter[i]}")}");
                            }
                            Thread.Sleep(100);
                            while (true)
                            {
                                string kullanıcıGirdisi = Console.ReadLine();

                                // Girdi kontrolü
                                if (int.TryParse(kullanıcıGirdisi, out int girdi))
                                {
                                    Console.WriteLine("\n" + Language.GetText("Vaka.Hırsızlık.AKBİ.Girdi") + " " + girdi);
                                    // Girdi sayıya dönüştürülebiliyorsa
                                    if (girdi <= ortakErişim.OrtakListe.Envanter.Count)
                                    {
                                        string eşyaSat = ortakErişim.OrtakListe.Envanter[girdi - 1];
                                        Console.WriteLine(Language.GetText("Vaka.Hırsızlık.AKBİ.Eşya") + " " 
                                            + Language.GetText($"Eşyalar.item.{eşyaSat}"));
                                        ortakErişim.OrtakListe.Envanter.RemoveAt(girdi - 1);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(Language.GetText("Vaka.Hırsızlık.AKBİ.YanlışGirdi"));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(Language.GetText("All.GeçersizGirdiSayıGir"));
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
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.<3.1"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.<3.2"));

                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.<3.3") +
                        Language.GetText($"Eşyalar.item.{ortakErişim.OrtakListe.Envanter[rastgele]}"));

                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.<3.4") +
                        Language.GetText($"Şehir.İş.{ortakErişim.OrtakListe.Grup[rastgele2]}"));

                    ortakErişim.OrtakListe.Envanter.RemoveAt(rastgele);
                    ortakErişim.OrtakListe.Grup.RemoveAt(rastgele2);
                }
                else if (rastgele < 6 && ortakErişim.OrtakListe.Grup.Count >= 5 && !ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                {
                    rastgele = random.Next(10, 25);
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.2.1"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.2.2"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.2.3"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.2.4"));
                    ortakErişim.OrtakListe.Para -= rastgele;
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.2.5") + $" {rastgele}");
                }
                else if (rastgele < 7 && ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma"))
                {
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.3.1"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.3.2"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.3.3"));
                    ortakErişim.OrtakListe.Grup.Remove("Haşin Koruma");
                }
                else if (rastgele < 30 && ortakErişim.OrtakListe.Grup.Contains("Haşin Koruma")
                        || rastgele < 20 && ortakErişim.OrtakListe.Grup.Contains("Basit Koruma"))
                {
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4"));
                    Thread.Sleep(1000);
                    rastgele = random.Next(0, 6);
                    if(rastgele == 0)
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.1.1"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.1.2"));
                        ortakErişim.OrtakListe.Erzak += 3;
                        Bahşiş(4, 8, 2);
                    }
                    else if (rastgele == 1)
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.2.1"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.2.2"));
                        ortakErişim.OrtakListe.Erzak += 14;
                        Bahşiş(8, 15, 5);

                    }
                    else if (rastgele == 2)
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.3.1"));
                        ortakErişim.OrtakListe.Erzak += 1;
                        Bahşiş(1, 4, 3);
                    }
                    else if (rastgele == 3)
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.4.1"));
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.4.2"));
                        ortakErişim.OrtakListe.Erzak += 4;
                        Bahşiş(4, 10, 2);
                    }else
                    {
                        CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.4.5.1"));

                    }
                }
                else if (rastgele < 20)
                {
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.5.1"));
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.5.2"));
                    rastgele = random.Next(0, ortakErişim.OrtakListe.Grup.Count - 1);
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.5.3") 
                        + Language.GetText($"Şehir.İş.{ortakErişim.OrtakListe.Grup[rastgele]}"));
                    ortakErişim.OrtakListe.Grup.RemoveAt(rastgele);
                }
                else
                {
                    CiddiliYaz(Language.GetText("Vaka.Hırsızlık.Rand.else"));
                }
            }

            //Benim oyunumda kumar oynamayın lan! Neden mi koydum oyuna o mu zaman mı? E sizi kazıklamak için olm. Kumar kötü bi şe.
            if (olay == "kumarÇıkış") 
            {
                if(sayıGirdisi1 > 300)
                {
                    CiddiliYaz("\n\n" + Language.GetText("Vaka.Kumar.0.1"));
                    CiddiliYaz(Language.GetText("Vaka.Kumar.0.2"));
                    rastgele = random.Next(1, 5);
                    switch (rastgele)
                    {
                        case 1:
                            CiddiliYaz(Language.GetText("Vaka.Kumar.1.1"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.1.2"));
                            break;
                        case 2:
                            CiddiliYaz(Language.GetText("Vaka.Kumar.2.1"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.2.2"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.2.3"));
                            break;
                        case 3:
                            CiddiliYaz(Language.GetText("Vaka.Kumar.3.1"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.3.2"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.3.3"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.3.4"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.3.5"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.3.6"));
                            ortakErişim.OrtakListe.Olay.Add("Doktor");
                            break;
                        case 4:
                            CiddiliYaz(Language.GetText("Vaka.Kumar.4.1"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.4.2"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.4.3"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.4.4"));
                            CiddiliYaz(Language.GetText("Vaka.Kumar.4.5"));
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
                    CiddiliYaz(Language.GetText("Vaka.Kumar.5.1"));
                    CiddiliYaz(Language.GetText("Vaka.Kumar.5.2"));
                    CiddiliYaz(Language.GetText("Vaka.Kumar.5.3"));
                    CiddiliYaz(Language.GetText("Vaka.Kumar.5.4"));
                    CiddiliYaz(Language.GetText("Vaka.Kumar.5.5"));
                    CiddiliYaz(Language.GetText("Vaka.Kumar.5.6"));
                    CiddiliYaz(Language.GetText("Vaka.Kumar.5.7") + $" {rastgele}");
                    ortakErişim.OrtakListe.Para = sayıGirdisi1 - rastgele;
                }
            }

            //Doktor görme olayı
            if (olay == "1" || olay == "3")
            {
                CiddiliYaz(Language.GetText("Vaka.dc.1"));
                CiddiliYaz(Language.GetText("Vaka.dc.2"));
                ortakErişim.OrtakListe.Olay.Add("Doktor");
            }
            //Olaysızlar
            else if (olay == "2")
            {
                rastgele = random.Next(1,9);
                if (rastgele == 1) { CiddiliYaz(Language.GetText("Vaka.Çerez.1")); }
                if (rastgele == 2) { CiddiliYaz(Language.GetText("Vaka.Çerez.2")); }
                if (rastgele == 3) { CiddiliYaz(Language.GetText("Vaka.Çerez.3")); }
                if (rastgele == 4) { CiddiliYaz(Language.GetText("Vaka.Çerez.4")); }
                if (rastgele == 5) { CiddiliYaz(Language.GetText("Vaka.Çerez.5")); }
                if (rastgele == 6) { CiddiliYaz(Language.GetText("Vaka.Çerez.6")); }
                if (rastgele == 7) { CiddiliYaz(Language.GetText("Vaka.Çerez.7")); }
                if (rastgele == 8) { CiddiliYaz(Language.GetText("Vaka.Çerez.8")); }
            }

            #region Dilenci
            //Yoldaki dilenci
            else if (olay == "4" 
                && !ortakErişim.OrtakListe.Olay.Contains("Gariban")
                && !ortakErişim.OrtakListe.Olay.Contains("GaribandıArtıkZengin"))
            {
                CiddiliYaz(Language.GetText("Vaka.Dilenci.1"));
                CiddiliYaz(Language.GetText("Vaka.Dilenci.2"));
                while (true)
                {
                    string cevap = Console.ReadLine();
                    if (cevap == "1")
                    {
                        CiddiliYaz(Language.GetText("Vaka.Dilenci.3"));
                        ortakErişim.OrtakListe.Erzak--;
                        ortakErişim.OrtakListe.Olay.Add("Gariban");
                        break;
                    }else if (cevap == "0")
                    {
                        CiddiliYaz(Language.GetText("Vaka.Dilenci.4"));
                        CiddiliYaz(Language.GetText("Vaka.Dilenci.5"), 100, 400);
                        CiddiliYaz(Language.GetText("Vaka.Dilenci.6"), 100, 400);
                        CiddiliYaz(Language.GetText("Vaka.Dilenci.7"), 100, 300);
                        break;
                    }
                    else
                    {
                        CiddiliYaz(Language.GetText("Vaka.Dilenci.8"));
                    }
                }
            }
            //Yoldaki dilenci zengin olmuş, seni takdir ediyor.
            else if (olay == "5" && ortakErişim.OrtakListe.Olay.Contains("Gariban"))
            {
                for (int i = 1; i<15; i++)
                {
                    CiddiliYaz(Language.GetText($"Vaka.Zengin.{i}"));
                }
                ortakErişim.OrtakListe.Envanter.Add("Elmas Yüzük");
                ortakErişim.OrtakListe.Olay.Remove("Gariban");
                ortakErişim.OrtakListe.Olay.Add("GaribandıArtıkZengin");
            }
            //Yoldaki dilenci zengin olmuştu karşılaşmışsın, tekrar karşılaştın.
            else if (olay == "5" && ortakErişim.OrtakListe.Olay.Contains("GaribandıArtıkZengin"))
            {
                CiddiliYaz(Language.GetText("Vaka.Zengin.Yine.1"));
                CiddiliYaz(Language.GetText("Vaka.Zengin.Yine.2"));
                ortakErişim.OrtakListe.Envanter.Add("Baharat");
                ortakErişim.OrtakListe.Envanter.Add("Baharat");
                ortakErişim.OrtakListe.Olay.Remove("GaribandıArtıkZengin");
                ortakErişim.OrtakListe.Olay.Add("Zengin");
            }
            #endregion
        }

        //Erzak bitmişken korumalar avlanınca bahşiş isterler.
        private void Bahşiş(int min = 5, int max = 15, int aralık = 3)
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Random random = new Random();
            int bahşişİstekMiktar;
            CiddiliYaz(Language.GetText("vBahşiş.1"));
            CiddiliYaz(Language.GetText("vBahşiş.2") + $" {max + aralık}");
            CiddiliYaz(Language.GetText("vBahşiş.3"));
            bahşişİstekMiktar = random.Next(min, max); //Korumanın istediği para.
            while (true)
            {
                string girilenMiktar = Console.ReadLine();
                // Girişi bir tamsayıya dönüştürme
                if (int.TryParse(girilenMiktar, out int verilenPara))
                {
                    if (verilenPara <= ortakErişim.OrtakListe.Para)
                    {
                        CiddiliYaz(Language.GetText("vBahşiş.4") + $" {verilenPara}");
                        if (verilenPara < bahşişİstekMiktar - aralık)
                        {
                            CiddiliYaz(Language.GetText("vBahşiş.5"));
                            ortakErişim.OrtakListe.Olay.Add("Avcı Koruma Bahşiş İsyanı");
                        }else if (verilenPara > bahşişİstekMiktar + aralık)
                        {
                            CiddiliYaz(Language.GetText("vBahşiş.6"));
                            CiddiliYaz(Language.GetText("vBahşiş.7"));
                        }
                        else
                        {
                            CiddiliYaz(Language.GetText("vBahşiş.8"));
                            CiddiliYaz(Language.GetText("vBahşiş.9"));
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine(Language.GetText("vBahşiş.10") + "\n -> ");
                    }
                }
                else
                {
                    Console.WriteLine(Language.GetText("All.GeçersizGirdiSayıGir") + "\n -> ");
                    // Giriş geçerli bir tamsayı değilse, uygun bir hata mesajı verebilir veya programı sonlandırabilirsiniz.
                }
            }
        }
    }
}
