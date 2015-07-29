using UnityEngine;

public class BallInHell : MonoBehaviour
{
	void OnTriggerEnter (Component other)
	{
        Transform playerTransform = other.transform;
		
		playerTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
		playerTransform.rotation = Quaternion.identity;
		playerTransform.position = new Vector3(0F, 1F, -0.5F);
	}
}
