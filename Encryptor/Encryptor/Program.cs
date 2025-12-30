// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public static void Main(string[] args)
    {
        Exercise1();
    }
    public static void Exercise1()
    {
        Console.WriteLine("Choose an operation: \n" +
            "1) Encrypte file \n" +
            "2) Decrypte file");
        int operation = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your file's path: ");
        string path = Console.ReadLine()?.Trim(' ', '"') ?? "";

        int key = Random.Shared.Next(1, 101);

        switch (operation)
        {
            case 1:
                Program.EncryptFile(path, key);
                break;
            case 2:
                Console.WriteLine("Bring an umbrella.");
                break;
            default:
                Console.WriteLine("Enjoy your day!");
                break;
        }
    }
    public static void EncryptFile(string path, int key)
    {
        if (File.Exists(path))
        {
            string originalContent = File.ReadAllText(path);
            char[] chars = originalContent.ToCharArray();

            for (int i = 0; i < originalContent.Length; i++)
            {
                chars[i] += (char)(chars[i] + key);
            }
            string newContent = new string(chars);

            File.WriteAllText(path, newContent);
            Console.WriteLine("File updated successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
            return;
        }
    }

    public static void DecryptFile(string path, int key)
    {
        // Decryption logic here
    }
}
