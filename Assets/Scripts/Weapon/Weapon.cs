using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    [SerializeField] private int BulletCount;

    protected Shootable shooter;

    public abstract void OnHitWith(Character character);
    public abstract void Move();
    public void Init(int _damage, Shootable _owner)
    {
        Damage = _damage;
        shooter = _owner;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 6f);
    }
    public int GetShootDirection()
    {
        float shootDir = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shootDir > 0)
            return 1;
        else return -1;
    }
}
