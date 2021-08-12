using System;
using System.IO;

namespace WordSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Ask the user for the file path
            //2. Ask the user for the search string
            //3. Open the file
            //4. Loop through each line in the file
            //5. If the line contains the search string, print it out along with its line number

            while (true)
            {
                Console.WriteLine("What is the full qualified name of the file that should be searched?");
                string fullPath = Console.ReadLine();
                Console.WriteLine("What is the search word you are looking for?");
                string searchWord = Console.ReadLine();
                Console.WriteLine("Should the search be case sensitive(Y/N)?");
                string caseSensitive = Console.ReadLine();
                if (caseSensitive != "n" && caseSensitive != "N" && caseSensitive != "y" && caseSensitive != "Y")
                {
                    Console.WriteLine("Invalid entry for case sensitivity, please try again.");
                }
                else
                {

                    try
                    {
                        using (StreamReader sr = new StreamReader(fullPath))
                        {
                            int lineNumber = 1;
                            while (!sr.EndOfStream)
                            {
                                if (caseSensitive == "y" || caseSensitive == "Y")
                                {
                                    string line = sr.ReadLine();
                                    if (line.Contains(searchWord))
                                    {
                                        Console.WriteLine(lineNumber + ") " + line);
                                    }
                                    lineNumber += 1;
                                }
                                else if (caseSensitive == "n" || caseSensitive == "N")
                                {
                                    string line = (sr.ReadLine()).ToLower();
                                    if (line.Contains(searchWord.ToLower()))
                                    {
                                        Console.WriteLine(lineNumber + ") " + line);
                                    }
                                    lineNumber += 1;
                                }
                            }
                            break;
                        }
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("No directory found in the name given, please try again.");
                        
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("No file found at the name given, please try again.");
                    }
                    
                    catch (IOException e)
                    {
                        Console.WriteLine("Error reading the file, please try again.");
                        Console.WriteLine(e.Message);    // raw exception message only displayed to user if unexpected IO exception occurs.
                    }
                }
            }
        }
    }
}
