using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kervan
{
    // Şehir sınıfı
    public class City
    {
        public string Name { get; set; }
        public List<Item> AvailableItems { get; set; }

        public City(string name)
        {
            Name = name;
            AvailableItems = new List<Item>();
        }
    }

    // Eşya sınıfı
    // Eşya sınıfı
    public class Item
    {
        public string Name { get; set; }
        private int baseRarity; // Eşyanın şehir dışındaki nadirlik değeri
        private Dictionary<string, int> cityRarities; // Şehirlere özel nadirlik değerleri
        private int basePrice; // Eşyanın şehir dışındaki değeri
        private Dictionary<string, int> cityPrices; // Şehirlere özel fiyatlar

        public Item(string name, int rarity, int basePrice)
        {
            Name = name;
            baseRarity = rarity;
            cityRarities = new Dictionary<string, int>();
            this.basePrice = basePrice;
            cityPrices = new Dictionary<string, int>();
        }
        public void SetCityData(string cityName, int rarity, int price)
        {
            SetCityInfo(cityRarities, cityName, rarity);
            SetCityInfo(cityPrices, cityName, price);
        }

        private void SetCityInfo(Dictionary<string, int> cityInfoDictionary, string cityName, int value)
        {
            if (cityInfoDictionary.ContainsKey(cityName))
            {
                cityInfoDictionary[cityName] = value;
            }
            else
            {
                cityInfoDictionary.Add(cityName, value);
            }
        }

        public int GetFinalValue(Dictionary<string, int> cityInfoDictionary, string cityName, int defaultValue)
        {
            if (cityInfoDictionary.ContainsKey(cityName))
            {
                return cityInfoDictionary[cityName];
            }
            else
            {
                return defaultValue;
            }
        }

        public int GetFinalRarity(string cityName)
        {
            return GetFinalValue(cityRarities, cityName, baseRarity);
        }

        public int GetFinalPrice(string cityName)
        {
            return GetFinalValue(cityPrices, cityName, basePrice);
        }

        /*
        public void SetCityRarity(string cityName, int rarity)
        {
            if (cityRarities.ContainsKey(cityName))
            {
                cityRarities[cityName] = rarity;
            }
            else
            {
                cityRarities.Add(cityName, rarity);
            }
        }
        public void SetCityPrice(string cityName, int price)
        {
            if (cityPrices.ContainsKey(cityName))
            {
                cityPrices[cityName] = price;
            }
            else
            {
                cityPrices.Add(cityName, price);
            }
        }

        public int GetFinalRarity(string cityName)
        {
            if (cityRarities.ContainsKey(cityName))
            {
                return cityRarities[cityName];
            }
            else
            {
                return baseRarity;
            }
        }

        public int GetFinalPrice(string cityName)
        {
            if (cityPrices.ContainsKey(cityName))
            {
                return cityPrices[cityName];
            }
            else
            {
                return basePrice;
            }
        }*/
    }

    internal class Eşyalar
    {

        public List<City> ŞehirlerListesi { get; set; }
        public List<Item> AllItems { get; set; }
        public Eşyalar()
        {
            Eşya(); // Eşya metodunu çağır
        }

        public void Eşya()
        {
            ŞehirlerListesi = new List<City>
            {
            new City("Harabeler"),
            new City("Güney Koyuncular Köyü"),
            new City("Güney Liman Şehri"),
            new City("Madenciler Köyü"),
            new City("Balıkçılar Köyü"),
            new City("Merkez Şehir"),
            new City("Çiftçiler Köyü"),
            new City("Kuzey Koyuncular Köyü"),
            new City("Kuzey Liman Şehri"),
            // Diğer şehirleri buraya ekleyebilirsiniz.
            };
            #region FİYATLANDIRMA
            AllItems = new List<Item>
        {
            //Eşya ismi, nadirlik 100-0, fiyat
            new Item("Et", 15, 15),
            new Item("Balık", 33, 8),
            new Item("Tahıl", 25, 6),
            new Item("İçki", 25, 15),
            new Item("Yün", 20, 10),
            new Item("Tuz", 7, 15),
            new Item("Demir", 10, 20),
            new Item("Çömlek", 18, 8),
            new Item("Yağ", 5, 30),
            new Item("İpek", 1, 50),
            new Item("Baharat", 7, 35),
            new Item("Midye", 5, 5),
            new Item("Keten", 10, 20),
            new Item("Bal", 3, 25),
            new Item("Elmas Yüzük", 0, 120),
            new Item("Deri", 7, 8),

        };

            // Tüm şehirlere aynı eşyaları ekleyin
            foreach (var city in ŞehirlerListesi)
            {
                city.AvailableItems.AddRange(AllItems);
            }


            // Şehirlere özel eşyaları güncelleyin
            //Et'in şehirlere göre farkı
            #region ET 15 15
            AllItems[0].SetCityData("Güney Koyuncular Köyü",    100, 8);
            AllItems[0].SetCityData("Güney Liman Şehri",        5, 20);
            AllItems[0].SetCityData("Madenciler Köyü",          35, 17);
            AllItems[0].SetCityData("Balıkçılar Köyü",          10, 15);
            AllItems[0].SetCityData("Merkez Şehir",             20, 14);
            AllItems[0].SetCityData("Çiftçiler Köyü",           35, 14);
            AllItems[0].SetCityData("Kuzey Koyuncular Köyü",    100, 10);
            AllItems[0].SetCityData("Kuzey Liman Şehri",        5, 20);
            #endregion
            #region Balık 33 8
            AllItems[1].SetCityData("Güney Koyuncular Köyü",    35, 10);
            AllItems[1].SetCityData("Güney Liman Şehri",        95, 6);
            AllItems[1].SetCityData("Madenciler Köyü",          5, 15);
            AllItems[1].SetCityData("Balıkçılar Köyü",          100, 5);
            AllItems[1].SetCityData("Merkez Şehir",             25, 8);
            AllItems[1].SetCityData("Çiftçiler Köyü",           20, 12);
            AllItems[1].SetCityData("Kuzey Koyuncular Köyü",    20, 12);
            AllItems[1].SetCityData("Kuzey Liman Şehri",        85, 5);
            #endregion
            #region Tahıl 25 6
            AllItems[2].SetCityData("Güney Koyuncular Köyü",    55, 4);
            AllItems[2].SetCityData("Güney Liman Şehri",        15, 8);
            AllItems[2].SetCityData("Madenciler Köyü",          45, 8);
            AllItems[2].SetCityData("Balıkçılar Köyü",          15, 7);
            AllItems[2].SetCityData("Merkez Şehir",             45, 6);
            AllItems[2].SetCityData("Çiftçiler Köyü",           100, 3);
            AllItems[2].SetCityData("Kuzey Koyuncular Köyü",    65, 5);
            AllItems[2].SetCityData("Kuzey Liman Şehri",        10, 9);
            #endregion
            #region İçki 25 15 
            AllItems[3].SetCityData("Güney Koyuncular Köyü",    5, 25);
            AllItems[3].SetCityData("Güney Liman Şehri",        55, 10);
            AllItems[3].SetCityData("Madenciler Köyü",          2, 35);
            AllItems[3].SetCityData("Balıkçılar Köyü",          25, 14);
            AllItems[3].SetCityData("Merkez Şehir",             15, 20);
            AllItems[3].SetCityData("Çiftçiler Köyü",           10, 25);
            AllItems[3].SetCityData("Kuzey Koyuncular Köyü",    45, 13);
            AllItems[3].SetCityData("Kuzey Liman Şehri",        100, 8);
            #endregion
            #region Yün 20 10
            AllItems[4].SetCityData("Güney Koyuncular Köyü",    95, 3);
            AllItems[4].SetCityData("Güney Liman Şehri",        20, 10);
            AllItems[4].SetCityData("Madenciler Köyü",          5, 15);
            AllItems[4].SetCityData("Balıkçılar Köyü",          2, 16);
            AllItems[4].SetCityData("Merkez Şehir",             25, 9);
            AllItems[4].SetCityData("Çiftçiler Köyü",           10, 14);
            AllItems[4].SetCityData("Kuzey Koyuncular Köyü",    100, 2);
            AllItems[4].SetCityData("Kuzey Liman Şehri",        20, 10);
            #endregion
            #region Tuz 7, 15
            AllItems[5].SetCityData("Güney Koyuncular Köyü",    2, 17);
            AllItems[5].SetCityData("Güney Liman Şehri",        5, 16);
            AllItems[5].SetCityData("Madenciler Köyü",          95, 5);
            AllItems[5].SetCityData("Balıkçılar Köyü",          8, 14);
            AllItems[5].SetCityData("Merkez Şehir",             4, 16);
            AllItems[5].SetCityData("Çiftçiler Köyü",           1, 18);
            AllItems[5].SetCityData("Kuzey Koyuncular Köyü",    1, 20);
            AllItems[5].SetCityData("Kuzey Liman Şehri",        1, 25);
            #endregion
            #region Demir 10 20
            AllItems[6].SetCityData("Güney Koyuncular Köyü",    25, 17);
            AllItems[6].SetCityData("Güney Liman Şehri",        20, 18);
            AllItems[6].SetCityData("Madenciler Köyü",          85, 9);
            AllItems[6].SetCityData("Balıkçılar Köyü",          3, 17);
            AllItems[6].SetCityData("Merkez Şehir",             10, 20);
            AllItems[6].SetCityData("Çiftçiler Köyü",           2, 16);
            AllItems[6].SetCityData("Kuzey Koyuncular Köyü",    0, 10);
            AllItems[6].SetCityData("Kuzey Liman Şehri",        0, 40);
            #endregion
            #region Çömlek 18 8
            AllItems[7].SetCityData("Güney Koyuncular Köyü",    2, 12);
            AllItems[7].SetCityData("Güney Liman Şehri",        12, 18);
            AllItems[7].SetCityData("Madenciler Köyü",          45, 4);
            AllItems[7].SetCityData("Balıkçılar Köyü",          15, 9);
            AllItems[7].SetCityData("Merkez Şehir",             75, 5);
            AllItems[7].SetCityData("Çiftçiler Köyü",           15, 8);
            AllItems[7].SetCityData("Kuzey Koyuncular Köyü",    3, 17);
            AllItems[7].SetCityData("Kuzey Liman Şehri",        4, 20);
            #endregion
            #region Yağ 5 30
            AllItems[8].SetCityData("Güney Koyuncular Köyü",    0, 61);
            AllItems[8].SetCityData("Güney Liman Şehri",        0, 60);
            AllItems[8].SetCityData("Madenciler Köyü",          0, 32);
            AllItems[8].SetCityData("Balıkçılar Köyü",          1, 15);
            AllItems[8].SetCityData("Merkez Şehir",             3, 50);
            AllItems[8].SetCityData("Çiftçiler Köyü",           1, 44);
            AllItems[8].SetCityData("Kuzey Koyuncular Köyü",    2, 42);
            AllItems[8].SetCityData("Kuzey Liman Şehri",        10, 24);
            #endregion
            #region İpek 1 50
            AllItems[9].SetCityData("Güney Koyuncular Köyü",    1, 23);
            AllItems[9].SetCityData("Güney Liman Şehri",        10, 35);
            AllItems[9].SetCityData("Madenciler Köyü",          1, 40);
            AllItems[9].SetCityData("Balıkçılar Köyü",          1, 35);
            AllItems[9].SetCityData("Merkez Şehir",             2, 66);
            AllItems[9].SetCityData("Çiftçiler Köyü",           2, 25);
            AllItems[9].SetCityData("Kuzey Koyuncular Köyü",    1, 20);
            AllItems[9].SetCityData("Kuzey Liman Şehri",        3, 70);
            #endregion
            #region Baharat 7 35
            AllItems[10].SetCityData("Güney Koyuncular Köyü",    0, 60);
            AllItems[10].SetCityData("Güney Liman Şehri",        12, 31);
            AllItems[10].SetCityData("Madenciler Köyü",          2, 26);
            AllItems[10].SetCityData("Balıkçılar Köyü",          1, 38);
            AllItems[10].SetCityData("Merkez Şehir",             2, 50);
            AllItems[10].SetCityData("Çiftçiler Köyü",           1, 30);
            AllItems[10].SetCityData("Kuzey Koyuncular Köyü",    0, 35);
            AllItems[10].SetCityData("Kuzey Liman Şehri",        15, 27);
            #endregion
            #region Midye 5 5
            AllItems[11].SetCityData("Güney Koyuncular Köyü",    1, 10);
            AllItems[11].SetCityData("Güney Liman Şehri",        35, 3);
            AllItems[11].SetCityData("Madenciler Köyü",          0, 15);
            AllItems[11].SetCityData("Balıkçılar Köyü",          60, 3);
            AllItems[11].SetCityData("Merkez Şehir",             5, 7);
            AllItems[11].SetCityData("Çiftçiler Köyü",           0, 10);
            AllItems[11].SetCityData("Kuzey Koyuncular Köyü",    0, 5);
            AllItems[11].SetCityData("Kuzey Liman Şehri",        60, 2);
            #endregion
            #region Keten 10 20
            AllItems[12].SetCityData("Güney Koyuncular Köyü",    10, 18);
            AllItems[12].SetCityData("Güney Liman Şehri",        0, 25);
            AllItems[12].SetCityData("Madenciler Köyü",          2, 24);
            AllItems[12].SetCityData("Balıkçılar Köyü",          1, 26);
            AllItems[12].SetCityData("Merkez Şehir",             10, 17);
            AllItems[12].SetCityData("Çiftçiler Köyü",           15, 15);
            AllItems[12].SetCityData("Kuzey Koyuncular Köyü",    2, 22);
            AllItems[12].SetCityData("Kuzey Liman Şehri",        0, 30);
            #endregion
            #region Bal 3 25
            AllItems[13].SetCityData("Güney Koyuncular Köyü",    2, 26);
            AllItems[13].SetCityData("Güney Liman Şehri",        6, 18);
            AllItems[13].SetCityData("Madenciler Köyü",          1, 30);
            AllItems[13].SetCityData("Balıkçılar Köyü",          2, 28);
            AllItems[13].SetCityData("Merkez Şehir",             15, 15);
            AllItems[13].SetCityData("Çiftçiler Köyü",           3, 25);
            AllItems[13].SetCityData("Kuzey Koyuncular Köyü",    0, 30);
            AllItems[13].SetCityData("Kuzey Liman Şehri",        0, 45);
            #endregion
            #region Elmas 0 120
            AllItems[14].SetCityData("Güney Koyuncular Köyü",    0, 90);
            AllItems[14].SetCityData("Güney Liman Şehri",        0, 150);
            AllItems[14].SetCityData("Madenciler Köyü",          1, 45);
            AllItems[14].SetCityData("Balıkçılar Köyü",          0, 18);
            AllItems[14].SetCityData("Merkez Şehir",             2, 70);
            AllItems[14].SetCityData("Çiftçiler Köyü",           0, 13);
            AllItems[14].SetCityData("Kuzey Koyuncular Köyü",    0, 20);
            AllItems[14].SetCityData("Kuzey Liman Şehri",        0, 160);
            #endregion
            #region Deri 7 8
            AllItems[15].SetCityData("Güney Koyuncular Köyü",    25, 5);
            AllItems[15].SetCityData("Güney Liman Şehri",        7, 8);
            AllItems[15].SetCityData("Madenciler Köyü",          2, 10);
            AllItems[15].SetCityData("Balıkçılar Köyü",          0, 16);
            AllItems[15].SetCityData("Merkez Şehir",             3, 10);
            AllItems[15].SetCityData("Çiftçiler Köyü",           0, 13);
            AllItems[15].SetCityData("Kuzey Koyuncular Köyü",    35, 5);
            AllItems[15].SetCityData("Kuzey Liman Şehri",        7, 8);
            #endregion
            /*
            #region Boş
            AllItems[10].SetCityData("Güney Koyuncular Köyü",    0, 0);
            AllItems[10].SetCityData("Güney Liman Şehri",        0, 0);
            AllItems[10].SetCityData("Madenciler Köyü",          0, 0);
            AllItems[10].SetCityData("Balıkçılar Köyü",          0, 0);
            AllItems[10].SetCityData("Merkez Şehir",             0, 0);
            AllItems[10].SetCityData("Çiftçiler Köyü",           0, 0);
            AllItems[10].SetCityData("Kuzey Koyuncular Köyü",    0, 0);
            AllItems[10].SetCityData("Kuzey Liman Şehri",        0, 0);
            #endregion
            */
#endregion
        }

        public void Print(string istek)
        {

            int i = 0;
            if (istek == "Şehirler+Eşyalar")
            {
                foreach (var city in ŞehirlerListesi)
                {
                    Console.WriteLine($"{city.Name}");
                    foreach (var item in city.AvailableItems)
                    {
                        if (item.Name.Length <= 4)
                        {
                            Console.WriteLine($"- {item.Name} \t\t(Nadir: {item.GetFinalRarity(city.Name)}, \tFiyat: {item.GetFinalPrice(city.Name)} Altın)");
                        }
                        else
                        {
                            Console.WriteLine($"- {item.Name} \t(Nadir: {item.GetFinalRarity(city.Name)}, \tFiyat: {item.GetFinalPrice(city.Name)} Altın)");
                        }
                    }
                    Console.WriteLine();
                    Thread.Sleep(200);
                }
            }else if (istek == "Şehirler")
            {
                foreach (var city in ŞehirlerListesi)
                {
                    if (city.Name != "Harabeler")
                    {
                        Console.WriteLine($"{i}.{city.Name}");
                        Thread.Sleep(200);
                    }
                    i++;
                }
                Console.WriteLine();
                Thread.Sleep(200);
            }
            else if (istek == "Eşyalar")
            {
                foreach (var seçiliEşya in ŞehirlerListesi.SelectMany(city => city.AvailableItems).DistinctBy(item => item.Name))
                {
                    Console.WriteLine($"{seçiliEşya.Name}:");
                    foreach (var city in ŞehirlerListesi)
                    {
                        var cityItem = city.AvailableItems.FirstOrDefault(ci => ci.Name == seçiliEşya.Name);
                        if (cityItem != null)
                        {
                            Console.WriteLine($"{city.Name} şehrinde (Nadir: {cityItem.GetFinalRarity(city.Name)}, Fiyat: {cityItem.GetFinalPrice(city.Name)} Altın)");
                        }
                    }
                    Console.WriteLine();
                    Thread.Sleep(200);
                }
            }

        }




    }
}
