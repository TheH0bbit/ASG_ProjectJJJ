using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public bool paused;
    public bool menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scenenName)
    {
        SceneManager.LoadScene(scenenName);

    }


    public void Pause()
    {
        if (paused)
        {
            //unPause
            paused = false;
        }
        else
        {
            //Pause
            paused = true;
        }
    }


    public void DoGesture()
    {
        if (menu)
        {
            LoadScene("MainScene");
        }
        else
        {
            Pause();
        }

    }


}
