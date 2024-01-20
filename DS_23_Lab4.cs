using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLab4
{
    class İlceSınıfı
    {
        public string İlçeAdı;
        public int merkezdenUzaklık;

        public İlceSınıfı(string ilceadı, int merkezdenuzaklık)
        {
            this.İlçeAdı = ilceadı;
            this.merkezdenUzaklık = merkezdenuzaklık;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] ilçeAdı = { "Balçova", "Bornova", "Buca", "Çiğli", "Gaziemir", "Güzelbahçe", "Karşıyaka", "Konak", "Narlıdere", "Aliağa", "Bayındır", "Bergama", "Beydağ", "Çeşme", "Dikili", "Foça", "Karaburun", "Kemalpaşa", "Kınık", "Kiraz", "Menderes", "Menemen", "Ödemiş", "Seferihisar", "Selçuk", "Tire", "Torbalı", "Urla" };

            int[] merkezdenUzaklık = { 14, 4, 10, 11, 8, 30, 6, 0, 17, 53, 78, 102, 141, 88, 105, 64, 107, 24, 119, 142, 23, 29, 113, 52, 76, 84, 46, 42 };
            ArrayList Arrayliste = new ArrayList();
            int sayac = 0;
            int sayac2 = 0;
            İlceSınıfı ilcesınıfı;

            List<İlceSınıfı> genericListe;
            while (sayac < ilçeAdı.Length)
            {
                genericListe = new List<İlceSınıfı>();
                int genericListeLength = (int)Math.Pow(2, sayac2);
                for (int i = 0; i < genericListeLength; i++)
                {
                    ilcesınıfı = new İlceSınıfı(ilçeAdı[sayac], merkezdenUzaklık[sayac]);
                    genericListe.Add(ilcesınıfı);
                    sayac++;

                    if (sayac == ilçeAdı.Length)
                        break;
                }
                Arrayliste.Add(genericListe);
                sayac2++;
            }
            foreach (List<İlceSınıfı> item in Arrayliste)
            {
                foreach (İlceSınıfı item1 in item)
                {
                    Console.WriteLine("{0}, {1}", item1.İlçeAdı, item1.merkezdenUzaklık);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
