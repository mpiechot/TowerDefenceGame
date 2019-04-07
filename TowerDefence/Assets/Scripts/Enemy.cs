using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float normalSpeed = 10f;
    [HideInInspector]
    public float speed;
    public int worth = 50;

    public GameObject deathEffect; 
    
    void Start()
    {
        speed = normalSpeed;
    }
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if(health <= 0)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = normalSpeed * (1 - pct);
    }
    private void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.money += worth;
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
