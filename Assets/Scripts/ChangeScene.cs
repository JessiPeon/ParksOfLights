using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void NextLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GameOver()
    {
        FindObjectOfType<AudioController>().Mute("Night");
        FindObjectOfType<AudioController>().Play("Breath");
        SceneManager.LoadScene("GameOver");
    }

    public void NextScene(string name)
    {
        if (name == "Controls")
        {
            StartCoroutine("LoadSceneInTime");
        } else
        {
            if (name == "SecondScene")
            {
                FindObjectOfType<AudioController>().Play("Night");
            }
            SceneManager.LoadScene(name);
        }
        
    }

    IEnumerator LoadSceneInTime()
    {
        FindObjectOfType<AudioController>().Play("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Controls");
    }
}
