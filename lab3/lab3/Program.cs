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
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
    class Program
    {
        
        
        
        public static void Main(string[] args)
        {
            int[] Marks = new int[6] { 1, 2, 3, 4, 5, 6 };

            List<User> users = new List<User>()
            {
                new User {Name = "Adam" , Role = "Admin" , Age = 34},
                new User {Name = "Bucho" , Role = "Moderator", Age = 27},
                new User {Name = "Adi" , Role = "Teacher" , Age = 31},
                new User {Name = "Ewcia" , Role = "Admin" , Age = 42},
                new User {Name = "Darek" , Role = "Student" , Age = 22, Marks = 1 },
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

           
            //8
            var Najlepsza = (from User user in users
                        where user.Marks != null && user.Marks.Length > 0
                        orderby user.Marks.Max() descending
                        select user.Marks.Max());
            Console.Write("Zadanie 8 : ");
            foreach (var user in Najlepsza.Take(1))
            {
                Console.WriteLine(user);
            }
            //9
            var najgorsza = users.Where(user => user.Marks is not null
            && user.Marks.Length > 0).Select(user => user.Marks.Min()).Min();
            var Najgorsza1 = (from user in users
                         where user.Marks is not null
                  && user.Marks.Length > 0
                         select user.Marks.Min()).Min();
            Console.WriteLine("Zadanie 9 :" + najgorsza);
            //10
            var Maro = from User user in users
                        where user.Marks != null && user.Marks.Length > 0
                        orderby user.Marks.Average() descending
                        select user.Name;
            var Maro1 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Average()).Select(user => user.Name);
            Console.Write("Zadanie 10: ");
            foreach (var user in Maro.Take(1))
            {
                Console.WriteLine(user);
            }
            //11
            var LowMarks = from User user in users
                           where user.Marks != null
                           orderby user.Marks.Length ascending
                           select user.Name;
            var LowMarks1 = users.Where(user => user.Marks != null).OrderByDescending(user => -user.Marks.Length).Select(user => user);
            Console.Write("Zadanie 11: ");
            foreach (var user in LowMarks.Take(1))
            {
                Console.WriteLine(user);
            }
            //12
            var MoreMarks = from User user in users
                           where user.Marks != null
                           orderby user.Marks.Length descending
                           select user.Name;
            var MoreMarks2 = users.Where(user => user.Marks != null).OrderByDescending(user => user.Marks.Length).Select(user => user);
            Console.Write("Zadanie 12: ");
            foreach (var user in MoreMarks.Take(1))
            {
                Console.WriteLine(user);
            }
            //13
            var Marek = from User user in users
                         where user.Marks != null && user.Marks.Length > 0
                         orderby user.Marks.Average() descending
                         select user.Name;
            var Marek2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Average()).Select(user => user.Name);
            Console.Write("Zadanie 13 ");
            foreach (var user in Marek)
            {
                Console.Write(user + " ");
            }
              }
    }
}
