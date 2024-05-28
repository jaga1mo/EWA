using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDamage : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private TMP_Text wandLabel;
    private float maxDuration = 0.3f;
    private float maxDuration2 = 0.3f;
    public int damage = 1;
    public int heal = 2;
    List<Collider> InRange = new List<Collider>();
    [SerializeField] private ParticleSystem VFX;
    [SerializeField] private ParticleSystem VFX2;
    private float duration = 0;
    private float duration2 = 0;
    public GameObject AttackSound;
    public GameObject HealSound;
    // Start is called before the first frame update
    void Start()
    {
        AttackSound.SetActive(false);
        HealSound.SetActive(false);
        VFX.Stop();
        VFX2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        duration-=Time.deltaTime;
        print(duration);
        if (duration <= 0f)
        {
            print("tu gaidys");
            VFX.Stop();
        }
        duration2-=Time.deltaTime;
        if (duration2 <= 0f)
        {
            VFX2.Stop();
        }
        if (Input.GetMouseButtonDown(0) && !PlayerMovement.dialogue)
        {
            int wandUses = int.Parse(wandLabel.text);
            if (wandUses > 0)
            {
                if(AttackSound.activeSelf == true)
                {
                    AttackSound.SetActive(false);
                }
                AttackSound.SetActive(true);
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
                if(HealSound.activeSelf == true)
                {
                    HealSound.SetActive(false);
                }
                HealSound.SetActive(true);
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