using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WandFeedback : MonoBehaviour
{
    [SerializeField] private GameObject brokenWand;
    [SerializeField] private GameObject fixedWand;
    [SerializeField] private TMP_Text wandUses;
    private int usesMemory;
    // Start is called before the first frame update
    void Start()
    {
        usesMemory = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(usesMemory == int.Parse(wandUses.text))
        {
            return;
        }
        else
        {
            usesMemory = int.Parse(wandUses.text);
            if(usesMemory > 0)
            {
                fixedWand.SetActive(true);
                brokenWand.SetActive(false);
            }
            else
            {
                fixedWand.SetActive(false);
                brokenWand.SetActive(true);
            }
        }
    }
}
