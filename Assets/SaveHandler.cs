using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fungus;

public class SaveHandler : MonoBehaviour
{
    public List<string> saves = new List<string>();
    protected static SaveHistory savesHistory = new SaveHistory();
    public static string STORAGE_DIRECTORY { get { return Application.persistentDataPath + "/FungusSaves/"; } }
    void Start()
    {
        var saveDataKey = "save_data";
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
            }
        }
    }

    private static string GetFullFilePath(string saveDataKey)
    {
        return STORAGE_DIRECTORY + saveDataKey + ".json";
    }

    public bool IsSave(string saveKey)
    {
        bool isSave = false;
        foreach (var save in saves)
        {
            if (save.Contains(saveKey))
            {
                isSave = true;
                break;
            }
        }
        return isSave;
    }
}
