using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CombinationLoader
{
    private static string combinationFolderName = "Assets/Text";
    private static string combinationFileName = "combination.txt";
    private static string combinationPath
    {
        get
        {
            return Path.Combine(combinationFolderName, combinationFileName);
        }
    }

    public static List<int> Load(List<int> defaultCombination)
    {
        EnsureFileExists(defaultCombination);
        return ReadCombinationFromFile();
    }

    private static void EnsureFileExists(List<int> defaultCombination)
    {
        if (!File.Exists(combinationPath))
            CreateFile(defaultCombination);
    }

    private static void EnsureDirectoryExists()
    {
        if (!Directory.Exists(combinationFolderName))
            Directory.CreateDirectory(combinationFolderName);
    }

    private static void CreateFile(List<int> defaultCombination)
    {
        EnsureDirectoryExists();

        //Write default combo to the file
        StreamWriter writer = new StreamWriter(combinationPath);

        foreach (int combinationEntry in defaultCombination)
        {
            writer.WriteLine(combinationEntry);
        }
        writer.Close();
        
    }

    private static List<int> ReadCombinationFromFile()
    {
        List<int> combination = new List<int>();

        //Text file will store 1 number per line

        StreamReader reader = new StreamReader(combinationPath);

        string combinationNumber = string.Empty;

        while((combinationNumber = reader.ReadLine()) != null)
        {
            int combinationInteger = int.Parse(combinationNumber);
            combination.Add(combinationInteger);
        }

        reader.Close();
        return combination;
    }
}
