using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawnPoint { get; set; }
    [field: SerializeField] public float BulletSpawnTime { get; set; }
    [field: SerializeField] public float BulletTimer { get; set; }
    [field: SerializeField] public int BulletCount { get; set; }
    [field: SerializeField] public float JumpCount { get; set; }
    public float maxSpeed = 10f;
	bool facingRight = true;

	public float jumpForce = 700.0f;

	// Use this for initialization
	void Start () 
	{
        Init(1);
        BulletSpawnTime = 0.5f;
        BulletTimer = 2.0f;
        BulletCount = 1;
        JumpCount = 3;
        rb = GetComponent<Rigidbody2D>	();
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && JumpCount > 0)
		{
			rb.AddForce(new Vector2(0, jumpForce));
			JumpCount -= 1;
		}

        BulletTimer -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && BulletTimer <= 0 && BulletCount > 0)
        {
            Shoot();
        }
    }

	void FixedUpdate () 
	{

		float move = Input.GetAxis("Horizontal");

		rb.velocity = new Vector2(move*maxSpeed, rb.velocity.y);

		if(move > 0 && !facingRight)
			Flip();
		else if( move < 0 && facingRight )
			Flip();
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    public void Shoot()
    {
        GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
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
    //SkillUp
    public void SkillUp(int bulletPlus)
    {
        BulletCount += bulletPlus;
        //UpdateBulletText();
    }

    public void SkillUp(float jumpPlus)
    {
        JumpCount += jumpPlus;
        //UpdateJumpText();
    }

}
