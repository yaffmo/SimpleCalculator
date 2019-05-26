using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = TextCopy.Clipboard.GetText();
            if (IsContain(text))
            {
                ToSwitch(text);
            }
            else
            {
                Console.Write("請輸入要轉換的路徑:");
                string input = Console.ReadLine();
                ToSwitch(input);
            }

        }

        private static bool IsContain(string pathRef)
        {
            List<string> pathKeyword = new List<string>()
            {
                "G:","Volumes",@"\\nas","smb"
            };

            return pathKeyword.Any(item => pathRef.Contains(item));
        }

        private static void ToSwitch(string text)
        {
            if (text.Contains("G:"))
            {
                PCSwitcher(text);
            }
            else if (text.Contains("Volumes"))
            {
                MACSwitcher(text);
            }
            else if (text.Contains(@"\\nas"))
            {
                PCNasSwitcher(text);
            }
            else if (text.Contains("smb"))
            {
                MACNasSwitcher(text);
            }
        }

        private static void MACNasSwitcher(string path)
        {
            var position = path.Replace(@"smb:/", @"\");
            var result = position.Replace("/", @"\");

            ShowSwitchResult(result);
        }

        private static void PCNasSwitcher(string path)
        {
            var position = path.Replace(@"\", "/");
            var result = $@"smb:{position}";

            ShowSwitchResult(result);
        }

        private static void MACSwitcher(string path)
        {

            var position = path.Replace(@"/Volumes/GoogleDrive", "G:");
            var result = position.Replace("/", @"\");

            ShowSwitchResult(result);
        }

        private static void PCSwitcher(string path)
        {
            var position = path.Replace(@"\", "/");
            var result = position.Replace(@"G:", "/Volumes/GoogleDrive");

            ShowSwitchResult(result);
        }

        private static void ShowSwitchResult(string result)
        {
            Console.WriteLine(result);
            TextCopy.Clipboard.SetText(result);
            Console.ReadKey();
        }
    }
}