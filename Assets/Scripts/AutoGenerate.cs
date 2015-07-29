using UnityEngine;

public class AutoGenerate : MonoBehaviour
{
	void Start ()
    {
        LevelGenerator lg = GetComponent<LevelGenerator>();
		lg.Generate2D();
	}
}
