using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsData
{
    public bool[] items = new bool[5];
    
    public ItemsData (Health player)
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
            Health enemyHealthScript = child.gameObject.GetComponent<Health>();
            if(enemyHealthScript.currentHealth <= 0)
            {
                int id = enemyHealthScript.GetEnemyID(child.gameObject.name);
                items[id] = true;
            }
        }

        return children;
    }
}
