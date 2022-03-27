using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutoreal : MonoBehaviour
{
    [SerializeField] private GameObject Shop;
    int pause = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showMenu()
    {
        Shop.SetActive(true);
        Time.timeScale = 0;
        pause += 1;
       
    }
    public void hideMenu()
    {
        Shop.SetActive(false);
        Time.timeScale = 1;
        pause += -1;
        
    }
}
