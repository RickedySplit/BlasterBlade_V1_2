using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    public float maxHealth = 20f;
    public float currentHealth = 20f;
    public Slider healthSlider;
    public float lastDamageAmountTaken;

    public GameObject FloatingTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        healthSlider.maxValue = maxHealth;

        if (currentHealth <= 0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        lastDamageAmountTaken = damage;
        currentHealth -= damage;

        if (FloatingTextPrefab != null)
        {
            lastDamageAmountTaken = damage;
            Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
            FloatingTextPrefab.GetComponent<TextMeshPro>().SetText(lastDamageAmountTaken.ToString());
            //ShowFloatingText();
        }
    }

    //void ShowFloatingText()
    //{
    //    Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
    //    //, transform
    //}
}
