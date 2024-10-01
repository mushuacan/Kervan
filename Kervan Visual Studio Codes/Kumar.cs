using System;
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
            Console.WriteLine(Language.GetText("Kumar.coinEnter.1") + $" {ortakErişim.OrtakListe.Para}.");
            Console.Write(Language.GetText("Kumar.coinEnter.2") + " ");

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
                    Console.WriteLine(Language.GetText("Kumar.coinEnter.YeterizPara"));
                    return coinEnter();
                }
            }
            else
            {
                Console.WriteLine(Language.GetText("All.GeçersizGirdiSayıGir"));
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
            due = 8; //7
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

                Console.WriteLine("\n" + Language.GetText("Kumar.Gamble.Giriş.1.1") + $" {coin}");
                Console.WriteLine(Language.GetText("Kumar.Gamble.Giriş.1.2") + $" {coinRate}");
                Console.WriteLine(Language.GetText("Kumar.Gamble.Giriş.2"));
                Console.Write("\n" + Language.GetText("Kumar.Gamble.Giriş.3") + " ");

                playAgainInput = Console.ReadLine();
                if (playAgainInput != "1")
                {
                    break;
                }

                Console.WriteLine("\n" + Language.GetText("Kumar.Gamble.1") + $" 1-{randomMax - 1}");
                Console.WriteLine(Language.GetText("Kumar.Gamble.2") + $" {due}");

                do
                {
                    Console.Write($"{attempts + 1}. " + Language.GetText("Kumar.Gamble.3") + " ");
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
                        Console.WriteLine(Language.GetText("All.GeçersizGirdiSayıGir"));
                        continue;
                    }

                    // Tahminin doğruluğunu kontrol etme
                    if (guess < targetNumber)
                    {
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.büyük"));
                    }
                    else if (guess > targetNumber)
                    {
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.küçük"));
                    }

                    if (guess == targetNumber)
                    {
                        Console.WriteLine("\n" + Language.GetText("Kumar.Gamble.Oyun.Win") + "\n");
                        Thread.Sleep(500);
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Win.1"));
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Win.2") + $" {attempts}\n");
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Win.3") + $" {targetNumber}");
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Yatırdığın") + $" {coin}");
                        Thread.Sleep(200);
                        int coinWin = (int)(coinRate * (due - attempts + 5) / 5);
                        coin = coin + coinWin;
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Win.4") + $" {coinWin}");
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Para") + $" {coin}");
                        Thread.Sleep(300);
                        whileLoop = false;
                    }
                    else if (attempts == due)
                    {
                        Console.WriteLine($"\n" + Language.GetText("Kumar.Gamble.Oyun.Lose") + "\n");
                        Thread.Sleep(500);
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Lose.1") + $" {targetNumber}");
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Lose.2") + $" {attempts}\n");
                        Thread.Sleep(250);
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Yatırdığın") + $" {coin}");
                        playAgainInput = "NoCoin";
                        coinRate = coin;
                        coin = 0;
                        Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.İflas"));
                        whileLoop = false;
                        Gamble(coin, coinAtFirst);
                        return;
                    }

                } while (whileLoop);
            } while (playAgainInput == "1");
            #endregion

            OL_Singleton ortakErişim = OL_Singleton.Instance;

            ortakErişim.OrtakListe.Para -= coinAtFirst;
            Console.WriteLine("\n\n" + Language.GetText("Kumar.Out"));
            Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Yatırdığın") + $" {coinAtFirst}");
            Console.WriteLine(Language.GetText("Kumar.Gamble.Oyun.Para") + $" {coin}\n\n\n");

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
            Console.WriteLine(Language.GetText("All.Para") + $" {ortakErişim.OrtakListe.Para}");
        }
    }
}
