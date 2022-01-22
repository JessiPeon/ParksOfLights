using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joybutton : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPlayer()
    {
        gameController.SwitchPlayer();
    }
}
