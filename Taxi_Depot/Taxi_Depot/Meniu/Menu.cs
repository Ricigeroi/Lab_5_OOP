using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_depot.Meniu
{
    public class Menu
    {
        private MenuCategory _current;
        public Menu(MenuCategory root)
        {
            _current = root;
        }

        public void Run()
        {
            Stack<MenuCategory> wayBack = new Stack<MenuCategory>();
            int index = 0;
            while (true)
            {
                DrawMenu(0, 0, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < _current.Items.Length - 1)
                            index++;
                        else
                            index = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                            index = _current.Items.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (_current.Items[index])
                        {
                            case MenuCategory category:
                                wayBack.Push(_current);
                                index = 0;
                                _current = category;
                                Console.Clear();
                                break;
                            case MenuAction action:
                                action.Action(action);
                                break;
                            case MenuBack:
                                if (wayBack.Count == 0)
                                    return;
                                MenuCategory parent = wayBack.Pop();
                                index = Array.IndexOf(parent.Items, _current);
                                _current = parent;
                                Console.Clear();
                                break;
                            default:
                                throw new InvalidCastException("Неизвестный тип пункта меню");
                        }
                        break;
                }
            }
        }

        private void DrawMenu(int row, int col, int index)
        {
            Console.SetCursorPosition(col, row);
            Console.WriteLine(_current.Name);
            Console.WriteLine();

            for (int i = 0; i < _current.Items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(_current.Items[i].Name);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
