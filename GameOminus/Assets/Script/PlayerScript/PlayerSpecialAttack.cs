using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    public static PlayerSpecialAttack instance;
    public Animator ImPackAttack;
    public Transform ImPackSMark;
    public float ImPackrange = 0.5f;
    public LayerMask enemyLayers;
    public int ImPackDamage = 500;
    float AttackTime = 0f;
    public float attackSlash = 2f;
    public LayerMask BossLayers;

    public GameObject ImEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= AttackTime)
        {
            if (Input.GetKeyDown(KeyCode.R) && Player.instance.SP >= 5)
            {

                Impack();
                AttackTime = Time.time + 1f / attackSlash;
                soundmanager.instance.Puti();

            }
        }
    }

    void Impack()
    {
        ImPackAttack.SetTrigger("imPack");
        Instantiate(ImEffect, transform.position, Quaternion.identity);
        Player.instance.SP = 0;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ImPackSMark.position, ImPackrange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {

            Debug.Log("we hit " + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(ImPackDamage);
        }
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(ImPackSMark.position, ImPackrange, BossLayers);
        foreach (Collider2D Boss in hitBoss)
        {

            Debug.Log("we hit " + Boss.name);

            Boss.GetComponent<BossHealth>().TakeDamageBosss(ImPackDamage);
        }

    }
    private void OnDrawGizmos()
    {
        if (ImPackSMark == null)
            return;
        Gizmos.DrawWireSphere(ImPackSMark.position, ImPackrange);
    }
}
