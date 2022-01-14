using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public bool illuminated = true;
    public bool activePlayer = true;
    public int lives = 5;
    public float timeToRevive = 1f;
    public float timeToCheckDeath = 0.1f;
    public GameObject lastLightVisited;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

        if (illuminated && activePlayer)
        {
            float movDirX = Input.GetAxis("Horizontal");
            float movDirY = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(movDirX * speed, movDirY * speed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }



    }

    public void Die()
    {
        StartCoroutine("IlluminatedZone");
    }

    IEnumerator IlluminatedZone()
    {
        illuminated = false;
        yield return new WaitForSeconds(timeToCheckDeath);
        if (!illuminated)
        {
            if (lives > 0)
            {
                //StopAllCoroutines();
                StartCoroutine("RestOneLife");
            }
            else
            {
                //game over
            }
        }
    }

    IEnumerator RestOneLife()
    {
        lives--;
        yield return new WaitForSeconds(timeToRevive);
        transform.position = lastLightVisited.transform.GetChild(0).transform.position;
        //illuminated = true;
    }
}
