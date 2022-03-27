using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOPNPC : MonoBehaviour
{

    [SerializeField] private GameObject Shop;
    int pause = 0;
    [SerializeField] LayerMask NPC;
    [SerializeField] private bool NPCSHOP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pause == 0 && NPCSHOP)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                showMenu();
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            hideMenu();
        }
        CheckGround();
    }
    void CheckGround()
    {
        NPCSHOP = Physics2D.OverlapCircle(transform.position, 1.5f, NPC);
    }
    public void showMenu()
    {
        Shop.SetActive(true);
        Time.timeScale = 0;
        pause += 1;
        stat.instance.coin++;
    }
    public void hideMenu()
    {
        Shop.SetActive(false);
        Time.timeScale = 1;
        pause += -1;
        stat.instance.coin--;
    }
}
