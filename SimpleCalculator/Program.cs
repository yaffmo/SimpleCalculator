using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            if (CopyToSwitch() == false)
            {
                InputToPath();
            }
        }

        private bool isContain(string pathRef)
        {
            List<string> listOfStrings = new List<string>()
            {
                "G:","Volumes",@"\\nas","smb"
            };
            
            return listOfStrings.Any(pathRef.Contains);
        }
        private static bool CopyToSwitch()
        {
            var text = TextCopy.Clipboard.GetText();

            if (text.Contains("G:"))
            {
                PCSwitcher(text);
                return true;
            }
            else if (text.Contains("Volumes"))
            {
                MACSwitcher(text);
                return true;
            }
            else if (text.Contains(@"\\nas"))
            {
                PCNasSwitcher(text);
                return true;
            }
            else if (text.Contains("smb"))
            {
                MACNasSwitcher(text);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void InputToPath()
        {
            Console.Write("請輸入要轉換的路徑:");
            string input = Console.ReadLine();

            if (input.Contains("G:"))
            {
                PCSwitcher(input);
            }
            else if (input.Contains("Volumes"))
            {
                MACSwitcher(input);
            }
            else if (input.Contains(@"\\nas"))
            {
                PCNasSwitcher(input);
            }
            else if (input.Contains("smb:"))
            {
                MACNasSwitcher(input);
                
            }
            
        }

        private static void MACNasSwitcher(string text)
        {
            string path = $@"{text}";
            var position = path.Replace(@"smb:/", @"\");
            var result = position.Replace("/", @"\");

            Console.WriteLine(result);
            TextCopy.Clipboard.SetText(result);
            Console.ReadKey();
        }

        private static void PCNasSwitcher(string text)
        {
            string path = $@"{text}";
            var position = path.Replace(@"\", "/");
            var result = $@"smb:{position}";

            Console.WriteLine(result);
            TextCopy.Clipboard.SetText(result);
            Console.ReadKey();
        }


        private static void MACSwitcher(string input)
        {

            string path = $@"{input}";
            var position = path.Replace(@"/Volumes/GoogleDrive", "G:");
            var result = position.Replace("/", @"\");

            Console.WriteLine(result);
            TextCopy.Clipboard.SetText(result);
            Console.ReadKey();
        }

        private static void PCSwitcher(string input)
        {
            string path = $@"{input}";
            var position = path.Replace(@"\", "/");
            var result = position.Replace(@"G:", "/Volumes/GoogleDrive");

            Console.WriteLine(result);
            TextCopy.Clipboard.SetText(result);
            Console.ReadKey();
        }


    }
}