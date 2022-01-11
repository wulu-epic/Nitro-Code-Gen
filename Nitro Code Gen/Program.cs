using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

Console.Title = "Nitro Code Generator by wulu#0827";

string cooltext = @"

____    __    ____  __    __   __       __    __  
\   \  /  \  /   / |  |  |  | |  |     |  |  |  | 
 \   \/    \/   /  |  |  |  | |  |     |  |  |  | 
  \            /   |  |  |  | |  |     |  |  |  | 
   \    /\    /    |  `--'  | |  `----.|  `--'  | 
    \__/  \__/      \______/  |_______| \______/  
                                                  
";


Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine(cooltext);

Console.WriteLine("Please insert how many codes you want to generate: ", Console.ForegroundColor);
Console.ForegroundColor = ConsoleColor.Red;

string amount_to_gen_string = Console.ReadLine();
int amt = Int32.Parse(amount_to_gen_string);

string ass = "abcdefghijklmnopqrstubwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
string discord = "discord.gift/";

static string Shuffle(string str)
{
    char[] array = str.ToCharArray();
    Random rng = new Random();
    int n = array.Length;
    while (n > 1)
    {
        n--;
        int k = rng.Next(n + 1);
        var value = array[k];
        array[k] = array[n];
        array[n] = value;
    }
    return new string(array);
}

static bool IsFileReady(string filename)
{
    try
    {
        using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
            return inputStream.Length > 0;
    }
    catch (Exception)
    {
        return false;
    }
}

List<string> nitrocodes = new List<string>();
List<string> codeslist = new List<string>();


Console.WriteLine("Starting.", Console.ForegroundColor);
Console.ForegroundColor = ConsoleColor.Red;

for (int i = 0; i < amt; i++)
{
    string shuffled = Shuffle(ass);
    string code = shuffled.Substring(0, 16);
    string nitroCode = discord + code;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(nitroCode, Console.ForegroundColor);

    nitrocodes.Add(nitroCode);
    codeslist.Add(code);

    Console.Title = "Nitro Code Generator by wulu#0827  GENERATED: " + i.ToString() + "/" + amt;
}

Console.ForegroundColor = ConsoleColor.Red;

for (int x = 0; x<5; x++)
{
    Console.Beep();
}

Console.WriteLine("[1] SAVE TO FILE, [2] EXIT", Console.ForegroundColor);

string choice = Console.ReadLine();

if (choice == "1")
{
    Console.WriteLine("[1] WITH URLS [2] ONLY CODES");
    string choice2 = Console.ReadLine();
    if (choice2 == "1")
    {
        try
        {
            System.IO.File.WriteAllLines("codes.txt", nitrocodes);

            if (IsFileReady("codes.txt"))
            {
                Console.WriteLine("Done, exiting in 3 seconds.");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
        catch
        {
            Exception ex;
        }
    }
    else
    {
        try
        {
            System.IO.File.WriteAllLines("codes.txt", codeslist);

            if (IsFileReady("codes.txt"))
            {
                Console.WriteLine("Done, exiting in 3 seconds.");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
        catch
        {
            Exception ex;
        }
    }
}
else
{
    Environment.Exit(0);
}