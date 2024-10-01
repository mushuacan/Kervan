using Kervan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

// İki farklı listeyi içeren sınıf
public class OyunVerileri
{
    public List<string> Kazanımlar { get; set; }
    public List<string> BitirilenSonlar { get; set; }
}

public class KazanımlarVeSonlar
{
    private OyunVerileri oyunVerileri;
    private string dosyaYolu = "SaveData//Kervan.kazanımlar.xml"; // Verileri saklayacağımız dosya

    public KazanımlarVeSonlar()
    {
        VerileriYükle();
    }

    // Kazanımları listeleme metodu (alfabetik sırada)
    public void KazanımlarıListele()
    {
        Console.WriteLine("Kayıtlı Kazanımlar (Alfabetik Sırada):");

        oyunVerileri.Kazanımlar.Sort();

        foreach (var kazanım in oyunVerileri.Kazanımlar)
        {
            Console.WriteLine($"- {Language.GetText(kazanım)}");
        }
    }

    // Bitirilen sonları listeleme metodu (alfabetik sırada)
    public void BitirilenSonlarıListele()
    {
        Console.WriteLine("Bitirilen Sonlar (Alfabetik Sırada):");
        Thread.Sleep(1400);

        oyunVerileri.BitirilenSonlar.Sort();

        foreach (var son in oyunVerileri.BitirilenSonlar)
        {
            Console.WriteLine($"- {Language.GetText(son)}");
            Thread.Sleep(300);
        }
        Thread.Sleep(3000);
    }

    public void TümKazanımVeSonlarıListele()
    {

    }

    // Yeni kazanım ekleme metodu
    public void YeniKazanımEkle(string yeniKazanım)
    {
        if (oyunVerileri.Kazanımlar.Contains(yeniKazanım))
        {
            Console.WriteLine($"Kazanım zaten mevcut: {yeniKazanım}");
        }
        else
        {
            oyunVerileri.Kazanımlar.Add(yeniKazanım);
            Console.WriteLine("Kazanım başarıyla eklendi.");
            VerileriKaydet(); // Yeni kazanımı kaydet
        }
    }

    // Yeni bitirilen son ekleme metodu
    public void YeniBitirilenSonEkle(string yeniSon)
    {
        if (oyunVerileri.BitirilenSonlar.Contains(yeniSon))
        {
            Console.WriteLine($"Son zaten bitirildi: {yeniSon}");
        }
        else
        {
            oyunVerileri.BitirilenSonlar.Add(yeniSon);
            Console.WriteLine("Son başarıyla eklendi:" + Language.GetText(yeniSon));
            VerileriKaydet(); // Yeni sonu kaydet
        }
    }

    // Verileri XML formatında kaydetme
    private void VerileriKaydet()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(OyunVerileri));
        using (StreamWriter writer = new StreamWriter(dosyaYolu))
        {
            serializer.Serialize(writer, oyunVerileri);
        }
    }

    // Verileri XML dosyasından yükleme
    private void VerileriYükle()
    {
        if (File.Exists(dosyaYolu))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(OyunVerileri));
            using (StreamReader reader = new StreamReader(dosyaYolu))
            {
                oyunVerileri = (OyunVerileri)serializer.Deserialize(reader);
            }
        }
        else
        {
            // Eğer dosya yoksa iki boş liste oluştur
            oyunVerileri = new OyunVerileri
            {
                Kazanımlar = new List<string>(),
                BitirilenSonlar = new List<string>()
            };
        }
    }
}
