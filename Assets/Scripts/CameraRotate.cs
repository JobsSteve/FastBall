using UnityEngine;

public class CameraRotate : MonoBehaviour
{
	public Transform target;
	public float distance = 10.0F;
	
	public float xSpeed = 250.0F;
	public float ySpeed = 120.0F;
	
	public float yMinLimit = -20F;
	public float yMaxLimit = 80F;
	
	float x = 0.0F;
	float y = 0.0F;

	void Start()
	{
		var angles = transform.eulerAngles;
		x = angles.y;
        y = angles.x;

        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
            audio.mute = AudioListener.pause;
	}

	void LateUpdate()
	{
	    if (!target)
            return;

	    if (!Game.Paused)
	        x += Input.acceleration.x * xSpeed;
			
	    Quaternion rotation = Quaternion.Euler(y, x, 0);
	    Vector3 position = rotation * new Vector3(0.0F, 0.0F, -distance) + target.position;
			
	    transform.rotation = rotation;
	    transform.position = position;
	}
}
