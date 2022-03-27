using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioBoss;
    AudioSource audioSource;

    public static SoundBoss instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
   
    public void BossDead()
    {
        audioSource.PlayOneShot(audioBoss[0]);
    }
    public void BossRange()
    {
        audioSource.PlayOneShot(audioBoss[1]);
    }
}
