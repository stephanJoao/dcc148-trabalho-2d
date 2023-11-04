using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CelestialHandler : MonoBehaviour
{
    [SerializeField] CelestialSOSetup celestialSOSetup;

    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] Light light;
    private MeshRenderer meshRenderer;

    [SerializeField] private float size;
    [SerializeField] private float maxSize;
    [SerializeField] private float mass;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        size = celestialSOSetup.celestialSO.size;
        maxSize = size;
        mass = celestialSOSetup.celestialSO.mass;
        circleCollider2D.radius = celestialSOSetup.celestialSO.range;
        light.color = celestialSOSetup.celestialSO.color;

        transform.localScale = new Vector3(maxSize, maxSize, maxSize);

        meshRenderer.material.SetColor("_EmissionColor", celestialSOSetup.celestialSO.color);        
    }
    private void Update()
    {
        transform.localScale = new Vector3(size, size, size);    
    }

    // Getters and Setters
    public float GetSize()
    {
        return size;
    }

    public float SetSize(float newSize)
    {
        return size = newSize;
    }
    public float GetMaxSize()
    {
        return maxSize;
    }
    
    public float GetMass()
    {
        return mass;
    }

    public void SetMass(float newMass)
    {
        mass = newMass;
    }    
}

[System.Serializable]
public class CelestialSOSetup
{
    public CelestialSO celestialSO;
}
