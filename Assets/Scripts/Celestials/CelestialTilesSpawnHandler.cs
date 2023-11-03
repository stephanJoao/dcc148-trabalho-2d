using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialTilesSpawnHandler : MonoBehaviour
{
    [SerializeField] List<CelestialTilesSO> tiles;

    [SerializeField] float gapBetweenTiles;

    [SerializeField] Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<CelestialTilesSO>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class CeletialTileSetup
{
    public CelestialTilesSO celestialTilesSO;

}
