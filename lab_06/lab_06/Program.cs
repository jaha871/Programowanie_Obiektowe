class Program
{
    public static void Main(string[] args)
    {

        List<User> users = GetUsers();
        //1
        Console.WriteLine("1.Lista rekordów" + users.Count());
        Console.WriteLine((from user in users select user).Count());

        //2
        List<string> name_1 = users.Select(user => user.Name).ToList();
        List<string> name_2 = (from user in users select user.Name).ToList();
        Console.WriteLine("2.Lista nazw użytkowników");
        foreach (string name in name_1)
            Console.WriteLine(name);

        //3
        List<User> users_1 = users.OrderBy(User => User.Name).ToList();
        List<User> users_2 = (from user in users orderby user.Name select user).ToList();
        Console.WriteLine("3.Posortowane po nazwie");
        foreach (User user in users_1)

            Console.WriteLine(user.Name);

        //4
        List<string> role = (from user in users select user.Role).ToList();
        IEnumerable<string> roles = role.Distinct();
        Console.WriteLine("4.Lista ról: ");
        foreach (string name in roles)
            Console.WriteLine(name);

        //5

        IEnumerable<IGrouping<string, string>> query =
        users.GroupBy(user => user.Role, user => user.Name);
        Console.WriteLine("5.Group by role (celina, grażyna to admini)");
        foreach (IGrouping<string, string> petGroup in query)
        {

            foreach (string name in petGroup)
                Console.WriteLine("  {0}", name);
        }

        //6

        var ilosc = (from User user in users
                     where user.Marks != null && user.Marks.Length > 0
                     select user).Count();
        var ilosc2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).Select(user => user).Count();
        Console.WriteLine("6.Ilość rekordów, dla których podano oceny (nie null i więcej niż 0) : " + ilosc);

        //7

        //8
        var najl = (from User user in users
                    where user.Marks != null && user.Marks.Length > 0
                    orderby user.Marks.Max() descending
                    select user.Marks.Max());
        Console.Write("8.Najlepsza ocena to: ");
        foreach (var user in najl.Take(1))
        {
            Console.WriteLine(user);
        }
        //9
        var najg = users.Where(user => user.Marks is not null
        && user.Marks.Length > 0).Select(user => user.Marks.Min()).Min();

        var najg2 = (from user in users
                     where user.Marks is not null
              && user.Marks.Length > 0
                     select user.Marks.Min()).Min();
        Console.WriteLine("9.Najgorsza ocena to : " + najg);
        //10
        var kujon = from User user in users
                    where user.Marks != null && user.Marks.Length > 0
                    orderby user.Marks.Average() descending
                    select user.Name;
        var kujon2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Average()).Select(user => user.Name);
        Console.Write("10,Najlepszy uczen to : ");
        foreach (var user in kujon.Take(1))
        {
            Console.WriteLine(user);
        }
        //11
        var najmocen = from User user in users
                       where user.Marks != null
                       orderby user.Marks.Length ascending
                       select user.Name;
        var najmocen2 = users.Where(user => user.Marks != null).OrderByDescending(user => -user.Marks.Length).Select(user => user);
        Console.Write("11.Najmniej ocen ma: ");
        foreach (var user in najmocen.Take(1))
        {
            Console.WriteLine(user);
        }
        //12
        var najwocen = from User user in users
                       where user.Marks != null
                       orderby user.Marks.Length descending
                       select user.Name;
        var najwocen2 = users.Where(user => user.Marks != null).OrderByDescending(user => user.Marks.Length).Select(user => user);
        Console.Write("12.Najwiecej ocen ma: ");
        foreach (var user in najwocen.Take(1))
        {
            Console.WriteLine(user);
        }
        //13
        var kujony = from User user in users
                     where user.Marks != null && user.Marks.Length > 0
                     orderby user.Marks.Average() descending
                     select user.Name;
        var kujony2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Average()).Select(user => user.Name);
        Console.Write("13.Studenci posortowani od najlepszego: ");
        foreach (var user in kujony)
        {
            Console.Write(user + ",");
        }
        //16
        var srednia = (from User user in users
                       where user.Marks != null && user.Marks.Length > 0
                       select user.Marks.Average()).Average();
        Console.WriteLine(" ");
        Console.Write("16.Srednia wszystkich studentów to: " + srednia);
        //18
        var najn = from user in users
                   orderby user.CreatedAt descending
                   select user;
        Console.WriteLine(" ");
        Console.Write("18.Najnowszy uczen to: " );

    }

    private static List<User> GetUsers()
    {
        return new List<User>()
            {

                new User {Name = "Bartek", Role = "Moderator", Marks = null, CreatedAt= new DateTime(2001, 4, 25)},
                new User {Name = "Celina", Role = "Admin", Marks = null, CreatedAt= new DateTime(2002, 3, 24)},
                new User {Name = "Adam", Role = "Teacher", Marks = null, CreatedAt= new DateTime(2002, 1, 20)},
                new User {Name = "Grażyna", Role = "Admin", Marks = null, CreatedAt= new DateTime(1999, 5, 10)},
                new User {Name = "Darek", Role = "Student", Marks = new int[]{1,6, 5, 5}, CreatedAt= new DateTime(1998, 6, 11)},
                new User {Name = "Bartek", Role = "Student", Marks = new int[]{1,1, 3, 2}, CreatedAt= new DateTime(1997, 4, 28)},
                new User {Name = "Janek", Role = "Student", Marks = new int[]{4,4, 3, 1}, CreatedAt= new DateTime(1996, 12, 24)},
                new User {Name = "Zosia", Role = "Student", Marks = new int[]{8,5, 5, 5}, CreatedAt= new DateTime(1995, 12, 22)},
                new User {Name = "Basia", Role = "Student", Marks = new int[]{6,5, 4, 3,6, 7,8}, CreatedAt= new DateTime(1994, 10, 11)}
            };
    }
}
public class User
{
    public string Name { get; set; }
    public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
    public int Age { get; set; }
    public int[]? Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
    public DateTime? CreatedAt { get; set; }
    public DateTime? RemovedAt { get; set; }
}

