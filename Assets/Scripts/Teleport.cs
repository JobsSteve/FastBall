using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public Transform teleportToTransform;

    void OnTriggerEnter(Collider other)
    {
        Transform playerTransform = other.transform;

        playerTransform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerTransform.rotation = Quaternion.identity;
        playerTransform.position = new Vector3(teleportToTransform.position.x, teleportToTransform.position.y + 1, teleportToTransform.position.z);
    }
}
