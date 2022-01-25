using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public int buttonTimes = 0;
    
    public Animator gateJinjin;
    public Animator gateRocky;
    public bool winLevel;

    public int arrivedAtEnd = 0;
    private StatusGame statusGame;
    private bool openGate = false;
    private ChangeScene changeScene;
    public Animator transition;

    // Start is called before the first frame update
    void Awake()
    {
        winLevel = false;
        statusGame = GameObject.Find("StatusGame").GetComponent<StatusGame>();
        if (!statusGame.playOnPhone)
        {
            foreach (GameObject control in GameObject.FindGameObjectsWithTag("Joystick"))
            {
                if (control.GetComponent<Image>())
                {
                    control.GetComponent<Image>().enabled = false;
                } else
                {
                    control.SetActive(false);
                }
                
            }
        }
        
        
    }

    private void Start()
    {
        changeScene = GameObject.Find("StatusGame").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !statusGame.playOnPhone)
        {
            SwitchPlayer();
        }

        bool finalLight = true;
        foreach(GameObject light in GameObject.FindGameObjectsWithTag("FinalLight"))
        {
            if (!light.GetComponent<Light2D>().enabled)
            {
                finalLight = false;
            }
        }
        if (finalLight)
        {
            DisableSwitches();
            OpenGate();
        }

    }

    public void SwitchPlayer()
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
        FindObjectOfType<AudioController>().Play("Stella");
    }

    private void OpenGate()
    {
        gateJinjin.SetTrigger("open");
        gateRocky.SetTrigger("open");
        if (!openGate)
        {
            FindObjectOfType<AudioController>().Play("Gate");
            foreach (GameObject gate in GameObject.FindGameObjectsWithTag("Gate"))
            {
                gate.GetComponent<BoxCollider2D>().enabled = false;
            }
            openGate = true;
        }
        
    }

    private void DisableSwitches()
    {
        foreach (GameObject sw in GameObject.FindGameObjectsWithTag("Switch"))
        {
            sw.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void EnterFinal()
    {
        FindObjectOfType<AudioController>().Mute("Night");
        StartCoroutine("FinalScene");
    }
    
    IEnumerator FinalScene()
    {
        FindObjectOfType<AudioController>().Play("Dream");
        transition.SetTrigger("dream");
        yield return new WaitForSeconds(2.5f);
        changeScene.NextLevel("Final");
    }
}
