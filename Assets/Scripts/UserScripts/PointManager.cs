using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static int lives = 3;
    public static int points=0;
    private static bool invincible = false;
    private static PauseManager manager;
    private GameObject player;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
      
        manager = GameObject.FindObjectOfType<PauseManager>();
        player = GameObject.Find("ybot@T-Pose");
        audioSource = this.GetComponent<AudioSource>();
        StartCoroutine("Points",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AwardPoints(int point)
    {
        points += point;
    }

    IEnumerator   Points()
    {
        while (true)
        {
            points +=  1;
            yield return new WaitForSeconds(1);

        }

    }

    public void Invincible()
    {
        if(!invincible && lives > 0)
        {
            invincible = true;
            audioSource.Play();
            StartCoroutine(Blink());
        }
        
    }
        
    public static void ReduceLives()
    {
        if (!invincible)
        {
            lives--;
            
        }
        if (lives <= 0)
        {
            manager.EndGame();
        }
        
    }

    IEnumerator Blink()
    {
        int x = 6;
        while(x >0){
            x--;

            player.SetActive(!player.active);
            yield return new WaitForSecondsRealtime(0.5f);
        }
        invincible = false;

    }

    public static void Reset()
    {
        points = 0;
        lives = 3;
    }
}
