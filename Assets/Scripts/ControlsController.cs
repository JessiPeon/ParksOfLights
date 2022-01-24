using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsController : MonoBehaviour
{
    private StatusGame statusGame;
    private ChangeScene changeScene;
    void Start()
    {
        statusGame = GameObject.Find("StatusGame").GetComponent<StatusGame>();
        changeScene = GameObject.Find("StatusGame").GetComponent<ChangeScene>();
    }

    public void chooseControl(string control)
    {
        if (control == "Keyboard")
        {
            statusGame.playOnPhone = false;
        } else
        {
            statusGame.playOnPhone = true;
        }
        changeScene.NextScene("SecondScene");
    }
}
