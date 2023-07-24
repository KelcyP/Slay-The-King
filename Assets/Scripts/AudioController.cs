using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioClip villager;
    public AudioClip skeleton;
    public AudioClip golem;
    public AudioClip playerHit;
    public AudioClip canon;
    public AudioClip playerDead;
    public AudioClip clearSound;

    AudioSource aud;

    void Start()
    {
        aud = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "ClearScene")
        {
            ClearSound();
        }
    }


    void Update()
    {

    }

    public void PlayerHit()
    {
        aud.PlayOneShot(playerHit);
    }

    public void Villager()
    {
        aud.PlayOneShot(villager);
    }

    public void Skeleton()
    {
        aud.PlayOneShot(skeleton, 0.5f);
    }

    public void Golem()
    {
        aud.PlayOneShot(golem, 0.2f);
    }

    public void Canon()
    {
        aud.PlayOneShot(canon, 0.1f);
    }

    public void PlayerDead()
    {
        aud.PlayOneShot(playerDead, 0.5f);
    }

    public void ClearSound()
    {
        aud.PlayOneShot(clearSound, 0.8f);
    }
}
