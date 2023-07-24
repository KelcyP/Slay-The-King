using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    public GameObject firePrefab;
    public Transform bulletPos;

    float delayTime;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject fireball = Instantiate(firePrefab, bulletPos.position, bulletPos.rotation) as GameObject;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            fireball.GetComponent<FireControl>().Shoot(worldDir.normalized * 2000);
            
        }
    }
}
