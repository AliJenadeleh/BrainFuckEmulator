using System;
using bfai.Classes.BrainFuck;

namespace BFEmulator
{
    class Program
    {
       private const string SampleBF = @"+++++>++<[>+<]>*";// 5+2;
        private const string SampleBFIO = @"/>/<[>+<]>*";// 5+2;
        private const string  name = "BrainFu*k Emulator";
        private const string version = "1.0";
        private const string Creator = "Ali Jendeleh";
        private const string Email = "AliJenadeleh@Outlook.com";
        private const string Web = "http://jcafe.ir";

        static void Main(string[] args)
        {

            Console.WriteLine($"{Program.name} \\ {Program.version} .");
            Console.WriteLine($"Creator :  {Program.Creator} .");
            Console.WriteLine($"Email :  {Program.Email} .");
            Console.WriteLine($"Web :  {Program.Web} .");
            Console.WriteLine("***************** Start ************************");
            //Console.ReadKey();

                new Emulator(Program.SampleBF).Run();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
