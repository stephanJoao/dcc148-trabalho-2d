
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private Rigidbody2D playerRb;

    private float speedX;
    private float speedY;
    private float playerMaxMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        acceleration = 20.0f;
        playerMaxMagnitude = 70.0f;
        speedX = 0;
        speedY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * acceleration;
        speedY = Input.GetAxis("Vertical") * acceleration;
        
        playerRb.AddForce(new Vector2(speedX, speedY));
        
        // limit player rigidbody velocity
        if (playerRb.velocity.magnitude > playerMaxMagnitude)
        {
            playerRb.velocity = playerRb.velocity.normalized * playerMaxMagnitude;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // collision with trigger range (gravity)
        if (other.CompareTag("Sun"))
        {
            CelestialHandler celestialHandler = other.GetComponentInParent<CelestialHandler>();
            Vector2 direction = (transform.position - other.transform.position).normalized;
               
            playerRb.AddForce(-direction * GameManager.gravitance * celestialHandler.GetMass());
            
            celestialHandler.SetMaxSpeedToDie(celestialHandler.GetMass());
        }

        // collision with trigger range (gravity)
        if (other.CompareTag("Planet"))
        {
            CelestialHandler celestialHandler = other.GetComponentInParent<CelestialHandler>();
            Vector2 direction = (transform.position - other.transform.position).normalized;

            playerRb.AddForce(-direction * GameManager.gravitance * celestialHandler.GetMass());

            celestialHandler.SetMaxSpeedToDie(celestialHandler.GetMass());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // collision with planet (destruction)
        if (other.gameObject.tag == "PlanetObject")
        {
			CelestialHandler celestialHandler = other.gameObject.GetComponentInParent<CelestialHandler>();
                        
            float magnitudePercentual = playerRb.velocity.magnitude / playerMaxMagnitude;
                        
            celestialHandler.SetSize(celestialHandler.GetSize() - (celestialHandler.GetSize() * magnitudePercentual * 0.25f));

            if(celestialHandler.GetSize() < 0.5 * celestialHandler.GetMaxSize())
            {
                Destroy(celestialHandler.gameObject);
            }

        }
    }
}
