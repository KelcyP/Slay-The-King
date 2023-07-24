using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    GameManager gameManager;
    float xmoveSize, ymoveSize, xmove, ymove;
    public float speed;
    public int camSpeed, getDam;
    float hAxis;
    float vAxis;

    Vector3 moveVec;
    Animator anim;
    Rigidbody rigid;
    GameObject sound;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sound = GameObject.Find("AudioController");
    }

    void Update()
    {
        xmoveSize = Input.GetAxis("Mouse Y");
        ymoveSize = Input.GetAxis("Mouse X");

        xmove = transform.eulerAngles.x - xmoveSize;
        ymove = transform.eulerAngles.y + ymoveSize;

        if (Input.GetMouseButton(1))
        {
            transform.eulerAngles = new Vector3(xmove * camSpeed, ymove * camSpeed, 0);
        }

        vAxis = Input.GetAxisRaw("Vertical");
        hAxis = Input.GetAxisRaw("Horizontal");

        moveVec = transform.forward * vAxis + transform.right * hAxis;

        rigid.velocity = moveVec * speed;

        anim.SetBool("isWalking", Input.GetButton("Vertical") || Input.GetButton("Horizontal"));

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            sound.GetComponent<AudioController>().PlayerHit();
            gameManager.playerCurHP -= getDam;
            gameObject.layer = 11;
            if (gameManager.playerCurHP <= 0)
            {
                sound.GetComponent<AudioController>().PlayerDead();
                Destroy(GameObject.Find("BackgroundMusic"));
            }

            Invoke("OffDamaged", 2);
        }
    }

    void OffDamaged()
    {
        gameObject.layer = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("SecondScene"))
        {
            SceneManager.LoadScene("SecondScene");
        }
        else if (other.gameObject.name.Equals("ThirdScene"))
        {
            SceneManager.LoadScene("ThirdScene");
        }

        if (other.tag == "Stairs")
        {
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if(other.tag == "Bomb")
        {
            sound.GetComponent<AudioController>().PlayerHit();
            gameManager.playerCurHP -= 10;
        }

        if (other.gameObject.name.Equals("GolemKill"))
        {
            gameManager.playerCurHP -= 100;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stairs")
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
