using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float hitHealth;
    [SerializeField] private float maxHealth = 5;
    [SerializeField] private float damage = 1;

    private void Start()
    {
        hitHealth = maxHealth;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitHealth -= damage;
            if (hitHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
