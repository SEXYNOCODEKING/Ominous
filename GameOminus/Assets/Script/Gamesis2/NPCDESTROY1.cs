using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDESTROY1 : MonoBehaviour
{

    public static NPCDESTROY1 instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
