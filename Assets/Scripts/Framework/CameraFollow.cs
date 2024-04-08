using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Script for camera to follow the player
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
