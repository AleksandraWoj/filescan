﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace filescan
{
    static class MenuProgramu
    {
        public static void StartMenuProgramu()
        {
            Console.Title = " Menu Programu ";
            string url = "https://www.w3.org/TR/PNG/iso_8859-1.txt";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Liczba liter");
                Console.WriteLine("2. Liczba wyrazów");
                Console.WriteLine("3. Liczba znaków interpunkcyjnych ");
                Console.WriteLine("4. Liczba zdań w pliku ");
                Console.WriteLine("5. Raport użycia A-Z ");
                Console.WriteLine("6. Koniec programu");

                ConsoleKeyInfo klawisz = Console.ReadKey();
                switch (klawisz.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear(); downloadFile(url); break;
                    case ConsoleKey.D2:
                        Console.Clear(); opcjawbudowie(); break;
                    case ConsoleKey.Escape:
                    case ConsoleKey.D3:
                        Console.Clear(); opcjawbudowie(); break;
                    case ConsoleKey.D4:
                        Console.Clear(); opcjawbudowie(); break;
                    case ConsoleKey.D5:
                        Console.Clear(); opcjawbudowie(); break;
                    case ConsoleKey.D6:
                        Environment.Exit(0); break;
                    default: break;
                }
            }
        }
        static void opcjawbudowie()

        {
            Console.Write("Opcja w budowie ! ");
            Console.ReadKey();
         }

        static void downloadFile(string url)
        {
            string file = System.IO.Path.GetFileName(url);
            WebClient cln = new WebClient();
            cln.DownloadFile(url, file);
        }

    }
}
