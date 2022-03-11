using System;

namespace Lab_01
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        class ulamek
        {
            public int Licznik;
            public int Mianownik;
            private static int licznik;
            private static int mianownik;
            // Prywatne zmienne Licznik i Mianownik 
            public ulamek()
            {

            }
            //Konstruktor domyślny bez argumentów
            public ulamek(int Licznik, int Mianownik, string Uczen)
            {
                this.Licznik = Licznik;
                this.Mianownik = Mianownik;
            }
            //Konstruktor domyślny z argumentem 
            public ulamek(ulamek licznik, ulamek mianownik, ulamek student)
            {
                this.Licznik = ulamek.licznik;
            }
            //Konstruktor kopiujący
            public class Student
            {
                private string name;

                public Student(String name)
                {
                    this.name = name;

                }


                public override string ToString()
                {
                    return $"Student: {this.name}.";
                }
            }
            //Metoda ToString
        }
        public class Uczen : IEquatable <Uczen>
        {
            private string imie;
            public Uczen(string imie)
            {
                this.imie = imie;
            }
            public bool Equals(Uczen other)
            {
                if (other == null) return false;
                if (other == this) return true;
                return object.Equals(this.imie, other.imie);
             }
            //Equatable
            //IEquatable
        }
    }
}
