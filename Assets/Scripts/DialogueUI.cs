using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    static Dialogue displaying;
    static TMP_Text displayLabel;
    static RawImage box;
    static int index = 0;
    static int left = 0;

    public static void DisplayDialogue(Dialogue dialogue, TMP_Text textLabel, RawImage image)
    {
        displaying = dialogue;
        displayLabel = textLabel;
        box = image;
        foreach (var item in dialogue.dialogue)
        {
            left++;
        }
    }

    void Update()
    {
        if(box != null)
        {
            Dialogue();
        }
    }
    void Dialogue()
    {
        if (left > 0)
        {
            box.enabled = true;
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
            {
                left--;
                index++;
            }
            try
            {
                displayLabel.text = displaying.dialogue[index];
            }
            catch { }
        }
        else
        {
            index = 0;
            box.enabled = false;
            displayLabel.text = "";
            PlayerMovement.dialogue = false;
            box = null;
        }
    }
}
