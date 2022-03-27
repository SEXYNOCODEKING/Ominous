using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // ME CODE
    public float speed = 10f;
    public float jump = 5f;
    public float DbJ;
    public int HP = 100;
    public int Bullet = 3;
    public float SP = 0f;
    //public int HPUP = 30;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anime;
    [SerializeField] private bool isGround;
    [SerializeField] private bool isMove;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private Slider HPSilder;
    [SerializeField] private Text HPText;
    [SerializeField] private Slider SPSilder;

    [SerializeField] private bool isFlash = false;


    //[SerializeField] private Button HPUPBU;
    //[SerializeField] private Button BUUP;


    [HideInInspector] public bool isFacingRight = true;

    public static Player instance;

    private void Start()
    {
        
    }

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        instance = this;

    }
    

    // Update is called once per frame
    private void Update()
    {
        Run();
        FilpSprite();
        CheckGround();
        Jump();
        AnimePlayer();

        
        HPSilder.value = HP;
        SPSilder.value = SP;

        if (SP > 5)
        {
            SP -= 1;
        }
    }


    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        isMove = (Input.GetAxisRaw("Horizontal") != 0);
        

    }
    void FilpSprite()
    {

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
           
            characterScale.x = -2;
            isFacingRight = false;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 2;
            isFacingRight = true;
        }
        transform.localScale = characterScale;
    }
    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(transform.position, 1.5f, groundLayer);
    }
    void Jump()
    {
        if (Input.GetButton("Jump") && isGround)
        {
            SoundJump.instance.Pjump();
            rb.velocity = new Vector2(rb.velocity.x, jump);
            jump = 10;
            DbJ = 1;
        }
        else if (Input.GetButtonDown("Jump") && DbJ == 1)
        {
            SoundJump.instance.Pjump2();
            rb.velocity = new Vector2(rb.velocity.x, jump);
            jump = 5;
            DbJ--;
        }
    }
    void AnimePlayer()
    {
        anime.SetBool("isMove", isMove);
        anime.SetBool("isGround", isGround);

    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        StartCoroutine(DamageAnimation());

        if (HP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    void Damage()
    {
        HP -= 5;
        isFlash = true;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Flash());
        
    }
    IEnumerator Flash()
    {
        for (int n = 0; n < 10; n++)
        {
            sr.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
        isFlash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyFly" && !isFlash)
        {
            Damage();
        }
    }
}
