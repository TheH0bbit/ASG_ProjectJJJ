using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streckenstück : MonoBehaviour {

   
    
    public Generator gen;
    public bool noObstacle;
 

	// Use this for initialization
	void Start () {

        gen = GameObject.FindObjectOfType<Generator>();

	}
	
	// Update is called once per frame
	void Update () {
       // this.transform.parent.Translate(Vector3.back * Time.deltaTime * speed);
       if(this.transform.position.z < -10)
        {
            
            DestroyThis();
        }
    }

    public void DestroyThis()
    {
        if (!noObstacle)
        {
            gen.SpawnNext();
        }
        Destroy(this.gameObject);
    }


    

}
