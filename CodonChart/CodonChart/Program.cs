using System;

namespace CodonChart
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            frontUI();
        }

        public static void frontUI()
        {
            Console.WriteLine("Please enter codon string here: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("\nWould you like to transcribe (a) or translate (b)");
            string userInputAB = Console.ReadLine();
            if (userInputAB.ToUpper().Equals("A"))
            {
                Console.WriteLine("\nThe transcription of the input is: " + transcription(userInput));
            }
            else if (userInputAB.ToUpper().Equals("B"))
            {
                Console.WriteLine("\nThe translation of the input is: " + translation(transcription(userInput)));
            }
        }

        // Transcribing the user input
        // Remember, for transcription, a --> u, g --> c, c --> g, and t --> a
        public static string transcription(string codons)
        {
            string retString = "";
            Boolean end = false;
            // Parses through the codons
            for (int i = 0; i < codons.Length; i++)
            {
                // Checks the string and takes action based on each string
                switch (Char.ToLower(codons[i]))
                {
                    case 'a': retString += "u"; break;
                    case 'g': retString += "c"; break;
                    case 'c': retString += "g"; break;
                    case 't': retString += "a"; break;
                    default: retString += "error"; end = true; break;
                }
                //if ((i % 3) - 2 == 0)
                  //  retString += "|";

                if (end)
                    break;
            }
            if (end)
                return "ERROR";
            return retString.ToUpper();
        }

        // Translating the transcribed codons
        public static string translation(string codons)
        {
            // Return value
            string retString = "";

            // Looping through the codons
            for (int i = 0; i < codons.Length - 3; i += 3)
            {
                // Switch for the first value from codons
                switch (codons[i])
                {
                    // If the first value is "U"
                    case 'U':
                        // Switch for the second value from codons
                        switch (codons[i + 1])
                        {
                            // If the second value is "U"
                            case 'U':
                                // Switch for the third value from codons
                                switch (codons[i + 2])
                                {
                                    // If the third value is "U"
                                    case 'U':
                                    // If the third value is "C"
                                    case 'C': retString += "phe"; break;
                                    // If the third value is "A"
                                    case 'A': 
                                    // If the third value is "G"
                                    case 'G': retString += "leu"; break;
                                }
                                break;
                            // If the second value is "C"
                            case 'C':
                                retString += "ser";
                                break;
                            // If the second value is "A"
                            case 'A':
                                switch (codons[i + 2])
                                {
                                    case 'U': 
                                    case 'C': retString += "tyr"; break;
                                    case 'A': 
                                    case 'G': retString += "STOP"; break;
                                }
                                break;
                            case 'G':
                                switch (codons[i + 2])
                                {
                                    case 'U': 
                                    case 'C': retString += "cys"; break;
                                    case 'A': retString += "STOP"; break;
                                    case 'G': retString += "trp"; break;
                                }
                                break;
                        }
                        break;

                    case 'C':
                        switch (codons[i + 1])
                        {
                            case 'U':
                                retString += "leu";
                                break;
                            case 'C':
                                retString += "pro";
                                break;
                            case 'A':
                                switch (codons[i + 2])
                                {
                                    case 'U': 
                                    case 'C': retString += "his"; break;
                                    case 'A':
                                    case 'G': retString += "gln"; break;
                                }
                                break;
                            case 'G':
                                retString += "arg";
                                break;
                        }
                        break;

                    case 'A':
                        switch (codons[i + 1])
                        {
                            case 'U':
                                switch (codons[i + 2])
                                {
                                    case 'U':
                                    case 'C':
                                    case 'A': retString += "ile"; break;
                                    case 'G': retString += "met(START)"; break;
                                }
                                break;
                            case 'C':
                                retString += "thr";
                                break;
                            case 'A':
                                switch (codons[i + 2])
                                {
                                    case 'U':
                                    case 'C': retString += "asn"; break;
                                    case 'A':
                                    case 'G': retString += "lys"; break;
                                }
                                break;
                            case 'G':
                                switch (codons[i + 2])
                                {
                                    case 'U':
                                    case 'C': retString += "ser"; break;
                                    case 'A':
                                    case 'G': retString += "arg"; break;
                                }
                                break;
                        }
                        break;

                    case 'G':
                        switch (codons[i + 1])
                        {
                            case 'U':
                                retString += "val";
                                break;
                            case 'C':
                                retString += "ala";
                                break;
                            case 'A':
                                switch (codons[i + 2])
                                {
                                    case 'U':
                                    case 'C': retString += "asp"; break;
                                    case 'A':
                                    case 'G': retString += "glu"; break;
                                }
                                break;
                            case 'G':
                                retString += "gly";
                                break;
                        }
                        break;
                }
                if (retString.Substring(retString.Length - 4).Equals("STOP")) break;
                retString += "|";
            }

            return retString;
        }
    }
}