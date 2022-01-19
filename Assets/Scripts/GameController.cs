using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool playOnPhone;
    public int buttonTimes = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (!playOnPhone)
        {
            foreach (GameObject control in GameObject.FindGameObjectsWithTag("Joystick"))
            {
                control.SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playOnPhone)
        {
            switchPlayer();
        }
    }

    public void switchPlayer()
    {
        GameObject stella = GameObject.Find("StellaPoint");
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            player.GetComponent<Player>().activePlayer = !player.GetComponent<Player>().activePlayer;
            if (!player.GetComponent<Player>().activePlayer)
            {
                stella.GetComponent<TrailRenderer>().enabled = false;
                stella.transform.position = player.transform.position;
            }

        }
        stella.GetComponent<TrailRenderer>().enabled = true;
        stella.GetComponent<SwitchEffect>().moveEffect = true;
    }
}
