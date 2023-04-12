using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fungus;

public class SaveHandler : MonoBehaviour
{
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
            print(historyData);
        }
        if (!string.IsNullOrEmpty(historyData))
        {
            var tempSavesHistory = JsonUtility.FromJson<SaveHistory>(historyData);
            if (tempSavesHistory != null)
            {
                savesHistory = tempSavesHistory;
                print(savesHistory.GetDebugInfo());
            }
        }
    }
    private static string GetFullFilePath(string saveDataKey)
    {
        return STORAGE_DIRECTORY + saveDataKey + ".json";
    }
}
