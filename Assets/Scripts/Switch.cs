using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
//using UnityEngine.Experimental.Rendering.LWRP;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < gameObject.transform.childCount ; i++)
            {
                transform.GetChild(i).GetComponent<Light2D>().enabled = !transform.GetChild(i).GetComponent<Light2D>().enabled;
                transform.GetChild(i).GetComponent<CircleCollider2D>().enabled = !transform.GetChild(i).GetComponent<CircleCollider2D>().enabled;
            }
        }
    }
}
