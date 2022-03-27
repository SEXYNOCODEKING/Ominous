using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audio;
    AudioSource audioSource;

    public static soundmanager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void Pjump()
    {
        audioSource.PlayOneShot(audio[0]);
    }
    public void Pjump2()
    {
        audioSource.PlayOneShot(audio[1]);
    }
    public void Patk()
    {
        audioSource.PlayOneShot(audio[2]);
    }
    public void Patk2()
    {
        audioSource.PlayOneShot(audio[3]);
    }
    public void Puti()
    {
        audioSource.PlayOneShot(audio[4]);
    }
    public void Prun()
    {
        audioSource.PlayOneShot(audio[5]);
    }
    public void Pshot()
    {
        audioSource.PlayOneShot(audio[6]);
    }
    public void Pdie()
    {
        audioSource.PlayOneShot(audio[7]);
    }
    public void Mon1atk()
    {
        audioSource.PlayOneShot(audio[8]);
    }
    public void Monhit()
    {
        audioSource.PlayOneShot(audio[9]);
    }
    public void Mondead()
    {
        audioSource.PlayOneShot(audio[10]);
    }
    public void Monrun()
    {
        audioSource.PlayOneShot(audio[11]);
    }
}
