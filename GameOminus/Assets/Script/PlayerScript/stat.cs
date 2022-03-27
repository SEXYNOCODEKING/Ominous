using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stat : MonoBehaviour
{

    public float coin = 1f;

    public int UPATT = 100;
    public int UPHP = 100;
    public int UPBUL = 3;
   
    public int MaxBUL = 3;
    public int MaxHP = 200;


    public static stat instance;
    [SerializeField] public Text atknum;
    [SerializeField] public Text arrnum;
    [SerializeField] public Text hpnum;

    private void Awake()
    {
        instance = this;
    }

    public void atkup()
    {
        if (coin >= 1)
        {
            PlayerComBat.instance.ATTDamage = (PlayerComBat.instance.ATTDamage + UPATT);
            coin--;
            atknum.text = "" + PlayerComBat.instance.ATTDamage;
            stat.instance.coin--;
            NPCDESTROY1.instance.Destroy();
        }
    }

    public void arrowup()
    {
        if (coin >= 1)
        {

            Player.instance.Bullet = (Player.instance.Bullet + UPBUL) ;
            coin--;
            arrnum.text = "" + Player.instance.Bullet;
            stat.instance.coin--;
            NPCDESTROY1.instance.Destroy();
        }
    }

    public void hpup()
    {
        if (coin >= 1)
        {
            Player.instance.HP = (Player.instance.HP + UPHP);
            coin--;
            hpnum.text = "" + Player.instance.HP;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Textstat();
    }
    //public void Maxvoid()
    //{
        //if ()
        //{
           // Player.instance.Bullet = (MaxBUL);
           // Player.instance.HP = (MaxHP);
        //}
    //}
    void Textstat()
    {
        atknum.text = "" + PlayerComBat.instance.ATTDamage;
    }
    
}
