using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    float RollSpeed = 350;
    float G = -100;

    private Vector3 startPos;
    private Vector3 pos;
    private Transform myTransform;
    private Transform cameraTransform;
    private Rigidbody myRigidbody;

	void Start()
	{
		myTransform = transform;
		myRigidbody = myTransform.GetComponent<Rigidbody>();
        cameraTransform = GameObject.Find("/Scene/Main Camera").transform;
        startPos = GameObject.Find("/Scene").GetComponent<SceneScript>().startPosition;
	}

	void Update()
    {
        float time = Time.deltaTime;

        Vector3 camera = cameraTransform.forward;
        camera.y = 0;

        float z = InputSettings.originZ - Input.acceleration.z;

        if (z > 0.3)
        {
            z = 0.45F;
        }
        else if (z < -0.3)
        {
            z = -0.45F;
        }
        else
        {
            z *= 1.5F;
        }

        Vector3 move = camera * z * RollSpeed * time;

        /*if ((Input.touchCount > 0) && (lastTouch + 0.5 < Time.timeSinceLevelLoad) && Input.GetTouch(0).position.y > pos.y)
        {
            //myRigidbody.AddForce(Vector3.up * JumpSpeed * time * 1000);
            move.y = JumpSpeed * time;

            lastTouch = Time.timeSinceLevelLoad;
        }
        else*/

        move.y = G * time;

        myRigidbody.velocity = move;

		if (myTransform.position.y < 0)
        {
            myRigidbody.velocity = Vector3.zero;
            myTransform.rotation = Quaternion.identity;
            myTransform.position = startPos;
		}
	}

}
