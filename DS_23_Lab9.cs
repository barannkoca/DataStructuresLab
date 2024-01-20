using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class Program
    {
        const double INF = Double.PositiveInfinity;
        
        static void Main(string[] args)
        {
            
            String[] iller = { "Ankara", "İstanbul", "İzmir", "Eskişehir", "Kayseri" };
            double[,] adjMatrix =
            {
                {INF,5,3,INF,2 },
                {INF,INF,2,6,INF },
                {INF,1,INF,2,INF },
                {INF,INF,INF,INF,INF },
                {INF,6,10,4,INF }
            };
            Console.Write($"{' ',10}");
            for (int i = 0; i < iller.Length; i++)
            {
                Console.Write($"{iller[i],10}"); //String Interpolation ifadesi 10 değeri hizalamak için kullanılıyor.
                //Ayrıntılı bilgi: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            }
            Console.Write("\n");
            for (int i = 0; i < iller.Length; i++)
            {
                Console.Write($"{iller[i],-10}");
                for (int j = 0; j < iller.Length; j++)
                {
                    string val = adjMatrix[i, j] == INF ? "#" : adjMatrix[i, j].ToString();
                    Console.Write($"{val,10}");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            Console.Write("Bir köşe numarası giriniz:");
            int koseNumarasi = int.Parse(Console.ReadLine());
            int gidenKenarSay = 0, gelenKenarSay = 0;
            Console.WriteLine($"[{koseNumarasi}] {iller[koseNumarasi]} Gelen-Giden Kenarlar:");
            for (int i = 0; i < iller.Length; i++)
            {
                if (adjMatrix[koseNumarasi,i] != INF)
                {
                    Console.WriteLine($"Giden Kenar: [{i}]{iller[i]}\tMaliyet: {adjMatrix[koseNumarasi,i]}");
                    gidenKenarSay++;
                }
                if (adjMatrix[i, koseNumarasi] != INF)
                {
                    Console.WriteLine($"Gelen Kenar: [{i}]{iller[i]}\tMaliyet: {adjMatrix[i,koseNumarasi]}");
                    gelenKenarSay++;
                }
            }
            Console.WriteLine($"Giden Kenar Sayısı: {gidenKenarSay}");
            Console.WriteLine($"Gelen Kenar Sayısı: {gelenKenarSay}");
            Console.WriteLine();
            printMinCostOutgoingEdges(iller,adjMatrix);
            Console.Read();          
        }
        static public void printMinCostOutgoingEdges(string[] names, double[,] adjMatrix)
        {
            Console.WriteLine("Minimum Maliyetli Giden Kenarlar:");
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                int minIndex = 0;
                for (int j = 1; j < adjMatrix.GetLength(0); j++)
                {
                    if(adjMatrix[i, j] != INF && adjMatrix[i, j] < adjMatrix[i, minIndex])
                    {
                        minIndex = j;
                    }
                }
                if(adjMatrix[i, minIndex] != INF)
                    Console.WriteLine($"[{i}]{names[i]} için minimum maliyetli giden kenar: [{minIndex}]{names[minIndex]}\tMaliyet:{adjMatrix[i,minIndex]}");
            }
        }
    }
}
