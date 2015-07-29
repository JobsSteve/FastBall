using UnityEngine;

public class SceneScript : MonoBehaviour
{
    public Vector3 startPosition;

	void Start()
    {
        Application.LoadLevelAdditive("GUIScene");
	}
}
