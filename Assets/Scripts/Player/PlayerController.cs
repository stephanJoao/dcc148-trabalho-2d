
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float acceleration;
    private float accelerationX;
    private float accelerationY;
    private float playerMaxMagnitude;
    private float playerMinMagnitudePercentual;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        acceleration = 25.0f;
        accelerationX = 0;
        accelerationY = 0;
        playerMaxMagnitude = 80.0f;
        playerMinMagnitudePercentual = 0.20f;
    }

    // Update is called once per frame
    void Update()
    {
        accelerationX = Input.GetAxis("Horizontal") * acceleration;
        accelerationY = Input.GetAxis("Vertical") * acceleration;
                
        playerRb.AddForce(new Vector2(accelerationX, accelerationY));
        
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
               
            playerRb.AddForce(-direction * celestialHandler.GetMass());
        }

        // collision with trigger range (gravity)
        if (other.CompareTag("Planet"))
        {
            CelestialHandler celestialHandler = other.GetComponentInParent<CelestialHandler>();
            Vector2 direction = (transform.position - other.transform.position).normalized;

            playerRb.AddForce(-direction * celestialHandler.GetMass());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // collision with planet (destruction)
        if (other.gameObject.tag == "PlanetObject")
        {
			CelestialHandler celestialHandler = other.gameObject.GetComponentInParent<CelestialHandler>();
                        
            
            // calculate impulse of collision
            ContactPoint2D[] contacts = new ContactPoint2D[other.contactCount];
            other.GetContacts(contacts);
            float totalImpulse = 0;
            foreach (ContactPoint2D contact in contacts)
            {
                totalImpulse += contact.normalImpulse;
            }
            //Debug.Log(totalImpulse);

            // check minimum impulse 
            if (true)
            {
                // reduce planet size by one quarter of how fast percentually the player is                                    
                celestialHandler.SetSize(celestialHandler.GetSize() - (totalImpulse * 0.025f));
                celestialHandler.SetMass(celestialHandler.GetMass() - (totalImpulse * 0.025f));
                // add score to player
                GameManager.instance.AddScore((totalImpulse * 0.25f));
            }

            // destroys planet if it's size is less than 40% of it's original size
            if (celestialHandler.GetSize() < 0.40f * celestialHandler.GetMaxSize())
            {
                // add score to player (rest of planet's mass)
                GameManager.instance.AddScore(celestialHandler.GetMass());
                // destroy planet
                Destroy(celestialHandler.gameObject);
            }


        }        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        // collision with sun (reduce score with time)
        if (other.gameObject.tag == "SunObject")
        {
            CelestialHandler celestialHandler = other.gameObject.GetComponentInParent<CelestialHandler>();
            // reduce score by 0.3% of sun mass
            GameManager.instance.AddScore(-celestialHandler.GetMass() * 0.003f * Time.deltaTime);
        }
    }
}
