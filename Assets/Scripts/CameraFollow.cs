using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public float cameraHeight = 0.0f;

    private void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z += cameraHeight;
        transform.position = pos;
    }
}