using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speedOnDesktop;
    public float speedOnPhone;
    private float speed;
    public bool illuminated = true;
    public bool activePlayer = true;
    public float timeToRevive = 0.01f;
    public float timeToCheckDeath = 0.1f;
    public GameObject lastLightVisited;
    private GameController gameController;
    public Joystick joystick;
    private float movDirX;
    private float movDirY;

    public Animator animator;
    private StatusGame statusGame;
    private ChangeScene changeScene;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.Find("GameController"))
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }
        joystick = FindObjectOfType<Joystick>();
        statusGame = GameObject.Find("StatusGame").GetComponent<StatusGame>();
        changeScene = GameObject.Find("StatusGame").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (illuminated && activePlayer)
        {
            if (statusGame.playOnPhone)
            {
                movDirX = joystick.Horizontal;
                movDirY = joystick.Vertical;
                speed = speedOnPhone;
                animator.SetFloat("Horizontal", joystick.Horizontal);
                animator.SetFloat("Vertical", joystick.Vertical);
                
            } else
            {
                movDirX = Input.GetAxis("Horizontal");
                movDirY = Input.GetAxis("Vertical");
                speed = speedOnDesktop;
                animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
                animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            }
            rb.velocity = new Vector2(movDirX * speed, movDirY * speed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }


    }

    public void Die()
    {
        StartCoroutine("IlluminatedZone");
    }

    IEnumerator IlluminatedZone()
    {
        illuminated = false;
        yield return new WaitForSeconds(timeToCheckDeath);
        if (!illuminated)
        {
            if (statusGame.lives > 0)
            {
                //StopAllCoroutines();
                StartCoroutine("RestOneLife");
            }
            else
            {
                //game over
            }
        }
    }

    IEnumerator RestOneLife()
    {
        statusGame.lives--;
        FindObjectOfType<AudioController>().Play("Life");
        yield return new WaitForSeconds(timeToRevive);
        transform.position = lastLightVisited.transform.GetChild(0).transform.position;
        //illuminated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.EnterFinal();
        }
        if (collision.gameObject.CompareTag("EndAnimation"))
        {
            changeScene.NextScene("SecondScene");
        }
    }

}
