using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryController;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class InventoryController : MonoBehaviour
{
    static List<Item> Inventory = new List<Item>();
    [SerializeField] private TMP_Text wandLabel;
    [SerializeField] private GameObject invWindow;
    public static TMP_Text wandLabelL;
    // Start is called before the first frame update
    void Start()
    {
        invWindow.SetActive(false);
        wandLabelL = wandLabel;
        Inventory.Add(new Item("repair1"));
        Inventory.Add(new Item("repair2"));
        Inventory.Add(new Item("repair3"));
        Inventory.Add(new Item("repair4"));
        Inventory.Add(new Item("repair5"));
        Inventory.Add(new Item("key1"));
        Inventory.Add(new Item("key2"));
        Inventory.Add(new Item("key3"));
    }

    // Update is called once per frame
    void Update()
    {
        if (invWindow.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Escape))
            {
                PlayerMovement.dialogue = false;
                invWindow.SetActive(false);
            }
        }
        else if (!PlayerMovement.dialogue)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerMovement.dialogue = true;
                invWindow.SetActive(true);
            }
        }
    }

    public static List<Item> GetInventory()
    {
        return Inventory;
    }

    public static void LoadInventory(int[] inventory)
    {
        for(int i = 0; i<8; i++)
        {
            Inventory[i].amount = inventory[i];
        }
    }

    public static void ObtainItem(string itemName, int amount)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if(Inventory[i].name == itemName)
            {
                Inventory[i].amount += amount;
                //print("Item " + itemName + " added " + amount + " times");
                i += Inventory.Count;
            }
        }
    }

    public static void DeleteItem(string itemName)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].name == itemName)
            {
                Inventory[i].amount--;
                i += Inventory.Count;
            }
        }
    }

    public static void RepairWand(string itemName)
    {
        int wandUses = int.Parse(wandLabelL.text);
        if (wandUses > 0)
        {
            return;
        }
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].name == itemName)
            {
                wandUses += i+1;
                Inventory[i].amount--;
                i += Inventory.Count;
            }
        }
        wandLabelL.text = wandUses.ToString();
    }

    public static int GetItemCount(string itemName)
    {
        int amount = 0;
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].name == itemName)
            {
                amount = Inventory[i].amount;
                i += Inventory.Count;
            }
        }
        return amount;
    }

    public class Item
    {
        public string name;
        public int amount;
        public Item(string name)
        {
            this.name = name;
            this.amount = 0;
        }
    }
}
