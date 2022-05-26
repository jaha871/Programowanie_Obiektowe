using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;
using System.Text;


    public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    private static void SaveXML()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(User));
    }
    public static void Main()
    {
        var user = new User
        {
            Id = 1,
            Name = "Jan Kowalski",
            Age = 30
        };
        XmlSerializer serializer = new XmlSerializer(typeof(User));
        using (MemoryStream s = new MemoryStream())
        {
            serializer.Serialize(s, user);
            string xml = Encoding.UTF8.GetString(s.ToArray());
            Console.WriteLine(xml);
        }
    }
} 
}

