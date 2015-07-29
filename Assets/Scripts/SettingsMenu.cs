using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static string PrevLevel;
    public static bool SoundEnabled = false;

    void Start()
    {
        Toggle audio = GameObject.Find("/Canvas/Audio").GetComponent<Toggle>();
        audio.isOn = !AudioListener.pause;

        Toggle autoCalibrate = GameObject.Find("/Canvas/Gyro").GetComponent<Toggle>();
        autoCalibrate.isOn = InputSettings.autoCalibrate;

        Button button = GameObject.Find("/Canvas/Calibrate").GetComponent<Button>();
        button.interactable = !InputSettings.autoCalibrate;

        Slider quality = GameObject.Find("/Canvas/GraphicsSlider").GetComponent<Slider>();
        quality.value = QualitySettings.GetQualityLevel();

        Slider difficulty = GameObject.Find("/Canvas/DifficultySlider").GetComponent<Slider>();
        difficulty.value = Game.DifficultyLevel;
    }

    public void GraphicsSliderMove(float value)
    {
        QualitySettings.SetQualityLevel((int)value);
    }

    public void DifficultySliderMove(float value)
    {
        Game.DifficultyLevel = (int)value;

        PlayerPrefs.SetInt("Difficulty", Game.DifficultyLevel);
        PlayerPrefs.Save();
    }

    public void BackClick()
    {
        Application.LoadLevel(PrevLevel);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackClick();
        }
    }

    public void CalibrateClick()
    {
        InputSettings.Calibrate();
    }

    public void ToggleSound(bool value)
    {
        AudioListener.pause = !value;

        PlayerPrefs.SetInt("SoundEnabled", SoundEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ToggleCalibration(bool value)
    {
        InputSettings.autoCalibrate = value;

        Game.SetButtonState("/Canvas/Calibrate", !value);

        PlayerPrefs.SetInt("autoCalibrate", InputSettings.autoCalibrate ? 1 : 0);
        PlayerPrefs.Save();
    }
}
