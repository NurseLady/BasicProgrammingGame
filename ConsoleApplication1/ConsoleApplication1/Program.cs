using Newtonsoft.Json;
using System;
using System.IO;
 
namespace Question2457815
{
    public class MyClass
    {
        public int number;
        public bool flag;
        [JsonIgnore]
        public Action action;
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass() { number = 123, flag = true, action = () => { Console.WriteLine("Hello, world!"); } };
 
            var o = new JsonSerializer();
            var sw = new StringWriter();
 
            o.Serialize(sw, obj);
            var str = sw.ToString();
            Console.WriteLine(str);
            var obj2 = (MyClass)o.Deserialize(new StringReader(str), typeof(MyClass));
            Console.WriteLine($"{obj2.number} {obj2.flag} {obj2.action}");
            Console.ReadKey();
        }
    }
}