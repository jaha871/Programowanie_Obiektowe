using System;
using System.Collections.Generic;
using System.Linq;

namespace lab3
{
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
    class Program
    {
        int[] Marks = new int[6] { 1, 2, 3, 4, 5, 6 };
        
        public static void Main(string[] args)
        {
             
            List<User> users = new List<User>()
            {
                new User {Name = "Adam" , Role = "Admin" , Age = 34},
                new User {Name = "Bucho" , Role = "Moderator", Age = 27},
                new User {Name = "Adi" , Role = "Teacher" , Age = 31},
                new User {Name = "Ewcia" , Role = "Admin" , Age = 42},
                new User {Name = "Darek" , Role = "Student" , Age = 22, Marks = 1},
                new User {Name = "Adek" , Role = "Student" , Age = 21, Marks = 3},
                new User {Name = "Marek" , Role = "Student" , Age = 20, Marks = 2 },
                new User {Name = "Janek" , Role = "Student" , Age = 18, Marks = 5 },
                new User {Name = "Zbyszek" , Role = "Student" , Age = 19, Marks = 4}
            };
            //1 Zliczanie ilości 
           Console.WriteLine("Jest " + users.Count() + " użytkowników");

            //Console.WriteLine((from User in users select User).Count());
            //2 Wypisanie imion 
            Console.WriteLine(" ");
            List<string> names_1 = users.Select(User => User.Name).ToList();
            //List<string> names_2 = (from User in users select User.Name).ToList();
            foreach (string name in names_1)
                Console.WriteLine("Dane imiona to " + name);


            //3 Sortowanie imion
            Console.WriteLine(" ");
            //foreach (string name in names_2)
            //Console.WriteLine(name);
            //List<User> users_1 = users.OrderBy(User => User.Name).ToList();
            List<User> users_2 = (from user in users
                                  orderby user.Name
                                  select user).ToList();
            foreach (User user in users_2)
                Console.WriteLine("Posortowane imiona to " + user.Name);

            //4 Wypisywanie wszystkich ról
            Console.WriteLine(" ");

            List<string> roles1 = users.Select(User => User.Role).ToList();
            IEnumerable<string> roles = roles1.Distinct();
            foreach (string Role in roles)
                Console.WriteLine("Wszystkie Role to " + Role);

            //5 Grupowanie wszystkich ról
            Console.WriteLine(" ");

            IEnumerable<IGrouping<string, string>> query =
             users.GroupBy(user => user.Role, user => user.Name);
            Console.WriteLine("Group by role");
            foreach (IGrouping<string, string> petGroup in query)
            {

                foreach (string name in petGroup)
                    Console.WriteLine("  {0}", name);
            }
            //6 
            Console.WriteLine(" ");



        }
    }
}
