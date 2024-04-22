using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemBehaviour : MonoBehaviour
{
    [SerializeField] private string Item;
    [SerializeField] private int Amount;

    private bool PlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.dialogue)
        {
            InventoryController.ObtainItem(Item, Amount);
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
