using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CelestialHandler : MonoBehaviour
{
    [SerializeField] CelestialSOSetup celestialSOSetup;

    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] Light light;
    private MeshRenderer meshRenderer;

    private float size;
    private float maxSize;
    private float mass;
    private float maxSpeedToDie;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        size = celestialSOSetup.celestialSO.size;
        maxSize = size;
        mass = celestialSOSetup.celestialSO.mass;
        circleCollider2D.radius = celestialSOSetup.celestialSO.range;
        light.color = celestialSOSetup.celestialSO.color;
        maxSpeedToDie = celestialSOSetup.celestialSO.maxSpeedToDie;

        transform.localScale = new Vector3(maxSize, maxSize, maxSize);

        meshRenderer.material.SetColor("_EmissionColor", celestialSOSetup.celestialSO.color);        
    }
    private void Update()
    {
        transform.localScale = new Vector3(size, size, size);    
    }

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
    
    public float SetMaxSpeedToDie(float mass)
    {
        return maxSpeedToDie = mass * 50;
    }
    
    public float GetMaxSpeedToDie()
    {
        return maxSpeedToDie;
    }
}

[System.Serializable]
public class CelestialSOSetup
{
    public CelestialSO celestialSO;
}
