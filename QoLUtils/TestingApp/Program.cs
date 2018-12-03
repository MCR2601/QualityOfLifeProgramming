using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QoLUtils.MenuUtils;


namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleMenu menu;
            menu = new SimpleMenu.SimpleMenuBuilder("Test Menu")
                .AddTopic("Something", DoSomething, SimpleMenu.InputType.None)
                .AddTopic("Number", PrintANumber, SimpleMenu.InputType.Int)
                .AddTopic("String", PrintString, SimpleMenu.InputType.Line)
                .AddTopic("Multiply by 4", Multiply, SimpleMenu.InputType.Int, 4)
                .AddTopic("Multiply by 5", Multiply, SimpleMenu.InputType.Int, 5)
                .AddTopic("Multiply by 3",Multiply, SimpleMenu.InputType.Int, 3)
                .AddTopic("Beeeep",LALALALA,SimpleMenu.InputType.None)
                .EnableQuickInput()
                .Build();

            while (true)
            {
                menu.CallMenu();
                Console.ReadKey();
            }

        }
        public static void LALALALA(object nix, object data)
        {
            Console.Beep();
            Console.WriteLine("BEEEEEEEEP");
        }
        public static void DoSomething(object nix, object data)
        {
            Console.WriteLine("did something");
        }
        public static void PrintANumber(object num, object data)
        {
            Console.WriteLine("Number "+num);
        }
        public static void PrintString(object line, object data)
        {
            Console.WriteLine("The line " + line);
        }
        public static void Multiply(object num, object other)
        {
            Console.WriteLine((int)num * (int)other);
        }
    }
}
