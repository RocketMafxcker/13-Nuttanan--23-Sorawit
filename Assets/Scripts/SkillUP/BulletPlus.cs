using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlus : SkillUp
{
    int AddBullet;

    private void Start()
    {
        AddBullet = 3;
    }

    public override void ApplySkillUp(Player player)
    {
       player.SkillUp(AddBullet);
    }
}
