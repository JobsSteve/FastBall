using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private  static Text cubesText;

    void Awake()
    {
        if (!Debug.isDebugBuild)
            Application.targetFrameRate = 60;

        Slider cubesSlider = GameObject.Find("/Canvas/Panel 2/Slider").GetComponent<Slider>();
        cubesSlider.value = (LevelGenerator.cubes / 10);

        cubesText = GameObject.Find("/Canvas/Panel 2/Cubes").GetComponent<Text>();
        cubesText.text = LevelGenerator.cubes + " cubes";

        if (Game.Level == 0)
        {
            Game.SetButtonState("/Canvas/Panel 1/Load Game", false);
        }
    }

    public void NewGameClick()
    {
        Game.NewGame();
    }

    public void LoadGameClick()
    {
        Game.LoadGame();
    }

    public void GenerateLevelClick()
    {
        Game.GenerateGame();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitClick();
        }
    }

    public void MenuClick()
    {
        SettingsMenu.PrevLevel = "MenuScene";
        Application.LoadLevel("SettingsMenu");
    }

    public void ExitClick()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
        //Application.Quit();
    }

    public void SliderMove(float value)
    {
        LevelGenerator.cubes = (ushort)(value * 10);

        cubesText.text = LevelGenerator.cubes + " cubes";
    }
}
