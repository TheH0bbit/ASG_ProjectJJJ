using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class RobotCharacterController : BasicAvatarController
{
    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform rightFootObj = null;
    public Transform leftFootObj = null;
    public Transform rightKneeObj = null;
    public Transform leftKneeObj = null;
    public Transform rightElbowObj = null;
    public Transform leftElbowObj = null;
    public Transform hip = null;
    public float footOffset = 0.2f;
    public float hipOffset;
    //public Transform debugCube;

    public override void Start()
    {
        // find transforms of model
        SpineBase = GameObject.Find("mixamorig:Hips").transform;
        //SpineMid = GameObject.Find("Character1_Spine2").transform;
        Neck = GameObject.Find("mixamorig:Neck").transform;
        Head = GameObject.Find("mixamorig:Head").transform;
            //ShoulderLeft = GameObject.Find("mixamorig:LeftArm").transform;
            //ElbowLeft = GameObject.Find("mixamorig:LeftForeArm").transform;
            //WristLeft = GameObject.Find("mixamorig:LeftHand").transform;
        //HandLeft = GameObject.Find("").transform;
            //ShoulderRight = GameObject.Find("mixamorig:RightArm").transform;
            //ElbowRight = GameObject.Find("mixamorig:RightForeArm").transform;
            //WristRight = GameObject.Find("mixamorig:RightHand").transform;
        //HandRight = GameObject.Find("").transform;
            /*HipLeft = GameObject.Find("mixamorig:LeftUpLeg").transform;
            KneeLeft = GameObject.Find("mixamorig:LeftLeg").transform;
            AnkleLeft = GameObject.Find("mixamorig:LeftFoot").transform;
            FootLeft = GameObject.Find("mixamorig:LeftToeBase").transform;
            HipRight = GameObject.Find("mixamorig:RightUpLeg").transform;
            KneeRight = GameObject.Find("mixamorig:RightLeg").transform;
            AnkleRight = GameObject.Find("mixamorig:RightFoot").transform;
            FootRight = GameObject.Find("mixamorig:RightToeBase").transform;*/
        SpineShoulder = GameObject.Find("mixamorig:Spine2").transform;
        //HandTipLeft = GameObject.Find("Character1_LeftHandIndex1").transform;
        //ThumbLeft = GameObject.Find("Character1_LeftHandThumb1").transform;
        //HandTipRight = GameObject.Find("Character1_RightHandIndex1").transform;
        //ThumbRight = GameObject.Find("Character1_RightHandThumb1").transform;

        base.Start();
    }




    public virtual void Update()
    {
        Vector3 posHipLeft;
        Vector3 posHipRight;
        Vector3 hipRightVector;
        float LerpP = 0.5f;

        Vector3 hipPosition = MoCapAvatar.getRawWorldPosition(JointType.SpineBase);
        
        hip.position = new Vector3(0,hipPosition.y+hipOffset,0);
        //Vector3 handRightDelta = MoCapAvatar.getRawWorldPosition(JointType.HandRight) - rightHandObj.position;
        //TODO nice to have: smooth inputs
        hipPosition.y = -hipOffset;

        //rightHandObj.position = MoCapAvatar.getRawWorldPosition(JointType.HandRight)-hipPosition;
        rightHandObj.position = Vector3.Lerp(rightHandObj.position, MoCapAvatar.getRawWorldPosition(JointType.HandRight) - hipPosition, LerpP);
        //leftHandObj.position = MoCapAvatar.getRawWorldPosition(JointType.HandLeft) - hipPosition;
        leftHandObj.position = Vector3.Lerp(leftHandObj.position, MoCapAvatar.getRawWorldPosition(JointType.HandLeft) - hipPosition, LerpP);
        //rightFootObj.position = MoCapAvatar.getRawWorldPosition(JointType.FootRight) + new Vector3(0,-footOffset,0) - hipPosition;
        rightFootObj.position = Vector3.Lerp(rightFootObj.position, MoCapAvatar.getRawWorldPosition(JointType.FootRight) + new Vector3(0, -footOffset, 0) - hipPosition, LerpP);
        //leftFootObj.position = MoCapAvatar.getRawWorldPosition(JointType.FootLeft) + new Vector3(0, -footOffset, 0) - hipPosition;
        leftFootObj.position = Vector3.Lerp(leftFootObj.position, MoCapAvatar.getRawWorldPosition(JointType.FootLeft) + new Vector3(0, -footOffset, 0) - hipPosition, LerpP);

        //rightElbowObj.position = MoCapAvatar.getRawWorldPosition(JointType.ElbowRight) - hipPosition;
        //leftElbowObj.position = MoCapAvatar.getRawWorldPosition(JointType.ElbowLeft) - hipPosition;
        //rightKneeObj.position = MoCapAvatar.getRawWorldPosition(JointType.KneeRight) - hipPosition;
        //leftKneeObj.position = MoCapAvatar.getRawWorldPosition(JointType.KneeLeft) - hipPosition;

        posHipLeft = MoCapAvatar.getRawWorldPosition(JointType.HipLeft);
        posHipRight = MoCapAvatar.getRawWorldPosition(JointType.HipRight);
        hipRightVector =  posHipRight - posHipLeft;

        Vector3 posHipCenter = MoCapAvatar.getRawWorldPosition(JointType.SpineBase);
        Vector3 posShoulderCenter = MoCapAvatar.getRawWorldPosition(JointType.SpineShoulder);
        Vector3 hipUpVector = posShoulderCenter - posHipCenter;

        Quaternion rot = Quaternion.identity;
        rot.SetLookRotation(-Vector3.Cross(hipUpVector,hipRightVector),hipUpVector);
        hip.rotation = rot;
        //base.Update();
    }

    public void OnDrawGizmos()
    {
       // Gizmos.DrawSphere(posHipLeft,0.02f);
       // Gizmos.DrawSphere(posHipRight, 0.02f);
        
       // Gizmos.DrawLine(posHipLeft + Vector3.right, posHipRight + Vector3.right);
        Gizmos.DrawLine(MoCapAvatar.getRawWorldPosition(JointType.FootRight), MoCapAvatar.getRawWorldPosition(JointType.FootLeft));
    }


    public Vector3 GetFootMiddlepoint()
    {
      Vector3 vec=  MoCapAvatar.getRawWorldPosition(JointType.FootRight) + MoCapAvatar.getRawWorldPosition(JointType.FootLeft)/2;
       
        return vec;
    }

}
