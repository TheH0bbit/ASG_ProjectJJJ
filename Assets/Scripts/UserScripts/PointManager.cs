using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{

    public static int points=0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Points",1f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
