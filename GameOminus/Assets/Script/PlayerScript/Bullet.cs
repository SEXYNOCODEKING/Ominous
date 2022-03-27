using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 15f;
	public int damage = 100;
	public Rigidbody2D rb;
	public GameObject impactEffect;


	// Use this for initialization

	 void Start ()
    {
		soundmanager.instance.Pshot();
		rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
	{

		Enemy enemy = hitInfo.GetComponent<Enemy>();
		BossHealth Bosssun = hitInfo.GetComponent<BossHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			

		}
		if (Bosssun != null)
		{
			Bosssun.TakeDamageBosss(damage);

		}
		

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
}
