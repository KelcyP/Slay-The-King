using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerControl : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    Rigidbody rigid;
    CapsuleCollider capCollider;
    Animator anim;
    GameObject sound;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        capCollider = GetComponent<CapsuleCollider>();
        sound = GameObject.Find("AudioController");
    }

    void Update()
    {
        if(curHealth == 0)
        {
            anim.SetBool("isDead", true);
            capCollider.enabled = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fire")
        {
            curHealth -= 5;

            if(this.gameObject.name == "Villager")
            {
                sound.GetComponent<AudioController>().Villager();
            }
            else if(this.gameObject.name == "Skeleton")
            {
                sound.GetComponent<AudioController>().Skeleton();
            }
            else if(this.gameObject.name == "Golem")
            {
                sound.GetComponent<AudioController>().Golem();
            }
        }

        if (other.tag == "Player")
        {
            anim.SetBool("isCollide", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("isCollide", false);
        }
    }
}
