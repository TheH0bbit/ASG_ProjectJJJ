using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject[] StreckenStücke;
    public float noObstacle;
    public float dodgeObstacle;
    public float sectorObstacle;
    public float hurdleObstacle;
    public Transform Strecke;

    public float speed;
    public float rotspeed;
    public float heightspeed;

    public int vorlauf;

    public GameObject hoverboard;

    public Transform nextSpawnpoint;
    // Use this for initialization
    void Start () {
        nextSpawnpoint.position = this.transform.position;

        float k=noObstacle+hurdleObstacle+sectorObstacle+dodgeObstacle;
       

        if(k >100||k< 100)
        {
            Debug.Log("Wahrscheinlichkeiten falsch");
        }

       
        for (int i = 0; i < vorlauf; i++)
        {
            int m = Random.Range(0, 100);
            int x = -1;

            if (m <= noObstacle)
            {
                x = 1;
            }else if( m <= noObstacle + dodgeObstacle)
            {
                x = 0;
            }else if(m <= noObstacle + dodgeObstacle + hurdleObstacle)
            {
                x = 2;
            }
            else
            {
                x = 3;
            }
            



            Debug.Log("Generate"+x);
            if (x == 0)
            {
                nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 24);
            }
            else
            {
                nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12);
            }
            GameObject g=  Instantiate(StreckenStücke[x], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
        
        }
    }
	
	// Update is called once per frame
	void Update () {

        Strecke.Translate(Vector3.back * Time.deltaTime * speed);


        /* if (Input.GetKey(KeyCode.D))
         {
             Rotate(rotspeed,1);
         }

         if (Input.GetKey(KeyCode.A))
         {
             Rotate(rotspeed, -1);
         }

         if (Input.GetKey(KeyCode.W))
         {
             ChangeHeight(heightspeed, -1);
         }

         if (Input.GetKey(KeyCode.S))
         {
             ChangeHeight(heightspeed, 1);
         }

     */

       

        float angle = Vector3.SignedAngle(hoverboard.transform.up, Vector3.up, Vector3.forward);
        angle = Mathf.Clamp(angle, -30f, 30f);
        if(angle<2f&& angle > -2f)
        {
            angle = 0;
        }

        Rotate(angle);

    }

    public void SpawnNext()
    {

        int m = Random.Range(0, 100);
        int x = -1;

        if (m <= noObstacle)
        {
            x = 1;
        }
        else if (m <= noObstacle + dodgeObstacle)
        {
            x = 0;
        }
        else if (m <= noObstacle + dodgeObstacle + hurdleObstacle)
        {
            x = 2;
        }
        else
        {
            x = 3;
        }




        Debug.Log("Generate"+x);
        if (x == 0)
        {
            nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 24);
        }
        else
        {
            nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12);
        }
        GameObject g = Instantiate(StreckenStücke[x], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);



    }


    public void Rotate(float speed)
    {
      
            Strecke.transform.Rotate(Vector3.back * Time.deltaTime * (speed *-4));
      
   

    }

   public void ChangeHeight(float speed, int dir)
    {

        if (dir > 0)
        {
            Strecke.transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        }
        else
        {
            Strecke.transform.Translate(Vector3.down * Time.deltaTime * speed,Space.World);
        }

    }

}
