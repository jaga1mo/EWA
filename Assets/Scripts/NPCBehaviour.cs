using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private RawImage image;
    private bool PlayerInRange = false;
    public Dialogue dialogue;
    private Transform ghost;
    private bool activeEnemy = false;
    public GameObject smallMouse;

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Start()
    {
        ghost = GetComponent<Transform>();
    }

    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.dialogue)
        {
            PlayerMovement.dialogue = true;
            DialogueUI.DisplayDialogue(dialogue, textLabel, image);
            if(ghost.parent.name == "GhostEntity4" && !activeEnemy)
            {
                Instantiate(smallMouse, transform.position + new Vector3(3, 0, 3), Quaternion.identity);
                Instantiate(smallMouse, transform.position + new Vector3(3, 0, -3), Quaternion.identity);
                Instantiate(smallMouse, transform.position + new Vector3(2, 0, 3), Quaternion.identity);
                Instantiate(smallMouse, transform.position + new Vector3(2, 0, -3), Quaternion.identity);
                Instantiate(smallMouse, transform.position + new Vector3(3, 0, 0), Quaternion.identity);
                activeEnemy = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerObj")
        {
            PlayerInRange = true;
            PromptUI.DisplayPrompt("E: Talk");
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
