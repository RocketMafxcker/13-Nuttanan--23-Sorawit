using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //public HealthBar healthBar;
    [SerializeField] private GameObject ObjDrop;
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
    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }
    public void TakeDamage(int _damage, Character _victim)
    {
        Health -= _damage;
        //healthBar.UpdateHealthBar(Health);
        if(IsDead())
        {
            GameObject obj = Instantiate(_victim.ObjDrop, _victim.transform);
            BulletPlus bulletPlus = obj.GetComponent<BulletPlus>();
        }
    }

}