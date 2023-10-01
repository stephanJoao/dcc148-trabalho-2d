using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CelestialHandler : MonoBehaviour
{
    [SerializeField] CelestialSOSetup celestialSOSetup;

    [SerializeField] CircleCollider2D circleCollider2D;
    private MeshRenderer meshRenderer;

    private float mass;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.sharedMaterial.color = celestialSOSetup.celestialSO.color;
        circleCollider2D.radius = celestialSOSetup.celestialSO.range;
        mass = celestialSOSetup.celestialSO.mass;
    }

    public float GetMass()
    {
        return mass;
    }
}

[System.Serializable]
public class CelestialSOSetup
{
    public CelestialSO celestialSO;
}
