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

    public GameObject Coin;
    public float coinHeightAbweichung;
    public int minCoins;
    public int maxCoins;

    public float size;
    
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
                nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 24* size);
            }
            else
            {
                nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12* size);
            }
            GameObject g=  Instantiate(StreckenStücke[x], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
            SpawnCoins(Random.Range(minCoins, maxCoins));
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
            nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 24* size);
        }
        else
        {
            nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12* size);
        }
        GameObject g = Instantiate(StreckenStücke[x], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
        SpawnCoins(Random.Range(minCoins,maxCoins));


    }


    public void SpawnCoins(int anzahl)
    {
        /* for (int i = 0; i < anzahl; i++)
         {
             float r1 = 1f;
             float r2 = innerRadius/outerRadius;

             float t = 2 * Mathf.PI * Random.Range(0, 1);
             float u = Random.Range(0, 1f) + Random.Range(0, 1f);
             float r;
             if (u > 1)
             {
                 r = 2 - u;
             }
             else
             {
                 r = u;
             }

             if (r < r2)
             {
                 r = r2 + r * ((outerRadius - innerRadius) / innerRadius);
             }
             Debug.Log(r+","+u+","+t);


             Instantiate(Coin, new Vector3(r * Mathf.Cos(t), r * Mathf.Sin(t), nextSpawnpoint.position.z), nextSpawnpoint.rotation, Strecke);

         }
         */
        for (int i = 0; i < anzahl; i++)
        {
            GameObject c = Instantiate(Coin, nextSpawnpoint.position, Quaternion.identity, Strecke);

            c.transform.RotateAround(Vector3.forward, Random.RandomRange(0, 36*2)*5);
            c.transform.GetChild(0).transform.localPosition += new Vector3(0, Random.Range(-coinHeightAbweichung, coinHeightAbweichung));
        }
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
