using UnityEngine;
using Windows.Kinect;

/// <summary>
/// The first part of the swipe left gesture
/// </summary>
public class SwipeDownLeftSegment1 : IRelativeGestureSegment
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
        Vector3 shoulderLeft = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 handLeft = skeleton.getRawWorldPosition(JointType.HandLeft);

        if (handLeft.x < head.x)
        {
            if (handLeft.y > head.y)
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
public class SwipeDownLeftSegment2 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        Vector3 shoulderLeft = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 handLeft = skeleton.getRawWorldPosition(JointType.HandLeft);

        if (handLeft.x < head.x)
        {
            if (handLeft.y < head.y)
            {
                if (handLeft.y > shoulderLeft.y)
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
public class SwipeDownLeftSegment3 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        Vector3 shoulderLeft = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 handLeft = skeleton.getRawWorldPosition(JointType.HandLeft);

        if (handLeft.x < head.x)
        {
           // if (handLeft.y < head.y)
            {
                if (handLeft.y < shoulderLeft.y)
                {
                    return GesturePartResult.Succeed;
                }
                return GesturePartResult.Pausing;
            }
        }
        return GesturePartResult.Fail;
    }
}

