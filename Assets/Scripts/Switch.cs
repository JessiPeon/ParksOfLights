using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite onSprite;
    public Sprite offSprite;
    public bool inZone = false;
    public bool on = false;
    private GameObject playerInZone;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inZone)
        {

            if (playerInZone.GetComponent<Player>().activePlayer && (Input.GetKeyDown(KeyCode.X) || (GameObject.Find("Fixed Joybutton Activation").GetComponent<TurnOnOffButton>().buttonPressed && gameController.buttonTimes == 0)))
            {
                gameController.buttonTimes++;
                on = !on;
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<Light>().TurnOnOff();
                }
            }
        }

        if (on)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = offSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInZone = collision.gameObject;
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inZone = false;
        }
    }


}
