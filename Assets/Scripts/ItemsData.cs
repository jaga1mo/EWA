using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsData
{
    public bool[] items = new bool[100];
    
    public ItemsData ()
    {
        GameObject father = GameObject.Find("/Items");
        
        List<GameObject> enemy = GetChildren(father);
    }

    public void SavePickedItem(int id)
    {
        items[id]=true;
    }

    List<GameObject> GetChildren(GameObject parent)
    {
        List<GameObject> children = new List<GameObject>();

        // Loop through all children of the parent
        foreach (Transform child in parent.transform)
        {
            children.Add(child.gameObject);
            if(!child.gameObject.activeSelf)
            {
                int id = GetItemID(child.gameObject.name);
                items[id] = true;
            }
        }
        return children;
    }
    public int GetItemID(string name)
    {
        switch (name) 
        {
            case "Item1":return 0;
            case "Item2":return 1;
            case "Item3":return 2;
            case "Item4":return 3;
            case "Item5":return 4;
            case "Item6":return 5;
            case "Item7":return 6;
        }
        return 5;
    }
}
