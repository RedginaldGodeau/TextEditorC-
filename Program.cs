// MADE BY REDGINALD GODEAU
using System;

namespace  MyIA
{
    class Program
    {
        static private string Addingletter (string _Input, char _Letter, int _Cursor)
        {
            if (_Cursor == _Input.Length)
                _Input += _Letter;
            else
                _Input = _Input.Insert(_Cursor, _Letter.ToString());

            return (_Input);
        }


        
        static void Main(string[] args)
        {
            string Path = args.Length > 0 ? args[0] : "";
            string Input = "";
            int Cursor = 0;
            bool Run = true;

            while (Run)
            {
                Console.Clear();
                Console.WriteLine($"{Input.Insert(Cursor, '|'.ToString())}\n\tCursor:{Cursor}");

                ConsoleKeyInfo KeyInput = Console.ReadKey();
                switch (KeyInput.Key)
                {
                    case ConsoleKey.Escape: Run = false; break;

                    case ConsoleKey.LeftArrow: 
                        if (Cursor >= 1)
                            Cursor--; 
                        break;
                    case ConsoleKey.RightArrow: 
                        if (Cursor < Input.Length)
                            Cursor++; 
                        break;   
                    case ConsoleKey.Backspace: 
                        if (Cursor >= 1)
                        {
                            Input = Input.Remove(Cursor - 1);
                            Cursor--; 
                        }
                        break;
                    case ConsoleKey.Enter: Input = Addingletter (Input, '\n', Cursor); Cursor++; break;
                    default: Input = Addingletter (Input, KeyInput.KeyChar, Cursor); Cursor++; break;
                }
            }


            Console.WriteLine("Voulez vous sauvegarder le fichier ? (y/n)");
            char res = Console.ReadKey().KeyChar;

            Console.Clear();
            if (res == 'y' || res == 'Y')
            {
                if (Path.Length == 0)
                {
                    Console.WriteLine("Donnez le nom du chemin/fichier");
                    while ((Path = Console.ReadLine()).Length == 0)
                        ;
                }
                Console.WriteLine("Saving...");
                File.WriteAllText(Path, Input);
                Console.Clear();
                Console.WriteLine("Saved !");
            }
            else
                Console.WriteLine("Exit...");
        }
    }


}