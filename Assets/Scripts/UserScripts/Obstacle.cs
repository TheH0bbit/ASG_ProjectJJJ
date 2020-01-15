using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PauseManager manager;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<PauseManager>();
        player = GameObject.Find("ybot@T-Pose");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //player.SetActive(false);
            //manager.EndGame();
            
        }
    }
}
