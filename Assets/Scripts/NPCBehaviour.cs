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

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && Input.GetKeyDown(KeyCode.E) && !PlayerMovement.dialogue)
        {
            PlayerMovement.dialogue = true;
            DialogueUI.DisplayDialogue(dialogue, textLabel, image);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerObj")
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerObj")
        {
            PlayerInRange = false;
        }
    }
}
