using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour
{
    private StatusGame statusGame;
    void Start()
    {
        FindObjectOfType<AudioController>().Mute("Night");
        statusGame = GameObject.Find("StatusGame").GetComponent<StatusGame>();
        statusGame.lives = 5;
        SceneManager.LoadScene("Credits");
    }

}
