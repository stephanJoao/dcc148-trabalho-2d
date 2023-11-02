
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private float speedX;
    private float speedY;
    private float speedXY;

    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        acceleration = 10.0f;
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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Sun"))
        {
            CelestialHandler celestialHandler = other.GetComponentInParent<CelestialHandler>();
            float distance = Vector2.Distance(transform.position, other.transform.position);
            Vector2 direction = (transform.position - other.transform.position).normalized;

            playerRb.AddForce(-direction / (distance * distance) * GameManager.gravitance * celestialHandler.GetMass());
            
            celestialHandler.SetMaxSpeedToDie(celestialHandler.GetMass());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "SunObject")
        {
            Debug.Log("SunObject");
			// decrease mass of the sun
			/*CelestialHandler celestialHandler = other.gameObject.GetComponentInParent<CelestialHandler>();
            celestialHandler.SetMass(celestialHandler.GetMass() - 1);
            celestialHandler.SetMaxSpeedToDie(celestialHandler.GetMass());
            Destroy(other.gameObject);*/

			CelestialHandler celestialHandler = other.gameObject.GetComponentInParent<CelestialHandler>();
            float speedPercentual = speedXY / celestialHandler.GetMaxSpeedToDie();
            if(speedPercentual > 0.5)
                Destroy(celestialHandler.gameObject);
            else
            {
                celestialHandler.SetMass(celestialHandler.GetMass() - (celestialHandler.GetMass() * speedPercentual));
            }
			
        }
    }
}
