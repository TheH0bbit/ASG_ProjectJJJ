using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureObstacle : MonoBehaviour
{
    public float speed;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LowerObstacles();
        }
    }


    public void LowerObstacles()
    {

        if (Mathf.Abs( this.transform.parent.position.z) < range)
        {
            StartCoroutine("Lower");
        }
    }


    IEnumerator Lower()
    {
        float x = 0;
        while(x < 200)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).Translate(Vector3.back * Time.deltaTime*speed, Space.Self);
                x += (Vector3.down * Time.deltaTime * speed).magnitude;
            }
            yield return new WaitForEndOfFrame();

        }

    }
}
