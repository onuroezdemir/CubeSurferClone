using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChase : MonoBehaviour
{
    private GameObject player;
    private float offsetZ;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        offsetZ = transform.position.z - player.transform.position.z;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y, player.transform.position.z + offsetZ);
    }
}
