using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Shootable
{
    GameObject Bullet { get; set; }
    Transform BulletSpawnPoint { get; set; }

    float BulletSpawnTime { get; set; }
    float BulletTimer { get; set; }
    void Shoot();
}
