using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHP = 10f;

    public float health;
    [SerializeField] private Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHP;
        healthSlider.minValue = 0;
        healthSlider.maxValue = maxHP;
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void TakeDamage(float dmg){
        health -= dmg;
        healthSlider.value = health;
        if(health <= 0 ){
            Debug.Log("Game Over");
        }
    }

}
