using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    [SerializeField] private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currH = playerHealth.currentHealth;
        float maxH = playerHealth.maxHealth;
        healthBar.fillAmount = currH/maxH;
    }
}
