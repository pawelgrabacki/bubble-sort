using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gr7Lab1
{
    class Ulamek : IComparable<Ulamek>
    {
        public int licznik;
        public int mianownik;

        public Ulamek(int inLicznik, int inMianownik)
        {
            if (inMianownik == 0)
                throw new ArgumentException("Mianownik nie może być zerem!");

            licznik = inLicznik;
            mianownik = inMianownik;
        }

        public override string ToString()
        {
            return licznik + "/" + mianownik;
        }

        public static Ulamek operator *(Ulamek a, Ulamek b)
        {
            return new Ulamek(a.licznik * b.licznik, a.mianownik * b.mianownik);
        }

        public static bool operator >(Ulamek a, Ulamek b)
        {
            return a.licznik * b.mianownik > b.licznik * a.mianownik;
        }

        public static bool operator <(Ulamek a, Ulamek b)
        {
            return a.licznik * b.mianownik < b.licznik * a.mianownik;
        }

        public static explicit operator double(Ulamek a)
        {
            return (double)a.licznik / a.mianownik;
        }

        public int CompareTo(Ulamek other)
        {
            if (this > other) return 1;
            if (this < other) return -1;
            return 0;
        }
    }

    class Program
    {
        // Manual bubble sort for Ulamek array
        static void BubbleSort(Ulamek[] array)
        {
            int n = array.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        // Swap
                        Ulamek temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        swapped = true;
                    }
                }

                if (!swapped)
                    break;
            }
        }

        static void Main(string[] args)
        {
            Ulamek[] tablica = {
                new Ulamek(1, 7),
                new Ulamek(6, 7),
                new Ulamek(3, 7),
                new Ulamek(2, 7)
            };

            Console.WriteLine("Tablica przed sortowaniem:");
            foreach (Ulamek u in tablica)
            {
                Console.WriteLine(u);
            }

            // Use bubble sort instead of Array.Sort
            BubbleSort(tablica);

            Console.WriteLine("Tablica po sortowaniu (bubble sort):");
            foreach (Ulamek u in tablica)
            {
                Console.WriteLine(u);
            }
        }
    }
}