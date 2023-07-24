using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviControl : MonoBehaviour
{
    public Transform target;

    NavMeshAgent nav;
    Animator anim;
    public int monspeed;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= 50)
        {
            nav.SetDestination(target.position);
            nav.speed = monspeed;
            anim.SetBool("isMove", true);
        }
        if (anim.GetBool("isDead"))
        {
            nav.isStopped = true;
        }
    }
}
