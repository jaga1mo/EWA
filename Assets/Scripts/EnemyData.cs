using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    //public bool[] items = new bool[5];
    public bool[] enemy = new bool[29];
    
    public EnemyData (Health player)
    {
        GameObject father = GameObject.Find("/Enemies");
        List<GameObject> enemy = GetChildren(father);
    }

    public void SaveEnemyKill(int id)
    {
        enemy[id]=true;
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
                enemy[id] = true;
            }
        }

        return children;
    }
}
