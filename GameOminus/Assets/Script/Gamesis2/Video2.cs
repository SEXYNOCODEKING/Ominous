using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Video2 : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            video.Stop();
            video.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneName);
        }
    }
}
