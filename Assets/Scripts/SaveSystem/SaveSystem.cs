using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSaveSystem", menuName = "SaveSystem")]
public class SaveSystem : ScriptableObject
{
    public string saveFileName = "bugbear.dat";
    public string backupSaveFileName = "bugbear.dat.bak";
    public Save saveData = new Save();

    public bool LoadSaveDataFromDisk()
    {
        if (FileManager.LoadFromFile(saveFileName, out var json))
        {
            saveData.LoadFromJson(json);
            return true;
        }
        return false;
    }
    public void SaveDataToDisk()
    {
        if (FileManager.MoveFile(saveFileName, backupSaveFileName))
        {
            try
            {
                bool success = FileManager.WriteToFile(saveFileName, saveData.ToJson());

                if (success)
                {
                    Debug.Log("Save Successful");
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
    public void WriteEmptySaveFile()
    {
        FileManager.WriteToFile(saveFileName, "");
    }
    public void SetNewGameData()
    {
        FileManager.WriteToFile(saveFileName, "");
        SaveDataToDisk();
    }
}