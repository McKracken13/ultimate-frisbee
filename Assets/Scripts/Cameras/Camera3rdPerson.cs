using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera3rdPerson : MonoBehaviour
{
    public Transform player;
    public float speed = 0.9f;
    public float minCamDistance = 5f;
    public float maxCamDistance = 10f;
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isLocalPlayer()) return;

        // Go to nice spot
        Vector3 direction = player.direction;
        // direction.y = 0;
        if (direction.magnitude < minCamDistance || direction.magnitude > maxCamDistance)
        {
            Vector3 target = player.position;
            target.y = transform.position.y;
            target += Vector3.ClampMagnitude(-direction, 1) * minCamDistance;
            direction = target - transform.position;
            float distance_trail = direction.magnitude * speed * Time.deltaTime;
            //transform.position = Vector3.Lerp(transform.position, target, step);
            transform.position = player.position - distance_trail*direction;
        }
    }

    bool isLocalPlayer()
    {
        return gameObject.transform.parent.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer;
    }
}
