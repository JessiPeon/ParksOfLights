using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : MonoBehaviour
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
        changeScene = GameObject.Find("StatusGame").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
 


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("EndAnimation"))
        {
            changeScene.NextScene("SecondScene");
        }
    }

}
