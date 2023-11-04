using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] private GameObject sun;
    [SerializeField] private float orbitRadius;
    [SerializeField] private float orbitSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        // orbitRadius receives current distance from planet to sun
        orbitRadius = Vector3.Distance(transform.position, sun.transform.position);
        orbitSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        // make planet orbit around sun
        transform.RotateAround(sun.transform.position, Vector3.forward, orbitSpeed);
    }
}
