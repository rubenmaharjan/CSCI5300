using System;

namespace ServerApp
{
    public class MenuClass
    {
        public MenuClass()
        {
        }

        public static void ShowMenu(string title, string[] menu_items)
        {
            Console.WriteLine("\n");
            Console.WriteLine("{0} Menu", title);
            Console.WriteLine("===========");
            for (int i = 0; i < menu_items.Length; i++)
            {
                Console.WriteLine(@"{0}. {1}", i+1, menu_items[i]);
            }
            Console.WriteLine("E. Exit");

        }

    }

}
