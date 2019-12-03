using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject[] StreckenStücke;
    public Transform Strecke;

    public float speed;
    public float rotspeed;
    public float heightspeed;

    public int vorlauf;

    public Transform nextSpawnpoint;
    // Use this for initialization
    void Start () {
        nextSpawnpoint = this.transform;
        int x = Random.Range(0, StreckenStücke.Length);
        for (int i = 0; i < vorlauf; i++)
        {
          GameObject g=  Instantiate(StreckenStücke[x], nextSpawnpoint.position, Quaternion.identity, Strecke);
            nextSpawnpoint = g.transform.GetChild(0).GetComponent<Streckenstück>().mySpawnpoint;
        }
    }
	
	// Update is called once per frame
	void Update () {

        Strecke.Translate(Vector3.back * Time.deltaTime * speed);


        if (Input.GetKey(KeyCode.D))
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

    }

    public void SpawnNext()
    {
        int x = Random.Range(0, StreckenStücke.Length);
        GameObject g = Instantiate(StreckenStücke[x], nextSpawnpoint.position, Quaternion.identity, Strecke);
        nextSpawnpoint = g.transform.GetChild(0).GetComponent<Streckenstück>().mySpawnpoint;



    }


    public void Rotate(float speed, int dir)
    {

        if (dir > 0)
        {
            Strecke.transform.Rotate(Vector3.back * Time.deltaTime * speed);
        }
        else
        {
            Strecke.transform.Rotate(Vector3.forward*Time.deltaTime*speed);
        }


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
