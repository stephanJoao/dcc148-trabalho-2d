
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private float speedX;
    private float speedY;
    private float playerMagnitude;
    private float speedXY;

    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        acceleration = 20.0f;
        playerMagnitude = 70.0f;
        speedX = 0;
        speedY = 0;
        speedXY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * acceleration;
        speedY = Input.GetAxis("Vertical") * acceleration;

        speedXY = Mathf.Abs(Mathf.Sqrt(playerRb.velocity.x * playerRb.velocity.x + playerRb.velocity.y * playerRb.velocity.y));
        
        playerRb.AddForce(new Vector2(speedX, speedY));
        
        // limit player rigidbody velocity
        if (playerRb.velocity.magnitude > playerMagnitude)
        {
            playerRb.velocity = playerRb.velocity.normalized * playerMagnitude;
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
        if (other.gameObject.tag == "SunObject")
        {
			CelestialHandler celestialHandler = other.gameObject.GetComponentInParent<CelestialHandler>();
            
            Debug.Log(speedXY);
            
            float speedPercentual = speedXY / 1000.0f;
                        
            celestialHandler.SetSize(celestialHandler.GetSize() - (celestialHandler.GetSize() * speedPercentual));

            if(celestialHandler.GetSize() < 0.5 * celestialHandler.GetMaxSize())
            {
                Destroy(celestialHandler.gameObject);
            }

            //if(speedPercentual > 0.5)
            //Destroy(celestialHandler.gameObject);
            //float newScale = other.gameObject.transform.localScale.x - (1/(other.gameObject.transform.localScale.x * 0.1f));



        }
    }
}
