using System;
using UnityEngine;

[Serializable]
public class Save
{
    public string _locationId;
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}