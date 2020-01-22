using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseManager : MonoBehaviour
{

    public bool paused;
    public bool menu;
    public GameObject panel;
    public Text pauseText;
    public GameObject effect;
   // private Generator gen;
    // Start is called before the first frame update
    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
        Time.timeScale = 0;
        paused = true;
        StartCoroutine(Countdown());

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DoGesture();
        }
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
           // Time.timeScale = 1;

            StartCoroutine("Countdown");
        }
        else
        {
            //Pause
            panel.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
    }

    IEnumerator Countdown()
    {
        int x = 3;
        while (x > 0)
        {
            if (pauseText != null)
            {
                pauseText.text = "" + x;
            }
            Debug.Log("davor");
            yield return new WaitForSecondsRealtime(1f);
            x -= 1;
            Debug.Log("danach");
        }
        paused = false;
        if (pauseText != null)
        {
            pauseText.text = "Pause";
        }
        if (panel != null)
        {
            panel.SetActive(false);
        }
        Time.timeScale = 1;

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


    public void EndGame()
    {
        Instantiate(effect, this.transform.position, Quaternion.identity);

    }


}
