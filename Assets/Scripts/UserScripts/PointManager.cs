using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static int lives = 300;
    public static int points=0;
    private static bool invincible = false;
    private static PauseManager manager;
    private GameObject player;
    private AudioSource audioSource;
    public int leben;
    public bool unbesiegbar;
    private bool isBlinking=false;
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
        leben = lives;
        unbesiegbar = invincible;
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
            if (!isBlinking)
            {
                StartCoroutine(Blink());
            }
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
        isBlinking = true;
        int x = 6;
        while(x >0){
            x = x - 1; ;

            if (player.activeSelf)
            {
                player.SetActive(false);
            }
            else
            {
                player.SetActive(true);
            }


           
            yield return new WaitForSecondsRealtime(0.3f);
        }
        invincible = false;
        isBlinking = false;
    }

    public static void Reset()
    {
        points = 0;
        lives = 3;
    }
}
