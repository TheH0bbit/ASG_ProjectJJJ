using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class RobotCharacterController : BasicAvatarController
{
    public override void Start()
    {
        // find transforms of model
        SpineBase = GameObject.Find("mixamorig:Hips").transform;
        //SpineMid = GameObject.Find("Character1_Spine2").transform;
        Neck = GameObject.Find("mixamorig:Neck").transform;
        Head = GameObject.Find("mixamorig:Head").transform;
        ShoulderLeft = GameObject.Find("mixamorig:LeftArm").transform;
        ElbowLeft = GameObject.Find("mixamorig:LeftForeArm").transform;
        WristLeft = GameObject.Find("mixamorig:LeftHand").transform;
        //HandLeft = GameObject.Find("").transform;
        ShoulderRight = GameObject.Find("mixamorig:RightArm").transform;
        ElbowRight = GameObject.Find("mixamorig:RightForeArm").transform;
        WristRight = GameObject.Find("mixamorig:RightHand").transform;
        //HandRight = GameObject.Find("").transform;
        HipLeft = GameObject.Find("mixamorig:LeftUpLeg").transform;
        KneeLeft = GameObject.Find("mixamorig:LeftLeg").transform;
        AnkleLeft = GameObject.Find("mixamorig:LeftFoot").transform;
        FootLeft = GameObject.Find("mixamorig:LeftToeBase").transform;
        HipRight = GameObject.Find("mixamorig:RightUpLeg").transform;
        KneeRight = GameObject.Find("mixamorig:RightLeg").transform;
        AnkleRight = GameObject.Find("mixamorig:RightFoot").transform;
        FootRight = GameObject.Find("mixamorig:RightToeBase").transform;
        SpineShoulder = GameObject.Find("mixamorig:Spine2").transform;
        //HandTipLeft = GameObject.Find("Character1_LeftHandIndex1").transform;
        //ThumbLeft = GameObject.Find("Character1_LeftHandThumb1").transform;
        //HandTipRight = GameObject.Find("Character1_RightHandIndex1").transform;
        //ThumbRight = GameObject.Find("Character1_RightHandThumb1").transform;

        base.Start();
    }

    public virtual void Update()
    {
        // apply base Update function, which rotates all known standard joints
        base.Update();
    }




}
