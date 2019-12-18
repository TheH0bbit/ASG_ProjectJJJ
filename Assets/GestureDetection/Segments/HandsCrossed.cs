using UnityEngine;
using Windows.Kinect;

public class HandsCrossedSegment1 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //arms in starting position
        Vector3 elbowLeft = skeleton.getRawWorldPosition(JointType.ElbowLeft);
        Vector3 elbowRight = skeleton.getRawWorldPosition(JointType.ElbowRight);
        Vector3 wristLeft = skeleton.getRawWorldPosition(JointType.WristLeft);
        Vector3 wristRight = skeleton.getRawWorldPosition(JointType.WristRight);

        //left arm in starting position
        if (elbowLeft.y < wristLeft.y && elbowLeft.x < wristLeft.x)
        {
            // right arm in starting position
            if (elbowRight.y < wristRight.y && elbowRight.x > wristRight.x)
            {
                //left arm left of right arm
                if (wristLeft.x < wristRight.x)
                {
                    return GesturePartResult.Succeed;
                }
                return GesturePartResult.Pausing;
            }

            return GesturePartResult.Pausing;
        }

        return GesturePartResult.Fail;
    }
}

public class HandsCrossedSegment2 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //arms in end position
        Vector3 elbowLeft = skeleton.getRawWorldPosition(JointType.ElbowLeft);
        Vector3 elbowRight = skeleton.getRawWorldPosition(JointType.ElbowRight);
        Vector3 wristLeft = skeleton.getRawWorldPosition(JointType.WristLeft);
        Vector3 wristRight = skeleton.getRawWorldPosition(JointType.WristRight);

        //left arm in end position
        if (elbowLeft.y < wristLeft.y && elbowLeft.x < wristLeft.x)
        {
            // right arm in end position
            if (elbowRight.y < wristRight.y && elbowRight.x > wristRight.x)
            {
                //arms crossed
                if (wristLeft.x > wristRight.x && elbowLeft.x < elbowRight.x)
                {
                    return GesturePartResult.Succeed;
                }
                return GesturePartResult.Pausing;
            }

            return GesturePartResult.Pausing;
        }

        return GesturePartResult.Fail;
    }
}
