using UnityEngine;
using Windows.Kinect;

public class PauseSegment1 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //arms in starting position
        Vector3 handLeft = skeleton.getRawWorldPosition(JointType.HandLeft);
        Vector3 handRight = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);

        // hands left and right of head
        if (handLeft.x < head.x && handRight.x > head.x)
        {
            //arms below head
            if (handLeft.y < head.y && handRight.y < head.y)
            {
                return GesturePartResult.Succeed;
            }

            return GesturePartResult.Pausing;
        }

        return GesturePartResult.Fail;
    }
}

public class PauseSegment2 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //arms in starting position
        Vector3 handLeft = skeleton.getRawWorldPosition(JointType.HandLeft);
        Vector3 handRight = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);

        // hands left and right of head
        if (handLeft.x < handRight.x)
        {
            // hands above head
            if (handLeft.y > head.y && handRight.y > head.y)
            {
                return GesturePartResult.Succeed;
            }

            return GesturePartResult.Pausing;
        }

        return GesturePartResult.Fail;
    }
}

public class PauseSegment3 : IRelativeGestureSegment
{
    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //hands in end position
        Vector3 handLeft = skeleton.getRawWorldPosition(JointType.HandLeft);
        Vector3 handRight = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        //hands above head
        if (handLeft.y > head.y && handRight.y > head.y)
        {
            //hands together
            if ((handLeft - handRight).magnitude < 0.20f)
            {
                return GesturePartResult.Succeed;
            }

            return GesturePartResult.Pausing;
        }

        return GesturePartResult.Fail;
    }
}
