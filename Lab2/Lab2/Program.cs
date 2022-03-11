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

            public ulamek()
            {

            }
           public ulamek(int Licznik, int Mianownik, string Uczen)
            {
               
                this.Licznik =Licznik;
                
                                  
            }
            public ulamek ( ulamek licznik , ulamek mianownik , ulamek student)
            {
                this.Licznik = ulamek.licznik;
            }

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

        }            
    }
}
