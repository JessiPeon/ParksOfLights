using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private StatusGame statusGame;
    void Start()
    {
        statusGame = GameObject.Find("StatusGame").GetComponent<StatusGame>();
        statusGame.lives = 5;
        SceneManager.LoadScene("Intro");
    }

}
