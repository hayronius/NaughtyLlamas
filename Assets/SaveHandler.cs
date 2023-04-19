using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

using Fungus;


public class SaveHandler : MonoBehaviour
{
    private string saveDataKey = "save_data";
    public List<string> saves = new List<string>();
    protected static SaveHistory savesHistory = new SaveHistory();
    public static string STORAGE_DIRECTORY { get { return Application.persistentDataPath + "/FungusSaves/"; } }
    void Start()
    {  
        var historyData = string.Empty;
        var fullFilePath = GetFullFilePath(saveDataKey);

        if (System.IO.File.Exists(fullFilePath))
        {
            historyData = System.IO.File.ReadAllText(fullFilePath);
            //print(historyData);
        }
        if (!string.IsNullOrEmpty(historyData))
        {
            var tempSavesHistory = JsonUtility.FromJson<SaveHistory>(historyData);
            if (tempSavesHistory != null)
            {
                savesHistory = tempSavesHistory;
                //var numSaves = savesHistory.NumSavePoints;
                //print(savesHistory.GetDebugInfo());
                var temp = savesHistory.GetDebugInfo();
                string[] splitArray = temp.Split("\n");

                for (int i = 0; i < splitArray.Length; i++)
                {
                    //Debug.Log(splitArray[i]);
                    var splits = splitArray[i].Split(":");
                    for (int j = 1; j < splits.Length; j+=2)
                    {
                        if (!splits[j].Equals(null) && !splits[j].Equals(""))
                        {
                            saves.Add(splits[j]);
                        }                       
                    }
                }
                WriteSaves(saves);
            }
        }

    }

    void WriteSaves(List<string> saves)
    {
        string filePath = STORAGE_DIRECTORY + saveDataKey + ".txt";
        print(filePath);

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read all the lines from the file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string input in saves)
            { 
                // Check if the input already exists in the file
                if (Array.IndexOf(lines, input) == -1)
                {
                    // Append the input to the file if it is unique
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine(input);
                        print("Input written to file.");
                    }
                }
                else
                {
                    print("Input already exists in file.");
                }
            }
        }
        else
        {
            // Create a new file and write the input to it
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (string input in saves)
                {
                    sw.WriteLine(input);
                    print("Input written to file.");
                }
            }
        }
    }

    private static string GetFullFilePath(string saveDataKey)
    {
        return STORAGE_DIRECTORY + saveDataKey + ".json";
    }

    public bool IsSave(string saveKey)
    {
        string filePath = STORAGE_DIRECTORY + saveDataKey + ".txt";
        bool isSave = false;
        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read all the lines from the file
            string[] lines = File.ReadAllLines(filePath);
            foreach (var save in lines)
            {
                if (save.Contains(saveKey))
                {
                    isSave = true;
                    break;
                }
            }
        }
        return isSave;

    }
}
