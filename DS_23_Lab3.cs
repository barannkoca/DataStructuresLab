using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_23_Lab3
{
    class ŞehirÇifti
    {
        public string[] şehirAdları = new string[2];
        public int puan;
    }

    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            string[] şehirler = { "İstanbul", "Roma", "Paris", "Madrid", "New York", "Moskova", "Londra", "Pekin" };

            string[] seyahatPlanı = seyahatPlanıOlustur(şehirler, 4, random);
            Console.WriteLine("Seyahat Planı:");
            foreach (string s in seyahatPlanı)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();


            ŞehirÇifti[] şehirÇiftleri = şehirÇiftiKombinasyonlariOlustur(seyahatPlanı);
            şehirÇiftleriniEkranaListele(şehirÇiftleri);

            Console.WriteLine();

            şehirÇiftleriniEkranaListele(şehirÇiftleri, "İstanbul");

            Console.ReadKey();
        }

        static string[] seyahatPlanıOlustur(string[] şehirler, int şehirBoyutu, Random random)
        {
            string[] şehirlerKopya = new string[şehirler.Length];
            Array.Copy(şehirler, şehirlerKopya, şehirler.Length);

            string[] seyahatPlanı = new string[şehirBoyutu];
            int maxValue = şehirlerKopya.Length;

            for (int i = 0; i < şehirBoyutu; i++)
            {
                int randomNumber = random.Next(0, maxValue);
                seyahatPlanı[i] = şehirlerKopya[randomNumber];

                for (int j = randomNumber; j < şehirlerKopya.Length - 1; j++)
                {
                    şehirlerKopya[j] = şehirlerKopya[j + 1];
                }

                maxValue--;
            }


            return seyahatPlanı;
        }

        static ŞehirÇifti[] şehirÇiftiKombinasyonlariOlustur(string[] seyahatPlanı)
        {
            ŞehirÇifti[] şehirÇiftiDizisi = new ŞehirÇifti[seyahatPlanı.Length * (seyahatPlanı.Length - 1) / 2];
            int index = 0;

            for (int i = 0; i < seyahatPlanı.Length - 1; i++)
            {
                for (int j = i + 1; j < seyahatPlanı.Length; j++)
                {
                    ŞehirÇifti şehirÇifti = new ŞehirÇifti();
                    şehirÇifti.şehirAdları[0] = seyahatPlanı[i];
                    şehirÇifti.şehirAdları[1] = seyahatPlanı[j];
                    şehirÇifti.puan = random.Next(0, 101); ;

                    şehirÇiftiDizisi[index++] = şehirÇifti;
                }
            }

            return şehirÇiftiDizisi;
        }

        private static void şehirÇiftleriniEkranaListele(ŞehirÇifti[] şehirÇiftleri)
        {
            Console.WriteLine("Şehir çiftleri:");
            foreach (ŞehirÇifti ic in şehirÇiftleri)
            {
                Console.Write("Şehir Adi 1: {0}\nŞehir Adi 2: {1}\nPuan: {2}\n", ic.şehirAdları[0], ic.şehirAdları[1], ic.puan);
                Console.WriteLine();
            }
        }

        private static void şehirÇiftleriniEkranaListele(ŞehirÇifti[] şehirÇiftleri, string aranan)
        {
            Console.WriteLine("Şehir çiftleri ({0} icerenler):", aranan);
            foreach (ŞehirÇifti ic in şehirÇiftleri)
            {
                if (ic.şehirAdları[0].Equals(aranan) || ic.şehirAdları[1].Equals(aranan))
                {
                    Console.Write("Şehir Adi 1: {0}\nŞehir Adi 2: {1}\nPuan: {2}\n", ic.şehirAdları[0], ic.şehirAdları[1], ic.puan);
                    Console.WriteLine();
                }
            }
        }
    }
}

