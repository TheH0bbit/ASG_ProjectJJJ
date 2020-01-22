using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject[] StreckenStücke;
    public float noObstacle;
    public float dodgeObstacle;
    public float sectorObstacle;
    public float hurdleObstacle;
    public float GestureObstacle;
    public Transform Strecke;

    public float speed;
    public float speedfactor;
    public AnimationCurve speedfac;
    public float rotspeed;
    public float heightspeed;

    public int vorlauf;
    public int leerVorlauf;

    public GameObject Sphere;

    public Transform nextSpawnpoint;

    public GameObject Coin;
    public float coinHeightDown;
    public float coinHeightMiddle;
    public float coinHeightUp;
    public int minCoins;
    public int maxCoins;

    public float size;

    public int schwierigkeitsgrad=0;
    public float timebetweenDifficulty;
    private float time = 0;

    public MassManager mass;
    
    // Use this for initialization
    void Start () {
        nextSpawnpoint.position = this.transform.position;


       for (int i = 0; i < leerVorlauf-3; i++){

            nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12 * size);
            GameObject g = Instantiate(StreckenStücke[1], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
        }


        float k=hurdleObstacle+sectorObstacle+dodgeObstacle+GestureObstacle;
       

        if(k >100||k< 100)
        {
            Debug.Log("Wahrscheinlichkeiten falsch");
        }

       
        for (int i = 0; i < vorlauf; i++)
        {
            SpawnNext();

           
        }
    }
	
	// Update is called once per frame
	void Update () {

        Strecke.Translate(Vector3.back * Time.deltaTime * speed);

        if (schwierigkeitsgrad < 3)
        {
            time += Time.deltaTime;
            if (time > timebetweenDifficulty)
            {
                schwierigkeitsgrad++;

                time = 0;
            }
        }


        /*float angle = Vector3.SignedAngle(.transform.up, Vector3.up, Vector3.forward);
        angle = Mathf.Clamp(angle, -30f, 30f);
        if(angle<2f&& angle > -2f)
        {
            angle = 0;
        }*/

        float factor = 30;
        Rotate(mass.getCoMVector().x * factor);

        speed = speedfac.Evaluate(Time.time);
    }

    public void SpawnNext()
    {

        int m = Random.Range(0, 100);
        int x = -1;

      
        if (m <=  dodgeObstacle)
        {
            x = 0;
        }
        else if (m <= dodgeObstacle + hurdleObstacle)
        {
            x = 2;
        }
        else if(m <= dodgeObstacle + hurdleObstacle+sectorObstacle)
        {
            x = 3;
        }
        else
        {
            x = 4;
        }

       

        switch (schwierigkeitsgrad)
        {
            case 0:

                for(int i=0; i <3; i++)
                {
                    nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12 * size);
                     Instantiate(StreckenStücke[1], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
                    SpawnCoins(Random.Range(minCoins, maxCoins));
                }

                break;

            case 1:
                for (int i = 0; i < 2; i++)
                {
                    nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12 * size);
                   Instantiate(StreckenStücke[1], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
                    SpawnCoins(Random.Range(minCoins, maxCoins));
                }
                break;

            case 2:
                for (int i = 0; i < 1; i++)
                {
                    nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12 * size);
                   Instantiate(StreckenStücke[1], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
                    SpawnCoins(Random.Range(minCoins, maxCoins));
                }
                break;
           





        }

        Debug.Log("Generate"+x);
        if (x == 0)
        {
            nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12* size);
        }
        else
        {
            nextSpawnpoint.position = nextSpawnpoint.position + new Vector3(0, 0, 12* size);
        }
        GameObject g= Instantiate(StreckenStücke[x], nextSpawnpoint.position, nextSpawnpoint.rotation, Strecke);
      //  g.transform.RotateAround(Vector3.forward, Random.RandomRange(0, 58) * 6.206896f);

        int y = Random.Range(0, 4);
        Debug.Log(x);
        switch (y)
        {
            case 0:
                g.transform.Rotate(Vector3.forward, 6f);
                break;

            case 1:
                g.transform.Rotate(Vector3.forward, 12f);
                break;

            case 2:
                g.transform.Rotate(Vector3.forward, 18f);
                break;
            case 3:
                g.transform.Rotate(Vector3.forward, 24f);
                break;

        }
        
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

            int x = Random.Range(0, 3);
            Debug.Log(x);
            switch (x)
            {
                case 0:
                    c.transform.GetChild(0).transform.localPosition += new Vector3(0,coinHeightDown,0);
                    break;

                case 1:
                    c.transform.GetChild(0).transform.localPosition += new Vector3(0, coinHeightMiddle, 0);
                    break;

                case 2:
                    c.transform.GetChild(0).transform.localPosition += new Vector3(0, coinHeightUp, 0);
                    break;
            }

           
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
