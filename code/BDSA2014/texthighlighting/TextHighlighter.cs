using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BDSA13;

namespace texthighlighting
{
    /// <summary>
    /// Assignment 37 - Text highlighting.
    /// </summary>
    class TextHighlighter
    {
        static void Main(string[] args)
        {
            new TextHighlighter();
        }

        // These to are used to check for keywords in input from user.
        private readonly string[] _keywords = new[] { "exit", "help", "setfile", "show", "search" };
        private readonly Dictionary<string, string> _keywordDescriptions = new Dictionary<string, string>()
        {
            {"exit", "exit\tExit Text Highlighter. Sad to see you go!"},
            {"help", "help\tSee a list of all commands in Text Highlighter. Very helpful!"},
            {"setfile", "setfile [FILENAME]\tSet the file that you want to search through. A good place to start!"},
            {"show", "show\tShow the file as is, without searching in it. Pretty colours inbound!"},
            {"search", "search \"[SEARCHTERM]\"\tSearch through the set file for the given search term. Now the fun begins!"}
        };

        public TextHighlighter()
        {
            Console.WriteLine("Welcome to the Text Highlighter!");
            Console.WriteLine("Write help to see a list of commands.");
            Console.WriteLine();
            bool exit = false;
            string file = "testFile.txt";
            while (!exit)
            {
                // Read user input.
                string userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput == null) continue;
                // Split it into tokens to be able to check each token.
                string[] tokens = userInput.Split(' ');
                if (tokens.Length == 0) continue;
                if (!_keywords.Contains(tokens[0].ToLower()))
                {
                    WriteError("Command not found. Try typing \"help\"!");
                    
                }
                else
                {
                    if (tokens[0].ToLower().Equals("setfile"))
                    {
                        if (tokens.Length != 2)
                        {
                            // This keyword takes an argument, namely the file name.
                            // If it isn't there, print error and retry loop.
                            WriteError("No file name specified... Write: setfile [FILENAME]");
                            continue;
                        }
                        // Set the file, if the file given exists.
                        if (File.Exists(tokens[1]))
                        {
                            file = tokens[1];
                            WriteSuccess("File " + tokens[1] + " set!");
                        }
                        else
                        {
                            WriteError("File given doesn't exist...");
                        }
                    }
                    else if (tokens[0].ToLower().Equals("show"))
                    {
                        // Check if the user has set a file.
                        if (file == "")
                        {
                            // If file isn't set, print error message and retry the loop.
                            WriteError("No file set... Use the setfile command!");
                            continue;
                        }
                        // Highlighting the text can begin.
                        HightlightText(file, "");
                    }
                    else if (tokens[0].ToLower().Equals("search"))
                    {
                        // Check if the user has set a file.
                        if (file == "")
                        {
                            // If file isn't set, print error message and retry the loop.
                            WriteError("No file set... Use the setfile command!");
                            continue;
                        }
                        // Highlighting the text can begin.
                        string searchTerm = "";
                        for(int i = 1; i < tokens.Length; i++)
                        {
                            searchTerm += tokens[i];
                            if (i < tokens.Length - 1)
                            {
                                searchTerm += " ";
                            }
                        }
                        HightlightText(file, searchTerm);
                    }
                    else if (tokens[0].ToLower().Equals("help"))
                    {
                        foreach (string desc in _keywordDescriptions.Values)
                        {
                            Console.WriteLine(desc);
                        }
                        Console.WriteLine();
                    }
                    else if (tokens[0].ToLower().Equals("exit"))
                    {
                        // If user wants to exit, do exit!
                        Console.WriteLine("Exiting Text Highlight...");
                        Thread.Sleep(1000); // Just for fun :)
                        exit = true;
                    }
                }
            }
        }

        public void HightlightText(string inputFile, string searchTerm)
        {
            // Fetch the text from the input file.
            string input = TextFileReader.ReadFile(inputFile);
            List<ColouredString> colouredTokens = new List<ColouredString>()
            {
                {new ColouredString(input, ConsoleColor.White)}
            };

            // Urls.
            for (int i = colouredTokens.Count-1; i >=0; i--)
            {
                Regex urlRegex = new Regex(@"(http|https|ftp|)\://{0,1}[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]", RegexOptions.IgnoreCase);

                List<ColouredString> result = FindItems((colouredTokens[i]), urlRegex, ConsoleColor.Blue);
                // Remove the old token and put in the new one(s).
                colouredTokens.RemoveAt(i);
                colouredTokens.InsertRange(i, result);
            }

            // Dates.
            for (int i = colouredTokens.Count-1; i >=0; i--)
            {
                Regex dateRegex = new Regex(@"((Mon|Tue|Wed|Thu|Fri|Sat|Sun|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday)\b)(\s?,?\s\d{2}\.?\s)?(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec|January|February|March|April|May|June|July|August|September|October|November|December)?\s?(\d{4})?/?\s?(\d{2}\:\d{2}(\:\d{2})?)?", RegexOptions.IgnoreCase);

                List<ColouredString> result = FindItems((colouredTokens[i]), dateRegex, ConsoleColor.Red);
                // Remove the old token and put in the new one(s).
                colouredTokens.RemoveAt(i);
                colouredTokens.InsertRange(i, result);
            }

            // Search term.
            if (!string.IsNullOrEmpty(searchTerm))
            {
                for (int i = colouredTokens.Count - 1; i >= 0; i--)
                {
                    Regex dateRegex =
                        new Regex(searchTerm, RegexOptions.IgnoreCase);

                    List<ColouredString> result = FindItems((colouredTokens[i]), dateRegex, ConsoleColor.Yellow);
                    // Remove the old token and put in the new one(s).
                    colouredTokens.RemoveAt(i);
                    colouredTokens.InsertRange(i, result);
                }
            }

            for (int i = 0; i < colouredTokens.Count; i++)
            {
                ColouredString text = (ColouredString)colouredTokens[i];
                Console.ForegroundColor = text.Colour;
                Console.Write(text.Text);
                Console.ResetColor();
                //Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private List<ColouredString> FindItems(ColouredString token, Regex regex, ConsoleColor colour)
        {
            List<ColouredString> colouredTokens = new List<ColouredString>();
            // If there are no matches at all, return the full token.
            if (!regex.IsMatch(token.Text))
            {
                colouredTokens.Add(new ColouredString(token.Text, token.Colour));
                return colouredTokens;
            }

            string currentToken = token.Text;
            while (regex.IsMatch(currentToken))
            {
                Match match = regex.Match(currentToken);
                // If there characters before the match.
                if (match.Index > 0)
                {
                    colouredTokens.Add(new ColouredString(currentToken.Substring(0, match.Index),token.Colour));
                }
                // Puts in the actual match.
                colouredTokens.Add(new ColouredString(match.Value, colour));

                // Continue to find more matches in the rest of the string.
                currentToken = currentToken.Substring(match.Index + match.Length);
            }
            colouredTokens.Add(new ColouredString(currentToken, token.Colour));

            // Return the new dictionary by asigning it to the parameter given.
            return colouredTokens;
        }

        private static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        private static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        private class ColouredString
        {
            public string Text { get; set; }
            public ConsoleColor Colour { get; set; }
            public ColouredString(string text, ConsoleColor colour)
            {
                Text = text;
                Colour = colour;
            }

            public new string ToString()
            {
                return Text;
            }
        }

    }
}
