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
        ///     Gets / sets the number of punctuation marks in file
        /// </summary>
        public int CountPunctMark { get; set; }

        /// <summary>
        ///     Gets / sets the number sentences in file
        /// </summary>
        public int CountSentences { get; set; }

        /// <summary>
        ///     Gets / sets the number of words in file
        /// </summary>
        public int WordsCount { get; set; }

        /// <summary>
        ///     Gets / sets the number leters in file
        /// </summary>
        public int LetterAmount { get; set; }

        /// <summary>
        ///     Gets or sets the file name 
        /// </summary>
        public string FileName { get; set; } = "textfile.txt";

        /// <summary>
        ///     Gets or sets the full file path
        /// </summary>
        public string FullDownloadFilePath
        {
            get
            {
                return  Path.Combine(userEnviromentFilePath, "Downloads", FileName);
            }
        }

        public string StatisticsFilePath
        {
            get
            {
                return Path.Combine(userEnviromentFilePath, "staistics.txt");
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
                        Console.Clear(); SaveStatistics(); break;
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
            webClient.DownloadFile(url, FullDownloadFilePath);
            Console.WriteLine("File has been downloaded...");
            Console.WriteLine("Press key to continue!");
            Console.ReadKey();
        }

        /// <summary>
        ///     Save the statistics to file
        /// </summary>
        public void WriteToFile()
        {
            using (StreamWriter sw = File.CreateText(StatisticsFilePath))
            {
                sw.WriteLine($"Number of punctuation marks : {CountPunctMark}");
                sw.WriteLine($"Number of sentences: {CountSentences}");
                sw.WriteLine($"Number of words: {WordsCount}");
                sw.WriteLine($"Number of leters : {LetterAmount}");
            }
        }

        /// <summary>
        ///     Edit or creat statistics file
        /// </summary>
        public void SaveStatistics()
        {
            if (File.Exists(StatisticsFilePath))
            {
                Console.WriteLine($"File already exists at: {StatisticsFilePath}");
                Console.WriteLine("to delete file and creat new one press 'y' " +
                    "to override file press 'o', any key to skip:");
                string input = Console.ReadLine();
                if (input.Equals("y"))
                {
                    File.Delete(StatisticsFilePath);
                    WriteToFile();
                }
                else if(input.Equals("o"))
                {
                    Console.WriteLine("Clearing file.\nSaving...");;
                    File.WriteAllText(StatisticsFilePath, string.Empty);
                    WriteToFile();
                }
                Console.WriteLine("Unrecognized input, please try again!");
            }
        }

        /// <summary>
        ///     Count number of punctuation marks in the file
        /// </summary>
        public void GetPunctuationMarks()
        {
            if (File.Exists(FullDownloadFilePath))
            {
                var fileContent = File.ReadAllText(FullDownloadFilePath);

                CountPunctMark = fileContent.ToString()
                                    .Where(x => char.IsPunctuation(x))
                                    .Count();
                
                Console.WriteLine($"Total number of Punctuation Marks in file: {CountPunctMark}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
        }

        /// <summary>
        ///     Count number of sentences in the file
        /// </summary>
        public void GetNumberOfSentences()
        {
            if(File.Exists(FullDownloadFilePath))
            {
                var fileContent = File.ReadAllText(FullDownloadFilePath);
                var regex = new Regex(@"(?<=[\.!\?])\s+");
                CountSentences =  regex.Split(fileContent.ToString()).ToList().Count;

                Console.WriteLine($"Total number of sentences if file {CountSentences}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
        }

        public void WordsCounter()
        {
            if (File.Exists(FullDownloadFilePath))
            {
                var fileContent = File.ReadAllText(FullDownloadFilePath);
                char[] separator = { ' ' };

                WordsCount = fileContent.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Total number of words in file {WordsCount}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
        }

        public void LettersCounter()
        {
            if (File.Exists(FullDownloadFilePath))
            {
                string fileContent = File.ReadAllText(FullDownloadFilePath);
                LetterAmount = fileContent.Length;
                Console.WriteLine($"Total number of letter in file {LetterAmount}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The file does not exist!}");
                Console.WriteLine("Press key to continue!");
                Console.ReadKey();
            }
        }
    }
}
