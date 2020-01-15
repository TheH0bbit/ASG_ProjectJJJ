using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GestureController gc;
    public PauseManager pauseManager;

	// Use this for initialization
	void Start () {
        gc.GestureRecognizedInController += OnGestureRecognized;
        IRelativeGestureSegment[] pause = {new PauseSegment1(), new PauseSegment2(), new PauseSegment3()};
        gc.AddGesture("Pause", pause);
        IRelativeGestureSegment[] swipeLeft = { new SwipeToLeftSegment1(), new SwipeToLeftSegment2(), new SwipeToLeftSegment3() };
        gc.AddGesture("SwipeLeft", swipeLeft);
        IRelativeGestureSegment[] waveLeft = { new WaveLeftSegment1(), new WaveLeftSegment2(),
                                             new WaveLeftSegment1(),new WaveLeftSegment2(),
                                             new WaveLeftSegment1(),new WaveLeftSegment2() };
        gc.AddGesture("WaveLeft", waveLeft);

        IRelativeGestureSegment[] pullLeft = { new PullToLeftSegment1(), new PullToLeftSegment2(), new PullToLeftSegment3(), };
        gc.AddGesture("PullLeft", pullLeft);

        pauseManager = GameObject.FindObjectOfType<PauseManager>();
	}

    void OnGestureRecognized(object sender, GestureEventArgs e)
    {
        if (e.GestureName == "Pause")
        {
            Debug.Log("Game Paused");
            pauseManager.DoGesture();

        }
        if (e.GestureName == "SwipeLeft")
        {
            Debug.Log("Swipe Recognized");
            
        }
        if (e.GestureName == "WaveLeft")
        {
            Debug.Log("Wave Recognized");
        }
        if (e.GestureName == "PullLeft")
        {
            Debug.Log("PullLeft Recognized");
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
