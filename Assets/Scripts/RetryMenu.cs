using UnityEngine;
using UnityEngine.UI;

public class RetryMenu : MonoBehaviour
{
    public static string Message;
    public static string PrevLevel;

	void Start ()
    {
        Text messageText = GameObject.Find("/Canvas/Message").GetComponent<Text>();
        messageText.text = Message;

        Text pointsText = GameObject.Find("/Canvas/Points").GetComponent<Text>();
        pointsText.text += "<color=yellow>" + Game.Points + "/" + Game.MaxPoints + "</color>";
	}

    public void RetryClick()
    {
        Game.RetryLevel(PrevLevel);
    }

    public void MenuClick()
    {
        Application.LoadLevel("MenuScene");
    }
}
