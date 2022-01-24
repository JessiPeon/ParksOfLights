using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZoneAnimation : MonoBehaviour
{

    private ChangeScene changeScene;

    public string nextScene;
    void Start()
    {
        changeScene = GameObject.Find("StatusGame").GetComponent<ChangeScene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            changeScene.NextScene(nextScene);
        }
        
    }
}
