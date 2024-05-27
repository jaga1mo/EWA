using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (Health player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(Health player)
    {
        string path = Application.persistentDataPath + "/player.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            SavePlayer(player);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            //Debug.LogError("Save file not found in " + path);
            //return null;
            return data;
        }
    }
    public static void SaveEnemy(Health player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/enemy.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        EnemyData data = new EnemyData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static EnemyData LoadEnemy(Health player)
    {
        string path = Application.persistentDataPath + "/enemy.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();

            return data;
        }
        else
        {
            SaveEnemy(player);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();
            //Debug.LogError("Save file not found in " + path);
            //return null;
            return data;
        }
    }
}
