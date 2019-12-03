using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streckenstück : MonoBehaviour {

   
    public Transform mySpawnpoint;
    public Generator gen;
    public float speed;

    public GameObject[] obstacles;

    public Transform[] oSpawnpoints;

	// Use this for initialization
	void Start () {
        gen = GameObject.FindObjectOfType<Generator>();
      // gen.nextSpawnpoint = mySpawnpoint;


        foreach(Transform t in oSpawnpoints)
        {
            int x = Random.Range(0, obstacles.Length );
            GameObject g = Instantiate(obstacles[x], t.position, t.rotation, this.transform.parent.transform);
        }


	}
	
	// Update is called once per frame
	void Update () {
       // this.transform.parent.Translate(Vector3.back * Time.deltaTime * speed);
    }

    public void DestroyThis()
    {
        gen.SpawnNext();
        Destroy(this.transform.parent.gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Deathplane") {

            Debug.Log("Trigger");
            DestroyThis();
                }
    }

}
