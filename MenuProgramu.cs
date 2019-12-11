using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace filescan
{
    public class MenuProgramu
    {
        #region filds

        /// <summary>
        ///     The user enviroment file path.     
        /// </summary>
        string userEnviromentFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the file name 
        /// </summary>
        public string FileName { get; set; } = "textfile.txt";

        /// <summary>
        /// Gets or sets the full file path
        /// </summary>
        public string FullFilePath
        {
            get
            {
                return  Path.Combine(userEnviromentFilePath, "Downloads", FileName);
            }
        }
        #endregion


        public void StartMenuProgramu()
        {
            Console.Title = " Menu Programu ";

        string url = "https://www.w3.org/TR/PNG/iso_8859-1.txt";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine("1. Pobranie pliku z internetu");
                Console.WriteLine("2. Liczba liter");
                Console.WriteLine("3. liczba wyrazow w pliku");
                Console.WriteLine("4. Liczba znaków interpunkcyjnych ");
                Console.WriteLine("5. Liczba zdań w pliku ");
                Console.WriteLine("6. Raport użycia A-Z ");
                Console.WriteLine("7. Zapis statystyk z pkt 2-5 do pliku .txt ");
                Console.WriteLine("8. Koniec programu");
                Console.WriteLine("===============================================");

                ConsoleKeyInfo klawisz = Console.ReadKey();
                switch (klawisz.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear(); DownloadFile(url); break;
                    case ConsoleKey.D2:
                        Console.Clear(); LettersCounter(); break;
                    case ConsoleKey.D3:
                        Console.Clear(); WordsCounter(); break;
                    case ConsoleKey.D4:
                        Console.Clear(); GetPunctuationMarks(); break;
                    case ConsoleKey.D5:
                        Console.Clear(); GetNumberOfSentences(); break;
                    case ConsoleKey.D6:
                        Console.Clear(); opcjawbudowie(); break;
                    case ConsoleKey.D7:
                        Console.Clear(); opcjawbudowie(); break;
                    case ConsoleKey.D8:
                        Environment.Exit(0); break;
                    case ConsoleKey.Escape:
                    default: break;
                }
            }
        }
        static void opcjawbudowie(){
            Console.Write("Opcja w budowie ! ");
            Console.ReadKey();
         }

        public void DownloadFile(string url)
            {
            

            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, FullFilePath);
            Console.WriteLine("File has been downloaded...");
            Console.WriteLine("Press key to continue!");
            Console.ReadKey();
        }

        /// <summary>
        ///     Count number of punctuation marks in the file
        /// </summary>
        /// <returns>
        ///     The number of punctuation marks 
        /// </returns>
        public int GetPunctuationMarks()
        {
            if (File.Exists(FullFilePath))
            {
                var fileContent = File.ReadAllText(FullFilePath);

                var countPunctMark = fileContent.ToString()
                                    .Where(x => char.IsPunctuation(x))
                                    .Count();
                
                Console.WriteLine($"Total number of Punctuation Marks in file: {countPunctMark}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return countPunctMark;
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return 0;
            }
        }

        /// <summary>
        ///     Count number of sentences in the file
        /// </summary>
        /// <returns>
        ///     The number of sentences 
        /// </returns>
        public int GetNumberOfSentences()
        {
            if(File.Exists(FullFilePath))
            {
                var fileContent = File.ReadAllText(FullFilePath);
                var regex = new Regex(@"(?<=[\.!\?])\s+");
                var countSentences =  regex.Split(fileContent.ToString()).ToList().Count;

                Console.WriteLine($"Total number of sentences if file {countSentences}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return countSentences;
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return 0;
            }
        }

        public int WordsCounter()
        {
            if (File.Exists(FullFilePath))
            {
                var fileContent = File.ReadAllText(FullFilePath);
                char[] separator = { ' ' };

                int wordsCount = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Total number of words in file {wordsCount}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return wordsCount;
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return 0;
            }
            

        }

        public int LettersCounter()
        {
            if (File.Exists(FullFilePath))
            {
                string fileContent = File.ReadAllText(FullFilePath);
                int letterAmount = fileContent.Length;
                Console.WriteLine($"Total number of letter in file {letterAmount}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return letterAmount;
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
                return 0;
            }

        }

    }
}
