using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultControl : MonoBehaviour
{
    GameObject resultTime;
    GameManager gameManager;

    void Start()
    {
        resultTime = GameObject.Find("ResultTime");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(GameObject.Find("BackgroundMusic"));
    }

    void Update()
    {
        resultTime.GetComponent<Text>().text = gameManager.min.ToString() + "Ка " + gameManager.sec.ToString() + "УЪ";
    }

    public void Retry()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;

        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("EventSystem"));
    }
}
