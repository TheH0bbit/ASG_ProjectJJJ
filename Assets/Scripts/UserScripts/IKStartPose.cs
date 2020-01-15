using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKStartPose : MonoBehaviour
{
    protected Animator animator;

    public Transform goalPosLeft;
    public Transform goalPosRight;
    public Transform leftElbow;
    public Transform rightElbow;


    public bool anim = true;
    float weight = 0.0f;

    bool weightUp = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!anim)
            return;

        if (weightUp)
        {
            weight += Time.deltaTime;
            if(weight >= 1)
            {
                weight = 1;
                weightUp = false;
            }
        }
        else{
            weight -= Time.deltaTime;
            if (weight <= 0)
            {
                weight = 0;
                weightUp = true;
            }
        }
    }

    void OnAnimatorIK()
    {
        if (animator)
        {
            Vector3 leftPos = goalPosLeft.position;// Vector3.Lerp(leftHand.position, goalPosLeft.position, 0.5f);


            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);

            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, weight);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, weight);

            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftPos);
            animator.SetIKPosition(AvatarIKGoal.RightHand, goalPosRight.position);

 
            animator.SetIKRotation(AvatarIKGoal.LeftHand, goalPosLeft.rotation);
            animator.SetIKRotation(AvatarIKGoal.RightHand, goalPosRight.rotation);

            animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, weight);
            animator.SetIKHintPosition(AvatarIKHint.RightElbow, rightElbow.position);

            animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, weight);
            animator.SetIKHintPosition(AvatarIKHint.LeftElbow, leftElbow.position);
        }
    }
}
