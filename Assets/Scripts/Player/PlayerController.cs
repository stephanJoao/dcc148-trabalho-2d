
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private float speedX;
    private float speedY;

    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        acceleration = 20.0f;
        speedX = 0;
        speedY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * acceleration;
        speedY = Input.GetAxis("Vertical") * acceleration;

        playerRb.AddForce(new Vector2(speedX, speedY));
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Sun"))
        {
            CelestialHandler celestialHandler = other.GetComponentInParent<CelestialHandler>();
            float distance = Vector2.Distance(transform.position, other.transform.position);
            Vector2 direction = (transform.position - other.transform.position).normalized;

            playerRb.AddForce(-direction / (distance * distance) * GameManager.gravitance * celestialHandler.GetMass());
        }
    }
}
