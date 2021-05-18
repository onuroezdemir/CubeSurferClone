using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;

    private Vector3 startMousePosition;

    public float sensitivity = .15f;
    public float clampDelta = 50f;
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float bounds = 2f;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y, transform.position.z);

        if (Input.GetMouseButtonDown(0) && GameManager.instance.currentState == GameManager.GameState.DefaultGameState)
        {
            startMousePosition = Input.mousePosition;
            EventManager.OnGameStarted?.Invoke();
        }

    }

    private void FixedUpdate()
    {
        if (GameManager.instance.currentState == GameManager.GameState.StartGameState)
        {


            body.transform.position += Vector3.forward * speed;

            if (Input.GetMouseButtonDown(0))
            {
                startMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 currentVector = startMousePosition - Input.mousePosition;
                startMousePosition = Input.mousePosition;

                currentVector = new Vector3(currentVector.x, 0, 0);

                Vector3 moveForce = Vector3.ClampMagnitude(currentVector, clampDelta);

                body.AddForce(-moveForce * sensitivity - body.velocity / 5f, ForceMode.VelocityChange);
            }

            body.velocity.Normalize();

        }
    }
}
