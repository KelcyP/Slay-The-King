using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float playerFullHP;
    public int playerCurHP;
    GameObject hpImage;
    Transform UIretry;

    GameObject timerText;
    float time = 0.0f;
    public int min, sec;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        timerText = GameObject.Find("Time");
        UIretry = GameObject.Find("RetryParent").transform.Find("Retry");
        hpImage = GameObject.Find("HP");
    }

    void Update()
    {
        if(playerCurHP <= 0)
        {
            hpImage.GetComponent<Image>().fillAmount = playerCurHP / playerFullHP;
            Time.timeScale = 0; //°ÔÀÓ ³» ½Ã°£ ¸ØÃã
            UIretry.gameObject.SetActive(true);
        }
        else if (playerCurHP > 0)
        {
            hpImage.GetComponent<Image>().fillAmount = playerCurHP / playerFullHP;
        }

        if(SceneManager.GetActiveScene().name != "ClearScene")
        {
            time += Time.deltaTime;
        }

        min = (int)time / 60;
        sec = (int)time % 60;

        timerText.GetComponent<Text>().text = min.ToString() + " : " + sec.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;

        Destroy(gameObject);
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("EventSystem"));
        Destroy(GameObject.Find("BackgroundMusic"));
    }
}
