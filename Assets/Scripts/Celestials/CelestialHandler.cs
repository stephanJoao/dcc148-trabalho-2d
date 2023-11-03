using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CelestialHandler : MonoBehaviour
{
    [SerializeField] CelestialSOSetup celestialSOSetup;

    [SerializeField] CircleCollider2D circleCollider2D;
    [SerializeField] Light light;
    private MeshRenderer meshRenderer;

    private float mass;
    private float maxSpeedToDie;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        light.color = celestialSOSetup.celestialSO.color;
        meshRenderer.material.SetColor("_EmissionColor", celestialSOSetup.celestialSO.color);
        circleCollider2D.radius = celestialSOSetup.celestialSO.range;
        mass = celestialSOSetup.celestialSO.mass;

        maxSpeedToDie = celestialSOSetup.celestialSO.maxSpeedToDie;
        
    }

    public float GetMass()
    {
        return mass;
    }

    public float SetMass(float newMass)
    {
        return mass = newMass;
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
