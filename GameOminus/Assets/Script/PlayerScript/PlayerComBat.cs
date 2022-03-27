using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComBat : MonoBehaviour
{
    public Animator myanim;
    public bool isAttacking = false;
    public static PlayerComBat instance;


    public Animator ImPackAttack;
    public float attackSlash = 2f;
    float AttackTime = 0f;


    public Transform attackMark;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask BossLayers;

    public int ATTDamage = 20;

    

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        myanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
        Attack();
        
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            soundmanager.instance.Patk();
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackMark.position, attackrange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                
                Debug.Log("we hit " + enemy.name);

                enemy.GetComponent<Enemy>().TakeDamage(ATTDamage);

                
            }
            Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackMark.position, attackrange, BossLayers);
            foreach (Collider2D Boss in hitBoss)
            {

                Debug.Log("we hit " + Boss.name);

                Boss.GetComponent<BossHealth>().TakeDamageBosss(ATTDamage);
            }


        }
    }
   

    private void OnDrawGizmos()
    {
        if (attackMark == null)
            return;
        Gizmos.DrawWireSphere(attackMark.position, attackrange);
    }


}
