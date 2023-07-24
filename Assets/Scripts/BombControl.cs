using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl : MonoBehaviour
{
    public float dropSpeed = -0.3f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, this.dropSpeed, 0);
        if(transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other){

        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
