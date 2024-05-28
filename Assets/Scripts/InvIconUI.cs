using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvIconUI : MonoBehaviour
{
    [SerializeField] private TMP_Text txtLabel;
    [SerializeField] private GameObject inventoryWindow;
    private Button button;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponentInChildren(typeof(Button), true) as Button;
        image = gameObject.GetComponentInChildren(typeof(Image), true) as Image;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryWindow.activeSelf)
        {
            int items = InventoryController.GetItemCount(gameObject.name);
            if (items > 0)
            {
                button.enabled = true;
                image.enabled = true;
                print(gameObject.name);
                if(txtLabel != null)
                {
                    txtLabel.text = items.ToString();
                }
            }
            else
            {
                button.enabled = false;
                image.enabled = false;
                txtLabel.text = "";
            }
        }
    }
}
