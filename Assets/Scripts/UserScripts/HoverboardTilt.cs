using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverboardTilt : MonoBehaviour
{
    // Start is called before the first frame update
    private RobotCharacterController charCon;

    public GameObject footLeft;
    public GameObject footRight;
    public float offset;

    void Start()
    {
        charCon= GameObject.FindObjectOfType<RobotCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.forward = charCon.GetFootVector();



       
        this.transform.position = new Vector3(this.transform.position.x,getLowestPoint().y-offset , this.transform.position.z);


    }



    public void OnDrawGizmos()
    {
        // Gizmos.DrawSphere(posHipLeft,0.02f);
        // Gizmos.DrawSphere(posHipRight, 0.02f);

        Vector3 vec = -(footLeft.transform.position - footRight.transform.position);
        // Gizmos.DrawLine(posHipLeft + Vector3.right, posHipRight + Vector3.right);
        Gizmos.DrawLine(footLeft.transform.position , footLeft.transform.position +vec);
    }


    public Vector3 getLowestPoint()
    {

        if(footRight.transform.position.y < footLeft.transform.position.y)
        {
            return footRight.transform.position;
        }
        else
        {
            return footLeft.transform.position;
        }

    }

    public Vector3 getMidPoint()
    {
        return ((footRight.transform.position + footLeft.transform.position) / 2);
    }
}
