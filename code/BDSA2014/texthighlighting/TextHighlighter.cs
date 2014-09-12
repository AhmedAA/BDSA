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

        private readonly string[] _keywords = new[] { "exit", "help", "setfile", "show", "search" };
        private readonly Dictionary<string, string> _keywordDescriptions = new Dictionary<string, string>()
        {
            {"exit", "exit\tExit Text Highlighter. Sad to see you go!"},
            {"help", "help\tSee a list of all commands in Text Highlighter. Very helpful!"},
            {"setfile", "setfile [FILENAME]\tSet the file that you want to search through. A good place to start!"},
            {"show", "show\tShow the file as is, without searching in it. Pretty colours inbound!"},
            {"search", "search [SEARCHTERM]\tSearch through the set file for the given search term. Now the fun begins!"}
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
                        HightlightText(file, tokens[1]);
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

        /*public void HightlightText(string inputFile, string searchTerm)
        {
            // Fetch the text from the input file.
            string input = TextFileReader.ReadFile(inputFile);
            string[] tokens = input.Split(' ');
            //string[] tokens = Regex.Split(input, @"\s");

            foreach (string token in tokens)
            {
                OrderedDictionary colouredTokens = new OrderedDictionary()
                {
                    {token, null}
                };

                TokeniseByRegex(ref colouredTokens, @"-{2,}");
                FindUrls(ref colouredTokens);
                FindDates(ref colouredTokens);

                foreach (string colouredToken in colouredTokens.Keys)
                {
                    Console.ForegroundColor = (ConsoleColor)colouredTokens[colouredToken];
                    Console.Write(colouredToken);
                    Console.Write(" ");
                }
                
                // Write a space between each word.
                Console.Write(" ");
            }
            Console.WriteLine();
        }*/

        public void HightlightText(string inputFile, string searchTerm)
        {
            // Fetch the text from the input file.
            string input = TextFileReader.ReadFile(inputFile);
            OrderedDictionary colouredTokens = new OrderedDictionary()
            {
                {input, null}
            };

            for (int i = 0; i < colouredTokens.Count; i++)
            {
                WriteError("Current key: " + FindKeyByIndex(colouredTokens, i));
                OrderedDictionary result = FindUrls2(FindKeyByIndex(colouredTokens, i));
                // Remove the old token and put in the new one(s).
                colouredTokens.RemoveAt(i);
                int index = i;
                foreach (string key in result.Keys)
                {
                    colouredTokens.Insert(index,key,result[key]);
                    index++;
                }
                i+=result.Count-1;
            }

            //TODO SOMETHING HAPPENS HERE WITH THE DATES!!!
            for (int i = 0; i < colouredTokens.Count; i++)
            {
                WriteError("Current key: " + FindKeyByIndex(colouredTokens, i));
                OrderedDictionary result = FindDates2(FindKeyByIndex(colouredTokens, i));
                // Remove the old token and put in the new one(s).
                colouredTokens.RemoveAt(i);
                int index = i;
                foreach (string key in result.Keys)
                {
                    colouredTokens.Insert(index, key, result[key]);
                    index++;
                }
                i += result.Count - 1;
            }

            foreach (string colouredToken in colouredTokens.Keys)
            {
                Console.ForegroundColor = (ConsoleColor)colouredTokens[colouredToken];
                Console.Write(colouredToken);
                Console.Write(" ");
            }

            Console.WriteLine();
        }

        private string FindKeyByIndex(OrderedDictionary dictionary, int index)
        {
            int currentIndex = 0;
            foreach (string key in dictionary.Keys)
            {
                if (currentIndex++ < index)
                {
                    continue;
                }
                return key;
            }
            return null;
        }

        /// <summary>
        /// Will tokenise the given tokens by the given regex.
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="regex"></param>
        private void TokeniseByRegex(ref OrderedDictionary tokens, string regex)
        {
            OrderedDictionary colouredTokens = new OrderedDictionary();
            Regex sepRegex = new Regex(regex, RegexOptions.IgnoreCase);
            foreach (string token in tokens.Keys)
            {
                Match sepMatch = sepRegex.Match(token);
                if (sepMatch.Success)
                {
                    // If there are "normal" words before the matched string.
                    if (sepMatch.Index > 0)
                    {
                        colouredTokens[token.Substring(0, sepMatch.Index)] = ConsoleColor.White;
                    }
                    // Puts in the actual matched string.
                    colouredTokens.Add(sepMatch.Value, ConsoleColor.White);
                    // If there are "normal" words after the matched string.
                    if (sepMatch.Index + sepMatch.Length < token.Length)
                    {
                        colouredTokens[token.Substring(sepMatch.Index + sepMatch.Length)] = ConsoleColor.White;
                    }
                }
                else
                {
                    colouredTokens[token] = ConsoleColor.White;
                }
            }
            // Return the new dictionary by asigning it to the parameter given.
            tokens = colouredTokens;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Returns an ordered dictionary containing strings and colours created from the given token.</returns>
        private OrderedDictionary FindUrls2(string token)
        {
            OrderedDictionary colouredTokens = new OrderedDictionary();
            Regex urlRegex = new Regex(@"(http|https|ftp|)\://{0,1}[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]", RegexOptions.IgnoreCase);
            // If there are no matches at all, return the full token.
            if (!urlRegex.IsMatch(token))
            {
                colouredTokens.Add(token, ConsoleColor.White);
                WriteError("No URL Match!");
                return colouredTokens;
            }

            string currentToken = token;
            while (urlRegex.IsMatch(currentToken))
            {
                Match match = urlRegex.Match(currentToken);
                // If there characters before the match.
                if (match.Index > 0)
                {
                    colouredTokens[currentToken.Substring(0, match.Index)] = ConsoleColor.White;
                }
                // Puts in the actual match.
                colouredTokens.Add(match.Value, ConsoleColor.Blue);

                // Continue to find more matches in the rest of the string.
                currentToken = currentToken.Substring(match.Index + match.Length);
            }

            // Return the new dictionary by asigning it to the parameter given.
            return colouredTokens;
        }

        private void FindUrls(ref OrderedDictionary tokens)
        {
            OrderedDictionary colouredTokens = new OrderedDictionary();
            Regex urlRegex = new Regex(@"(http|https|ftp|)\://{0,1}[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$", RegexOptions.IgnoreCase);
            foreach (string token in tokens.Keys)
            {
                Match urlMatch = urlRegex.Match(token);
                if (urlMatch.Success)
                {
                    // If there are "normal" words before the url.
                    if (urlMatch.Index > 0)
                    {
                        colouredTokens[token.Substring(0, urlMatch.Index)] = ConsoleColor.White;
                    }
                    // Puts in the actual url.
                    colouredTokens.Add(urlMatch.Value, ConsoleColor.Blue);
                    // If there are "normal" words after the url.
                    if (urlMatch.Index + urlMatch.Length < token.Length)
                    {
                        colouredTokens[token.Substring(urlMatch.Index + urlMatch.Length)] = ConsoleColor.White;
                    }
                }
                else
                {
                    colouredTokens[token] = ConsoleColor.White;
                }
            }
            // Return the new dictionary by asigning it to the parameter given.
            tokens = colouredTokens;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Returns an ordered dictionary containing strings and colours created from the given token.</returns>
        private OrderedDictionary FindDates2(string token)
        {
            OrderedDictionary colouredTokens = new OrderedDictionary();
            Regex dateRegex = new Regex(@"((Mon|Tue|Wed|Thu|Fri|Sat|Sun|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday)\b)(\s?,?\s\d{2}\.?\s)?(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec|January|February|March|April|May|June|July|August|September|October|November|December)?\s?(\d{4})?/?\s?(\d{2}\:\d{2}(\:\d{2})?)?", RegexOptions.IgnoreCase);
            // If there are no matches at all, return the full token.
            if (!dateRegex.IsMatch(token))
            {
                colouredTokens.Add(token, ConsoleColor.White);
                WriteError("No DATE Match!");
                return colouredTokens;
            }

            string currentToken = token;
            while (dateRegex.IsMatch(currentToken))
            {
                Match match = dateRegex.Match(currentToken);
                // If there characters before the match.
                if (match.Index > 0)
                {
                    colouredTokens[currentToken.Substring(0, match.Index)] = ConsoleColor.White;
                }
                // Puts in the actual match.
                colouredTokens.Add(match.Value, ConsoleColor.Red);

                // Continue to find more matches in the rest of the string.
                currentToken = currentToken.Substring(match.Index + match.Length);
            }

            // Return the new dictionary by asigning it to the parameter given.
            return colouredTokens;
        }

        private void FindDates(ref OrderedDictionary tokens)
        {
            OrderedDictionary colouredTokens = new OrderedDictionary();
            Regex urlRegex = new Regex(@"((Mon|Tue|Wed|Thu|Fri|Sat|Sun|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday)\b)(\s?,?\s\d{2}\.?\s)?(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec|January|February|March|April|May|June|July|August|September|October|November|December)?\s?(\d{4})?/?\s?(\d{2}\:\d{2}(\:\d{2})?)?", RegexOptions.IgnoreCase);
            foreach (string token in tokens.Keys)
            {
                Match urlMatch = urlRegex.Match(token);
                if (urlMatch.Success)
                {
                    // If there are "normal" words before the url.
                    if (urlMatch.Index > 0)
                    {
                        colouredTokens[token.Substring(0, urlMatch.Index)] = ConsoleColor.White;
                    }
                    // Puts in the actual url.
                    colouredTokens.Add(urlMatch.Value, ConsoleColor.Red);
                    // If there are "normal" words after the url.
                    if (urlMatch.Index + urlMatch.Length < token.Length)
                    {
                        colouredTokens[token.Substring(urlMatch.Index + urlMatch.Length)] = ConsoleColor.White;
                    }
                }
                else
                {
                    colouredTokens[token] = ConsoleColor.White;
                }
            }
            // Return the new dictionary by asigning it to the parameter given.
            tokens = colouredTokens;
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
        }

    }
}
