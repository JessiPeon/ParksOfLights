using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEffect : MonoBehaviour
{
    public bool moveEffect;
    public float speed;

    void Update()
    {
        if (moveEffect)
        {
            GameObject activePlayer = null;
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (player.GetComponent<Player>().activePlayer)
                {
                    activePlayer = player;
                }
            }
            if (activePlayer.name == "Jinjin")
            {
                gameObject.GetComponent<TrailRenderer>().startColor = Color.green;
            } else
            {
                gameObject.GetComponent<TrailRenderer>().startColor = Color.blue;
            }
            positionChange(activePlayer.transform.position);
            if (transform.position == activePlayer.transform.position)
            {
                moveEffect = false;
                foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                {
                    player.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = player.GetComponent<Player>().activePlayer;
                }
            }
        }
    }
    public void positionChange(Vector2 target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

    }
}
