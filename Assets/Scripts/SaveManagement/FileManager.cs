using System;
using System.IO;
using UnityEngine;

public static class FileManager
{
    public static bool WriteToFile(string fileName, string fileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            File.WriteAllText(fullPath, fileContents);
            return true;
        }
        catch (Exception e)
        {
            //TODO: Exception Handlers for Writing to File
            Debug.LogException(e);
            return false;
        }
    }

    public static bool LoadFromFile(string fileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(fullPath))
        {
            File.WriteAllText(fullPath, "");
        }
        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            result = "";
            return false;
        }
    }

    public static bool MoveFile(string fileName, string newFileName)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);
        var newFullPath = Path.Combine(Application.persistentDataPath, newFileName);

        try
        {
            if (File.Exists(newFullPath)) File.Delete(newFullPath);
            File.Move(fullPath, newFullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }
    }
}