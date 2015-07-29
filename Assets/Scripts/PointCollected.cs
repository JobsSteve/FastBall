using UnityEngine;

public class PointCollected : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
        Game.Points++;

		Destroy(gameObject);

        Game.CheckPoints();
	}
}
