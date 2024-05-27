using System.Collections;
using System.Collections.Generic;
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
    public static void SavePlayer2(Health player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save.backup";
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
    public static PlayerData LoadPlayer2(Health player)
    {
        string path = Application.persistentDataPath + "/player.save.backup";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();

        return data;
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
            //SaveEnemy(player);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream1 = new FileStream(path, FileMode.Create);
            EnemyData data1 = new EnemyData(player);
            bool[] newEnemy = new bool[29];
            data1.enemy = newEnemy;
            formatter.Serialize(stream1, data1);
            stream1.Close();

            FileStream stream = new FileStream(path, FileMode.Open);

            EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();
            //Debug.LogError("Save file not found in " + path);
            //return null;
            return data1;
        }
    }
    public static void SaveEnemy2(Health player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/enemy.save.backup";
        FileStream stream = new FileStream(path, FileMode.Create);

        EnemyData data = new EnemyData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static EnemyData LoadEnemy2(Health player)
    {
        string path = Application.persistentDataPath + "/enemy.save.backup";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        EnemyData data = formatter.Deserialize(stream) as EnemyData;
        stream.Close();

        return data;
    }
    public static void SaveItem()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/item.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        ItemsData data = new ItemsData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ItemsData LoadItem()
    {
        string path = Application.persistentDataPath + "/item.save";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ItemsData data = formatter.Deserialize(stream) as ItemsData;
            stream.Close();

            return data;
        }
        else
        {
            //SaveItem();
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream1 = new FileStream(path, FileMode.Create);
            ItemsData data1 = new ItemsData();
            bool[] newitems = new bool[5];
            data1.items = newitems;
            formatter.Serialize(stream1, data1);
            stream1.Close();
            //Debug.LogError("Save file not found in " + path);
            //return null;
            return data1;
        }
    }
    public static void SaveItem2()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/item.save.backup";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        ItemsData data = new ItemsData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ItemsData LoadItem2()
    {
        string path = Application.persistentDataPath + "/item.save.backup";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        ItemsData data = formatter.Deserialize(stream) as ItemsData;
        stream.Close();

        return data;
    }
}
