using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemBehaviour : MonoBehaviour
{
    [SerializeField] private string Item;
    [SerializeField] private int Amount;
    [SerializeField] private GameObject ItemObject;

    private bool PlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        ItemObject.SetActive(true);
        ItemsData data = SaveSystem.LoadItem();
        int id = data.GetItemID(gameObject.transform.parent.name);
        print(gameObject.transform.parent.name + " " + data.items[id]);
        if(data.items[id])
        {
            ItemObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.dialogue)
        {
            ItemsData data = SaveSystem.LoadItem();
            InventoryController.ObtainItem(Item, Amount);
            PromptUI.DeletePrompt();
            ItemObject.SetActive(false);
            int id = data.GetItemID(gameObject.transform.parent.name);
            data.SavePickedItem(id);
            SaveSystem.SaveItem();
            print("safas");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerObj")
        {
            PlayerInRange = true;
            PromptUI.DisplayPrompt("E: Pick up the item");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerObj")
        {
            PlayerInRange = false;
            PromptUI.DeletePrompt();
        }
    }
}
