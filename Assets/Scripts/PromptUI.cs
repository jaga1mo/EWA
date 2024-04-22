using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PromptUI : MonoBehaviour
{
    [SerializeField] private TMP_Text txtLabel;
    public static TMP_Text textLabel;

    void Start()
    {
        textLabel = txtLabel;
    }

    public static void DisplayPrompt(string prompt)
    {
        textLabel.text = prompt;
    }

    public static void DeletePrompt()
    {
        textLabel.text = "";
    }
}
