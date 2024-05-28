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
                if(gameObject.name!="key1" || gameObject.name!="key2" || gameObject.name!="key3"){
                    txtLabel.text = items.ToString();
                }
                else{
                    txtLabel.text = "";
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
