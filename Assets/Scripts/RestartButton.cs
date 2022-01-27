using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private StatusGame statusGame;

    
    public void RestartGame()
    {
        statusGame = GameObject.Find("StatusGame").GetComponent<StatusGame>();
        statusGame.lives = 5;
        SceneManager.LoadScene("Intro");
    }

    public void Skip()
    {
        FindObjectOfType<AudioController>().Mute("Night");
        SceneManager.LoadScene("Credits");
    }
}
