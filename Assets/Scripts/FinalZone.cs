using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZone : MonoBehaviour
{
    private GameController gameController;

    private ChangeScene changeScene;

    public string nextLevel;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        changeScene = GameObject.Find("StatusGame").GetComponent<ChangeScene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.arrivedAtEnd++;
        }
        if (gameController.arrivedAtEnd == 2)
        {
            changeScene.NextLevel(nextLevel);
        }
    }
}
