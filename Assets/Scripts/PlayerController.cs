using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private float speedX;
    private float speedY;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        acceleration = 10.0f;
        speedX = 0;
        speedX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * acceleration;
        speedY = Input.GetAxis("Vertical") * acceleration;

        playerRb.AddForce(new Vector2(speedX, speedY));
    }
}
