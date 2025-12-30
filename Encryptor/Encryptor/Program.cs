using System;
using System.IO;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;


class EncryptionAlgorithm
{
    const string PATH = @"C:\Users\Li-am Hemo\Desktop\exercise1";
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

        Console.WriteLine("Enter your file: ");
        string file = Console.ReadLine();

        int key = Random.Shared.Next(1, 101);

        switch (operation)
        {
            case 1:
                EncryptFile(file, key);
                break;
            case 2:
                DecryptFile(file);
                break;
            default:
                Console.WriteLine("Enjoy your day!");
                break;
        }
    }
    public static void EncryptFile(string file, int key)
    {
        string filePath = $@"{PATH}\{file}.txt";
        if (File.Exists(filePath))
        {
            string originalContent = File.ReadAllText(filePath);
            char[] chars = originalContent.ToCharArray();

            for (int i = 0; i < originalContent.Length; i++)
            {
                chars[i] = (char)(chars[i] + key);
            }

            string newContent = new string(chars);  

            File.WriteAllText($@"{PATH}\{file}_encrypted.txt", newContent);
            File.WriteAllText($@"{PATH}\key.txt", key.ToString());
            Console.WriteLine("Your new files path is: " +
                $"\nEncrypted file : {PATH}\\{file}_encrypted.txt" +
                $"\nKey : {PATH}\\key.txt");
        }
        else
        {
            Console.WriteLine("File not found.");
            return;
        }


    }
    public static void DecryptFile(string file)
    {
        string filePath = $@"{PATH}\{file}_encrypted.txt";
        if (File.Exists(filePath))
        {
            string originalContent = File.ReadAllText(filePath);
            string keyString = File.ReadAllText($@"{PATH}\key.txt");
            int key = int.Parse(keyString);

            char[] chars = originalContent.ToCharArray();

            for (int i = 0; i < originalContent.Length; i++)
            {
                chars[i] = (char)(chars[i] - key);
            }
            string newContent = new string(chars);

            File.WriteAllText($@"{PATH}\{file}_decrypted.txt", newContent);
            Console.WriteLine("Your new file path is: " +
                $"\nDecrypted file : {PATH}\\{file}_decrypted.txt");
        }
        else
        {
            Console.WriteLine("File not found.");
            return;
        }
    }
}
