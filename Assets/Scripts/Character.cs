using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //public HealthBar healthBar;
    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public Animator anim;
    public Rigidbody2D rb;

    public virtual void Init(int newHealth)
    {
        Health = newHealth;
        //healthBar.SetMaxHealth(newHealth);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public bool IsDead(Character character)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }
    public void TakeDamage(int _damage, Character character)
    {
        Health -= _damage;
        //healthBar.UpdateHealthBar(Health);
        IsDead(character);
    }
}