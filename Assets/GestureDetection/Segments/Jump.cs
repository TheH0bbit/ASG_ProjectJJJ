using UnityEngine;
using Windows.Kinect;

public class JumpSegment1 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        // hand above elbow
        Vector3 ankleLeft = skeleton.getRawWorldPosition(JointType.AnkleLeft);
        Vector3 ankleRight = skeleton.getRawWorldPosition(JointType.AnkleRight);


        if (ankleRight.y < 0)
        {
            // Feet on Ground
            if (ankleLeft.y < 0)
            {
                return GesturePartResult.Succeed;
            }

            return GesturePartResult.Pausing;
        }

        return GesturePartResult.Fail;
    }
}

public class JumpSegment2 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        // hand above elbow
        Vector3 ankleLeft = skeleton.getRawWorldPosition(JointType.AnkleLeft);
        Vector3 ankleRight = skeleton.getRawWorldPosition(JointType.AnkleRight);

        if (ankleRight.y < 0.1f)
        {
            // hand right of elbow
            if (ankleLeft.y < 0.1f)
            {
                return GesturePartResult.Succeed;
            }

            return GesturePartResult.Pausing;
        }

        return GesturePartResult.Fail;
    }
}
