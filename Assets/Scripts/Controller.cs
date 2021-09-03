using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        Debug.Log("Scene loaded");

    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit Executed");
    }
}
