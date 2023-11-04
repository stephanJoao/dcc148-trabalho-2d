using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] private GameObject sun;
    private float orbitRadius;
    [SerializeField] private float orbitSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        // orbitRadius receives current distance from planet to sun
        orbitRadius = Vector3.Distance(transform.position, sun.transform.position);
        // receives a random orbit speed between 0.01 and 0.04
        orbitSpeed = Random.Range(10.0f, 40.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // make planet orbit around sun
        transform.RotateAround(sun.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }
}
