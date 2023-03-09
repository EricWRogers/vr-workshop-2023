using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //Use this when messing with files 
using System.Runtime.Serialization.Formatters.Binary; //Binary formatter because why not?

public static class SaveSystem
{
  public static void SavePlayer(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath +"/player.dat"; //Probably, I don't know. Use this if that doesnt work -> /storage/emulated/0/Android/data/<packagename>/files
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static SaveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.dat";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
