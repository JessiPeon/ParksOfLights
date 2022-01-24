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

    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
