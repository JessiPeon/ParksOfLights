using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusGame : MonoBehaviour
{

    public static StatusGame instance;
    public bool playOnPhone;
    public int lives = 5;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Lives"))
        {
            TextMeshProUGUI t = GameObject.Find("Lives").GetComponent<TextMeshProUGUI>();
            t.text = lives.ToString();
        }
            
    }
}
