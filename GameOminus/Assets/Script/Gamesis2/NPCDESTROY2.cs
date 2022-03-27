using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDESTROY2 : MonoBehaviour
{
    public static NPCDESTROY2 instance;
    [SerializeField] private GameObject fog2;
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
        fog2.SetActive(false);
    }
}
