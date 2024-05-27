using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDamage : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private TMP_Text wandLabel;
    public int maxDuration = 150;
    public int maxDuration2 = 150;
    public int damage = 1;
    public int heal = 2;
    List<Collider> InRange = new List<Collider>();
    [SerializeField] private ParticleSystem VFX;
    [SerializeField] private ParticleSystem VFX2;
    public int duration = 0;
    public int duration2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        VFX.Stop();
        VFX2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0)
        {
            duration--;
            if (duration <= 0)
            {
                VFX.Stop();
            }
        }
        if (duration2 > 0)
        {
            duration2--;
            if (duration2 <= 0)
            {
                VFX2.Stop();
            }
        }
        if (Input.GetMouseButtonDown(0) && !PlayerMovement.dialogue)
        {
            int wandUses = int.Parse(wandLabel.text);
            if (wandUses > 0)
            {
                DealDamage(damage);
                wandUses--;
                wandLabel.text = wandUses.ToString();
            }
        }
        if (Input.GetMouseButtonDown(1) && !PlayerMovement.dialogue)
        {
            int wandUses = int.Parse(wandLabel.text);
            if (wandUses > 0)
            {
                HealSelf(heal);
                wandUses--;
                wandLabel.text = wandUses.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //print(other.gameObject.name + " entered attack range");
            InRange.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //print(other.gameObject.name + " left attack range");
            InRange.Remove(other);
        }
    }

    void DealDamage(int damage)
    {
        VFX.Play();
        duration = maxDuration;
        foreach (var coll in InRange)
        {
            Health enemyHealthScript = coll.GetComponent<Health>();
            if (enemyHealthScript != null)
            {
                enemyHealthScript.TakeDamage(damage);
            }
        }
    }

    void HealSelf(int heal)
    {
        VFX2.Play();
        duration2 = maxDuration2;
        playerHealth.TakeDamage(-1 * heal);
    }
}