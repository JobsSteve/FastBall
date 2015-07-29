using UnityEngine;

public class LaunchGame : MonoBehaviour {

	void Start ()
    {
        Input.gyro.enabled = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Game.LoadData();

        Application.LoadLevel("MenuScene");
	}
}
