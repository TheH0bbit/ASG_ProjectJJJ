using UnityEngine;
using Windows.Kinect;

/// <summary>
/// The first part of the swipe left gesture
/// </summary>
public class SwipeDownRightSegment1 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        // right hand in front of right shoulder
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        Vector3 shoulderRight = skeleton.getRawWorldPosition(JointType.ShoulderRight);
        Vector3 handRight = skeleton.getRawWorldPosition(JointType.HandRight);

        if (handRight.x > head.x)
        {
            if (handRight.y > head.y)
            {
                return GesturePartResult.Succeed;
            }
            return GesturePartResult.Pausing;
        }
        return GesturePartResult.Fail;
    }
}

/// <summary>
/// The second part of the swipe left gesture
/// </summary>
public class SwipeDownRightSegment2 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        Vector3 shoulderRight = skeleton.getRawWorldPosition(JointType.ShoulderRight);
        Vector3 handRight = skeleton.getRawWorldPosition(JointType.HandRight);

        if (handRight.x > head.x)
        {
            if (handRight.y < head.y)
            {
                if (handRight.y > shoulderRight.y)
                {

                    return GesturePartResult.Succeed;
                }
                return GesturePartResult.Pausing;
            }
        }
        return GesturePartResult.Fail;
    }
}

/// <summary>
/// The third part of the swipe left gesture
/// </summary>
public class SwipeDownRightSegment3 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        Vector3 shoulderRight = skeleton.getRawWorldPosition(JointType.ShoulderRight);
        Vector3 handRight = skeleton.getRawWorldPosition(JointType.HandRight);

        if (handRight.x > head.x)
        {
            // if (handLeft.y < head.y)
            {
                if (handRight.y < shoulderRight.y)
                {
                    return GesturePartResult.Succeed;
                }
                return GesturePartResult.Pausing;
            }
        }
        return GesturePartResult.Fail;
    }
}
