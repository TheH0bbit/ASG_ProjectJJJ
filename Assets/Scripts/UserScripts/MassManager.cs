using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassManager : MonoBehaviour
{
    [SerializeField]
    public JointWeight[] joints;
    public Transform footLeft;
    public Transform footRight;

    private Vector3 footing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sumPosition = Vector3.zero;
        float sumMass = 0.0f;

        //this.transform.position = player.worldCenterOfMass;
        foreach (JointWeight j in joints)
        {
            sumPosition += j.transform.position * j.mass;
            sumMass += j.mass;
        }

        this.transform.position = sumPosition / sumMass;

        footing = (footLeft.position + footRight.position)/2;



    }

    public void OnDrawGizmos()
    {

        Gizmos.DrawLine(footing, this.transform.position);

    }

    [System.Serializable]
    public class JointWeight
    {
        public Transform transform;
        public float mass;

        public JointWeight(Transform transform,float mass)
        {
            this.transform = transform;
            this.mass = mass;
        }
    }
}
