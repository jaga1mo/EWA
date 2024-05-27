using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    [SerializeField] public Image staminaBar;
    [SerializeField] private PlayerMovement stamina;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currS = stamina.currentStamina;
        float maxS = stamina.maxStamina;
        staminaBar.fillAmount = currS / maxS;
    }
}
