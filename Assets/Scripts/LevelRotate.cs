using UnityEngine;

public class LevelRotate : MonoBehaviour
{
	public float RotateSpeed;

    private Transform myTransform;
    private Transform playerTransform;
    private Transform cameraTransform;

	void Start ()
    {
		myTransform = transform;
		playerTransform = GameObject.Find("/Scene/Player").transform;
		cameraTransform = GameObject.Find("/Scene/Main Camera").transform;
	}
	

	void Update ()
    {
		Vector3 vect = Vector3.zero;
		vect.x = cameraTransform.position.x - playerTransform.position.x;
		vect.z = cameraTransform.position.z - playerTransform.position.z;
		vect = new Vector3 (-vect.z, 0, vect.x);

		myTransform.Rotate(vect, Input.acceleration.z * RotateSpeed * Time.deltaTime);
	}
}
