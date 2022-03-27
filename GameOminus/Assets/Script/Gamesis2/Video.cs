using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Video : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] private GameObject bG;
    [SerializeField] private GameObject logo;
   

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bG.SetActive(false);
        logo.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            video.Stop();
            video.gameObject.SetActive(false);
            bG.SetActive(true);
            logo.SetActive(true);
           
        }
    }
}
