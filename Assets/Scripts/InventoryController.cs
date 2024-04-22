using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryController;
using UnityEngine.UI;
using TMPro;

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
            if (Input.GetKeyDown(KeyCode.R))
            {
                PlayerMovement.dialogue = false;
                invWindow.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R) && !PlayerMovement.dialogue)
            {
                PlayerMovement.dialogue = true;
                invWindow.SetActive(true);
            }
        }
    }

    public static void ObtainItem(string itemName, int amount)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if(Inventory[i].name == itemName)
            {
                Inventory[i].amount++;
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
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].name == itemName)
            {
                wandUses++;
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
