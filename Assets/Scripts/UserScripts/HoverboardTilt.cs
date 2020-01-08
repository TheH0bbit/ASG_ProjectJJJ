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

        //this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x,getLowestPointY()-offset , this.transform.position.z), 0.8f);
        this.transform.position = new Vector3(this.transform.position.x, getLowestPointY() - offset, this.transform.position.z);
    }



    public void OnDrawGizmos()
    {
        // Gizmos.DrawSphere(posHipLeft,0.02f);
        // Gizmos.DrawSphere(posHipRight, 0.02f);

        Vector3 vec = -(footLeft.transform.position - footRight.transform.position);
        // Gizmos.DrawLine(posHipLeft + Vector3.right, posHipRight + Vector3.right);
        Gizmos.DrawLine(footLeft.transform.position , footLeft.transform.position +vec);
    }


    public float getLowestPointY()
    {

        if(footRight.transform.position.y < footLeft.transform.position.y)
        {
            //min height to avoid shaking
            if(footRight.transform.position.y < 0f)
            {
                return -0.11f;
            }
            return footRight.transform.position.y;
        }
        else
        {
            if (footLeft.transform.position.y < 0f)
            {
                return -0.11f;
            }
            return footLeft.transform.position.y;
        }

    }

    public Vector3 getMidPoint()
    {
        return ((footRight.transform.position + footLeft.transform.position) / 2);
    }
}
