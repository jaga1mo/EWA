using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryController;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;
    public int[] inventory;

    //public bool[] items = new bool[5];
    

    public PlayerData (Health player)
    {
        health = player.currentHealth;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        List<Item> Inventory1 = InventoryController.GetInventory();
        inventory = new int[8];
        for(int i = 0; i<8; i++)
        {
            inventory[i] = Inventory1[i].amount;
        }
    }
}
