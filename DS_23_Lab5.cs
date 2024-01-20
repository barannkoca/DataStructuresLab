using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Musteri
    {
        public String musteriAdi;
        public int urunSayisi;
        public Musteri(string musteriAdi, int urunSayisi)
        {
            this.musteriAdi = musteriAdi;
            this.urunSayisi = urunSayisi;
        }
    }
    public class Kuyruk<T>
    {
        private List<T> genericList;

        public Kuyruk()
        {
            this.genericList = new List<T>();
        }

        public void Ekle(T item)
        {
            this.genericList.Add(item);
        }
        public T Sil()
        { 
            T item = this.genericList[0];
            this.genericList.RemoveAt(0);
            return item;
        }
        public int ElemanSayisi() { return this.genericList.Count; }

        public bool BosMu() { return ElemanSayisi() == 0; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kuyruk<Musteri> musteriKuyrugu = new Kuyruk<Musteri>();
            musteriKuyrugu.Ekle(new Musteri("Selim", 10));
            musteriKuyrugu.Ekle(new Musteri("Canan", 20));
            musteriKuyrugu.Ekle(new Musteri("Aykut", 13));
            musteriKuyrugu.Ekle(new Musteri("Cemal", 4));

            int beklemeSuresi = 0;

            while (!musteriKuyrugu.BosMu())
            {
                Musteri m = musteriKuyrugu.Sil();
                Console.WriteLine($"Müşteri Adı: {m.musteriAdi}, Bekleme Süresi: {beklemeSuresi}s");
                beklemeSuresi += m.urunSayisi;                
            }
            Console.WriteLine($"Toplam bekleme süresi: {beklemeSuresi}");

            Console.Write("\n\nİkinci Durum:\n");
            Queue<Musteri> queue = new Queue<Musteri>();
            queue.Enqueue(new Musteri("Cemal", 4));
            queue.Enqueue(new Musteri("Selim", 10));
            queue.Enqueue(new Musteri("Aykut", 13));
            queue.Enqueue(new Musteri("Canan", 20));

            beklemeSuresi = 0;
            while (queue.Count> 0)
            {
                Musteri m = queue.Dequeue();
                Console.WriteLine($"Müşteri Adı: {m.musteriAdi}, Bekleme Süresi: {beklemeSuresi}s");
                beklemeSuresi += m.urunSayisi;
            }
            Console.WriteLine($"Toplam bekleme süresi: {beklemeSuresi}");
            Console.Read();
        }             

    }
}
