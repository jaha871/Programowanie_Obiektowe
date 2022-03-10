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
            private int Licznik;
            private int Mianownik;

            static void BezArgumentu()
            {

            }
            static void ZArgumentem(int Licznik, int Mianownik, string Uczen)
            {
                                  
            }
            public void Kopiujacy(int Licznik,int Mianownik)
            {
                this.Licznik = Licznik;
                this.Mianownik = Mianownik;
            }
            public class student
            {
                private string name;

                    public student(String name)
                {
                    this.name = name;
                }


                public override string ToString()
                {
                    return $"Student: {this.name}.";
                }
            }
        
        }
    }
}
