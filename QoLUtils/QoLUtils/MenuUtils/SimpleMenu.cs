using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoLUtils.MenuUtils
{
    public class SimpleMenu
    {
        string Name;

        bool quickInput = false;

        List<MenuTopic> Topics = new List<MenuTopic>();

        private SimpleMenu(string Name)
        {
            this.Name = Name;
        }

        public void CallMenu()
        {   
            string input;
            int output;
            do
            {
                Console.Clear();
                Console.WriteLine("*** " + Name + " ***");
                for (int i = 0; i < Topics.Count; i++)
                {
                    Console.WriteLine(i + ")\t" + Topics[i].TopicName);                    
                }
                if (Topics.Count<=10 && quickInput)
                {
                    input = Console.ReadKey().KeyChar.ToString();
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine();
                }
                else
                {
                    input = Console.ReadLine();
                }             
            } while (!int.TryParse(input, out output));
            MenuTopic topic = Topics[output];
            topic.Call();
        }


        public class SimpleMenuBuilder
        {
            SimpleMenu menu;

            public SimpleMenuBuilder(string MenuName)
            {
                menu = new SimpleMenu(MenuName);
            }

            public SimpleMenuBuilder AddTopic(string name, MenuCallable c, InputType i, object d = null)
            {
                menu.Topics.Add(new MenuTopic(name, c, i, d));
                return this;
            }

            public SimpleMenuBuilder EnableQuickInput(bool tick = true)
            {
                menu.quickInput = tick;
                return this;
            }
            

            public SimpleMenu Build()
            {
                return menu;
            }
        }
        public enum InputType
        {
            None,
            Int,
            Line
        }
        private class MenuTopic
        {
            public string TopicName;
            public MenuCallable calling;
            public InputType input;
            public object data;

            public MenuTopic(string name, MenuCallable c, InputType i, object d = null)
            {
                TopicName = name;
                calling = c;
                input = i;
                data = d;
            }

            public void Call()
            {
                object line = "";
                switch (input)
                {
                    case InputType.None:
                        break;
                    case InputType.Int:
                        Console.WriteLine("Enter an Integer: ");
                        try
                        {
                            line = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Wrong Input");
                            System.Threading.Thread.Sleep(500);
                            return;
                        }
                        break;
                    case InputType.Line:
                        Console.WriteLine("String Input:");
                        line = Console.ReadLine();
                        break;
                    default:
                        break;
                }
                calling.Invoke(line, data);
            }

            
        }   
    }
}
