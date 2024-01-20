using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_19_Lab2
{
    class Program
    {
        static int[] topla(int[,] m)
        {
            int[] dizi = new int[m.GetLength(1)];
            int nRow = m.GetLength(0);
            int nCol = m.GetLength(1);
            int orta = nRow / 2;

            for (int j = 0; j <= orta; j++)
            {
                int top = 0;
                for (int i = orta - j; i <= orta + j; i++)
                {
                    top += m[i, j];

                }
                dizi[j] = top;
            }

            for (int j = nCol - 1; j > orta; j--)
            {
                int top = 0;
                for (int i = orta - (nCol - 1 - j); i <= orta + (nCol - 1 - j); i++)
                {
                    top += m[i, j];

                }
                dizi[j] = top;
            }


            return dizi;

        }
        static void Main(string[] args)
        {
            int[,] matris = { { 5, 4, 3, 2, 1 }, { 1, 3, 4, 6, 5 }, { 6, 3, 2, 1, 0 }, { 2, 5, 7, 11, 20 }, { 13, 17, 19, 23, 25 } };
            int[] sonuc = topla(matris);
            for (int i = 0; i < matris.GetLength(1); i++)
            {

                Console.WriteLine(sonuc[i]);
            }

            Console.ReadKey();
        }
    }
}

