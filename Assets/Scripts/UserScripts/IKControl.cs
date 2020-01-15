using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{

    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform rightFootObj = null;
    public Transform leftFootObj = null;

    public Transform rightKneeObj = null;
    public Transform leftKneeObj = null;
    public Transform rightElbowObj = null;
    public Transform leftElbowObj = null;

    public Transform lookObj = null;

    public GameObject leftFootSnap;
    public GameObject rightFootSnap;
    public GameObject leftFootSnapCollider;
    public GameObject rightFootSnapCollider;

    public bool LerpSnap;



    void Start()
    {
        animator = GetComponent<Animator>();
    }


    //a callback for calculating IK
    void OnAnimatorIK()
    {

        //TODO check if already snapped
        //TODO polishing: slerp snap
        if (leftFootSnapCollider.GetComponent<Collider>().bounds.Contains(leftFootObj.position))
        {
            if(LerpSnap)
                leftFootObj.position = Vector3.Lerp(leftFootObj.position, leftFootSnap.transform.position, 0.5f);
            else
                leftFootObj.position = leftFootSnap.transform.position;

            leftFootObj.eulerAngles = leftFootSnap.transform.parent.eulerAngles;
        }
        else if (leftFootSnapCollider.GetComponent<Collider>().bounds.Contains(rightFootObj.position))
        {
            if (LerpSnap)
                rightFootObj.position = Vector3.Lerp(rightFootObj.position, leftFootSnap.transform.position, 0.5f);
            else
                rightFootObj.position = leftFootSnap.transform.position;

            rightFootObj.eulerAngles = leftFootSnap.transform.eulerAngles;
        }

        if (rightFootSnapCollider.GetComponent<Collider>().bounds.Contains(rightFootObj.position))
        {
            if (LerpSnap)
                rightFootObj.position = Vector3.Lerp(rightFootObj.position, rightFootSnap.transform.position, 0.5f);
            else
                rightFootObj.position = rightFootSnap.transform.position;

            rightFootObj.eulerAngles = rightFootSnap.transform.eulerAngles;
        }
        else if (rightFootSnapCollider.GetComponent<Collider>().bounds.Contains(leftFootObj.position))
        {
            if (LerpSnap)
                leftFootObj.position = Vector3.Lerp(leftFootObj.position, rightFootSnap.transform.position, 0.5f);
            else
                leftFootObj.position = rightFootSnap.transform.position;
            leftFootObj.eulerAngles = rightFootSnap.transform.parent.eulerAngles;
        }


        if (animator)
        {

            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {

                // Set the look __target position__, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(1);
                    animator.SetLookAtPosition(lookObj.position);
                }

                // Set the right hand target position and rotation, if one has been assigned
                if (rightFootObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootObj.rotation);
                }
                if (leftHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                }
                if (rightHandObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                }
                if (leftFootObj != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot,1);
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootObj.rotation);
                }

                if (rightElbowObj != null)
                {
                    animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);
                    animator.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbowObj.position);
                }
                if (leftElbowObj != null)
                {
                    animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
                    animator.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbowObj.position);
                }
                if (rightKneeObj != null)
                {
                    animator.SetIKHintPositionWeight(AvatarIKHint.RightKnee, 1);
                    animator.SetIKHintPosition(AvatarIKHint.RightKnee, rightKneeObj.position);
                }
                if (leftKneeObj != null)
                {
                    animator.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, 1);
                    animator.SetIKHintPosition(AvatarIKHint.LeftKnee, leftKneeObj.position);
                }

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetLookAtWeight(0);
            }
        }
    }
}
