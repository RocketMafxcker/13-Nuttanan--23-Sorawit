using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;



public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }
    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }
    [field: SerializeField] public int BulletCount { get; set; }

    void Start()
    {
        Init(1);
        BulletSpawnTime = 1.0f;
        BulletTimer = 2.0f;
        BulletCount = 1;
    }
    private void Update()
    {
        BulletTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && BulletTimer <= 0 && BulletCount > 0)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
        BulletPng bulletPng = obj.GetComponent<BulletPng>();
        bulletPng.Init(1, this);
        BulletTimer = BulletSpawnTime;
        BulletCount -= 1;//BulletBar
    }
    public void OnHitWith(Character character)
    {
        if (character is Enemy)
            TakeDamage(1,character);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        OnHitWith(other.gameObject.GetComponent<Character>());
    }
}
