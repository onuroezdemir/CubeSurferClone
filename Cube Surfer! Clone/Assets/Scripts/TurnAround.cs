using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    [Space]
    [SerializeField]
    private Vector3 rotatePerSecond = new Vector3(0f, 50f, 0f);

    void Update()
    {
        transform.Rotate(rotatePerSecond * Time.deltaTime);
    }
}
