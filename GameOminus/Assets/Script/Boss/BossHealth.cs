using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int health = 1500;
	
	public Animator animator;

	public bool isInvulnerable = false;

	public float timeLeft;

	public static BossHealth instance;

    public void Awake()
    {
		instance = this;

	}
    void Start()
	{

	}
	public void TakeDamageBosss(int damageBoss)
	{
		if (isInvulnerable)
			return;

		health -= damageBoss;
		animator.SetTrigger("Hunt");
		if (health <= 750)
		{
			SoundBoss.instance.BossRange();
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			
			Die();
			StartCoroutine(delayDead());
			
		}
	}

	 public void Die()
	{
		Debug.Log("E DEAD");
		
		animator.SetBool("isDead", true);
		SoundBoss.instance.BossDead();
		this.enabled = false;
		NPCDESTROY2.instance.Destroy();
		
	}
	

	IEnumerator delayDead()
	{
		
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	
	}
}
