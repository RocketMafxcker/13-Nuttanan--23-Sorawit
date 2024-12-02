using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : Enemy
{
    [SerializeField] private GameObject objDrop;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    void Start()
    {
        Init(1);
    }


    private void FixedUpdate()
    {
        Behavior();
        IsDrop();
    }
    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        velocity *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public override void IsDrop()
    {
        if (IsDead())
        {
            Debug.Log("Drop");
            GameObject obj = Instantiate(objDrop, this.transform);
            BulletPlus bulletPlus = obj.GetComponent<BulletPlus>();
            Destroy(this.gameObject);
        }
    }
}

