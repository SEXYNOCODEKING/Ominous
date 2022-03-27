using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int HP = 100;
    int CRHP;
    public float timeLeft;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CRHP = HP;
    }
    public void TakeDamage(int damage)
    {
        //BossHealth.instance.health -= damage;
        CRHP -= damage;
        animator.SetTrigger("Hunt");
        soundmanager.instance.Monhit();
        if (CRHP <= 0)
        {
            Die();
            StartCoroutine(delayDead());
            Player.instance.SP++;
        }
    }

    
    void Die()
    {
        soundmanager.instance.Mondead();
        Debug.Log("E DEAD");
        animator.SetBool("isDead", true);
        this.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator delayDead()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    

}
