using UnityEngine;

public static class InputSettings
{
    public static bool autoCalibrate { get; set; }

    public static float originZ{ get; private set; }

    public static void LoadData()
    {
        autoCalibrate = (PlayerPrefs.GetInt("autoCalibrate", 1) == 1);
        originZ = PlayerPrefs.GetFloat("Z", 0F);
    }

    public static bool TouchBegan() // nefunguje?
    {
        return ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began));
    }

    public static bool TouchEnded() // nefunguje?
    {
        return ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Ended));
    }

    public static void AutoCalibrate()
    {
        if (autoCalibrate)
            Calibrate();
    }

    public static void Calibrate()
    {
        originZ = Input.acceleration.z;

        PlayerPrefs.SetFloat("Z", originZ);
        PlayerPrefs.Save();
    }
}
