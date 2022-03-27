using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundJump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] audioJump;
    AudioSource audioSource;

    public static SoundJump instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Pjump()
    {
        audioSource.PlayOneShot(audioJump[0]);
    }
    public void Pjump2()
    {
        audioSource.PlayOneShot(audioJump[1]);
    }
}
