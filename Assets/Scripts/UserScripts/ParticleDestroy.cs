using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleDestroy : MonoBehaviour
{
    private ParticleSystem particle;
    public bool player;
    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
      
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!particle.IsAlive())
        {
            if (!player)
            {
                Destroy(gameObject);
            }
            else
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
