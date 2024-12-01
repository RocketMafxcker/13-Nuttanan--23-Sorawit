using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUpControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            SkillUp powerUp = GetComponent<SkillUp>();

            if (powerUp != null && player != null)
            {
                powerUp.ApplySkillUp(player);
                Destroy(gameObject);
            }
        }
    }

}