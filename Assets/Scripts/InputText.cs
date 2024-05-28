using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputText : MonoBehaviour
{
    public GameObject inputWindow;
    public GameObject reward;
    public TMP_InputField inputField;
    private bool PlayerInRange = false;
    public string Solution;
    public bool Solving = false;
    public bool Solved = false;
    string Prompt = "E: Solve riddle";
    PickupItemBehaviour item;

    void Start()
    {
        item = reward.GetComponentInChildren<PickupItemBehaviour>();
        inputWindow.SetActive(false);
        reward.SetActive(false);
    }

    void Update()
    {
        if (!Solved)
        {
            if (InventoryController.GetItemCount(item.Item) > 0)
            {
                Solved = true;
                Prompt = "your knowledge triumphs";
            }
            if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.dialogue && !Solving)
            {
                PlayerMovement.dialogue = true;
                inputWindow.SetActive(true);
                Solving = true;
                PromptUI.DeletePrompt();
            }
            if (Solving)
            {
                Solve();
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerMovement.dialogue = false;
                    inputWindow.SetActive(false);
                    Solving = false;
                    PromptUI.DisplayPrompt(Prompt);
                }
                if (!PlayerInRange)
                {
                    PlayerMovement.dialogue = false;
                    inputWindow.SetActive(false);
                    Solving = false;
                }
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerObj")
        {
            PlayerInRange = true;
            PromptUI.DisplayPrompt(Prompt);
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

    void Solve()
    {
        if (Solution.Equals(inputField.text, System.StringComparison.CurrentCultureIgnoreCase))
        {
            reward.SetActive(true);
            if(reward.activeSelf)
            {
                print("Aktyvus");
            }
            Solved = true;
            Prompt = "your knowledge triumphs";
            PlayerMovement.dialogue = false;
            inputWindow.SetActive(false);
            Solving = false;
            PromptUI.DisplayPrompt(Prompt);
        }
    }
}
