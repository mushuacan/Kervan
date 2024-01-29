﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kervan
{
    internal class Kumar
    {
        public int coinEnter()
        {
            OL_Singleton ortakErişim = OL_Singleton.Instance;
            Console.WriteLine($"Toplam paran {ortakErişim.OrtakListe.Para}.");
            Console.Write("Kumarhâneye geldin. Kaç para yatırmak istersin: ");

            #region Kumarhanede Para Girişi
            string girilenMiktar = Console.ReadLine();

            // Girişi bir tamsayıya dönüştürme
            if (int.TryParse(girilenMiktar, out int yatirilanPara))
            {
                if (yatirilanPara <= ortakErişim.OrtakListe.Para)
                {
                    return yatirilanPara;
                }
                else
                {
                    Console.WriteLine("Lanet olsun dostum! O kadar paran yok.");
                    return coinEnter();
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir tamsayı girin.");
                coinEnter();
                // Giriş geçerli bir tamsayı değilse, uygun bir hata mesajı verebilir veya programı sonlandırabilirsiniz.
            }
            return 0;
            #endregion
        }

        public void Gamble(int coin, int coinAtFirst)
        {
            #region Değişkenler
            string playAgainInput;
            int coinRate;
            int guess;
            int attempts = 0;
            
            int randomMax;
            int due; //Kaç deneme hakkı olduğu

            randomMax = 161; //150
            due = 7; //6
            #endregion

            #region KUMAR OYUNU
            do
            {
                if (coin <= 0)
                {
                    break;
                }

                #region Değişken ayarlamaları
                due--;
                attempts = 0;
                bool whileLoop = true;
                randomMax = randomMax - 10;
                coinRate = (int)(coin * (17 - due) * 0.08);
                #endregion

                Random randomCs = new Random();
                int targetNumber = randomCs.Next(1, randomMax); 

                Console.WriteLine($"\nŞu kadar para yatırdın: {coin}\nKazanırsan en az {coinRate} kadar para kazanacaksın.  ");
                Console.WriteLine("Kaybedersen bütün paranı kaybedeceksin.");
                Console.Write("\nOynamak istiyor musunuz? (Evet için 1, Hayır için 0): ");

                playAgainInput = Console.ReadLine();
                if (playAgainInput != "1")
                {
                    break;
                }

                Console.WriteLine($"\n1 ile {randomMax - 1} arasında bir sayıyı tahmin edin. {due} kadar hakkın var.");

                do
                {
                    Console.Write($"{attempts + 1}. tahmininizi girin: ");
                    string input = Console.ReadLine();
                    attempts++;

                    // Kullanıcının girişini kontrol etme
                    if (!int.TryParse(input, out guess))
                    {
                        attempts--;
                        //Hile
                        if (input == "kumarbaz")
                        {
                            Console.Write($"\n\n\nHile aktifleştirildi. Sayı: {targetNumber}\n\n\n");
                            continue;
                        }
                        Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
                        continue;
                    }

                    // Tahminin doğruluğunu kontrol etme
                    if (guess < targetNumber)
                    {
                        Console.WriteLine("Daha BÜYÜK bir sayı girin.");
                    }
                    else if (guess > targetNumber)
                    {
                        Console.WriteLine("Daha KÜÇÜK bir sayı girin.");
                    }

                    if (guess == targetNumber)
                    {
                        Console.WriteLine($"\nK A Z A N D I N !!!!\n");
                        Thread.Sleep(500);
                        Console.WriteLine($"Tebrikler! {attempts} denemede doğru sayıyı buldunuz. Sayı: {targetNumber}\n");
                        Console.WriteLine($"Paranız {coin} idi");
                        Thread.Sleep(200);
                        int coinWin = (int)(coinRate * (due - attempts + 5) / 5);
                        coin = coin + coinWin;
                        Console.WriteLine($"Paranız {coinWin} artarak {coin} oldu.");
                        Thread.Sleep(300);
                        whileLoop = false;
                    }
                    else if (attempts == due)
                    {
                        Console.WriteLine($"\nK A Y B E T T İ N !!!!\n");
                        Console.WriteLine($"{targetNumber} sayısını {attempts} defa denediysen de bulamadın.\n");
                        Console.WriteLine($"Paranız {coin} idi");
                        playAgainInput = "NoCoin";
                        coinRate = coin;
                        coin = 0;
                        Console.Write("Bütün paranı harcadın. Kumarhaneyi terk ediyorsun.");
                        whileLoop = false;
                        Gamble(coin, coinAtFirst);
                        return;
                    }

                } while (whileLoop);
            } while (playAgainInput == "1");
            #endregion

            OL_Singleton ortakErişim = OL_Singleton.Instance;

            ortakErişim.OrtakListe.Para -= coinAtFirst;
            Console.WriteLine($"\n\nKumarhâneden çıktın. {coinAtFirst} kadar para yatırdın ve şuan {coin} kadar parayla çıkıyorsun.\n\n\n");

            #region Kumarhane Çıkışı Vakaları
            Random random = new Random();
            int rastgele = random.Next(0, 40);

            if (coin >= 100 && rastgele < 5)
            {
                Vakalar vakaCs = new Vakalar();
                vakaCs.VakaAyrıştırıcı("kumarÇıkış", coin);
                ortakErişim.OrtakListe.Olay.Add("Kumar Parası");
            }
            else if (coin >= 300 && rastgele < 7)
            {
                Vakalar vakaCs = new Vakalar();
                vakaCs.VakaAyrıştırıcı("kumarÇıkış", coin);
                ortakErişim.OrtakListe.Olay.Add("Kumar Dayağı");
            }
            else
            {
                ortakErişim.OrtakListe.Para += coin;
                ortakErişim.OrtakListe.Olay.Add("Kumar Parası");
            }
            #endregion

            Harita haritaCs = new Harita();
            haritaCs.oyunBekasıKontrol(true);
            Console.WriteLine($"Toplam paran {ortakErişim.OrtakListe.Para}.");
        }
    }
}
