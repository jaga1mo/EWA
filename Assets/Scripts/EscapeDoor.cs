using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeDoor : MonoBehaviour
{
    [SerializeField] private GameObject Lock1;
    [SerializeField] private GameObject Lock2;
    [SerializeField] private GameObject Lock3;
    public GameObject LockSound;
    private bool PlayerInRange = false;
    private bool Unlocking = false;
    private float wait = 0f;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        LockSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.dialogue)
        {
            if
            (InventoryController.GetItemCount("key1")>0 && InventoryController.GetItemCount("key2")>0 && InventoryController.GetItemCount("key3")>0){
                Unlocking = true;
            }
            else
            {
                PromptUI.DisplayPrompt("You are not worthy");
            }
        }
        if(Unlocking){
            wait-=Time.deltaTime;
            if(wait<=0f)
            {
                LockSound.SetActive(false);
                LockSound.SetActive(true);
                switch(index)
                {
                    case 0:
                        Lock1.SetActive(false);
                        break;
                    case 1:
                        Lock2.SetActive(false);
                        break;
                    case 2:
                        Lock3.SetActive(false);
                        break;
                    case 3:
                        SceneManager.LoadSceneAsync("VictoryScene", LoadSceneMode.Single);
                        break;
                }
                index++;
                wait = 2f;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerObj")
        {
            PlayerInRange = true;
            PromptUI.DisplayPrompt("E: Escape");
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
