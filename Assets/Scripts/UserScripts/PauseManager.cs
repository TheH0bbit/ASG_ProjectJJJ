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
        PointManager.points = 0;

    }


    public void Pause()
    {
        if (paused)
        {
            //unPause
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            //Pause
            Time.timeScale = 0;
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


    public static void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }


}
