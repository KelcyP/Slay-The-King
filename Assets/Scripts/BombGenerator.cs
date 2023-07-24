using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject bombPrefab;
    float span = 3.0f;
    float delta = 0;
    GameObject sound;


    void Start()
    {
        sound = GameObject.Find("AudioController");
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject item = Instantiate(bombPrefab);
            GameObject item1 = Instantiate(bombPrefab);
            GameObject item2 = Instantiate(bombPrefab);
            GameObject item3 = Instantiate(bombPrefab);
            GameObject item4 = Instantiate(bombPrefab);
            float x1 = Random.Range(-12, 13);
            float x2 = Random.Range(-12, 13);
            float x3 = Random.Range(-12, 13);
            float x4 = Random.Range(-12, 13);
            float x5 = Random.Range(-12, 13);
            float z1 = Random.Range(100, 300);
            float z4 = Random.Range(100, 300);
            float z2 = Random.Range(300, 400);
            float z5 = Random.Range(300, 400);
            float z3 = Random.Range(400, 500);
            item.transform.position = new Vector3(x1, 90, z1);
            item1.transform.position = new Vector3(x2, 90, z2);
            item2.transform.position = new Vector3(x3, 90, z3);
            item3.transform.position = new Vector3(x4, 90, z4);
            item4.transform.position = new Vector3(x5, 90, z5);
            sound.GetComponent<AudioController>().Canon();
        }
    }
}
