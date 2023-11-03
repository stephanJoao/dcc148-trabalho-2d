using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialTilesSpawnHandler : MonoBehaviour
{
    [SerializeField] List<CelestialTilesSO> tiles;

    [SerializeField] float gapBetweenTiles;
    [SerializeField] int tilesNumber;

    [SerializeField] Grid grid;

    [SerializeField] GameObject player;

    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnTilesCoroutine());
    }

    IEnumerator SpawnTilesCoroutine()
    {
        for(var i = 0; i < tilesNumber; i++)
        {
            var tile = tiles[UnityEngine.Random.Range(0, tiles.Capacity)];
            var pos = grid.GetCellCenterWorld(grid.LocalToCell(new Vector3(player.transform.position.x + (gapBetweenTiles * i), player.transform.position.y, 1)));
            Instantiate(tile.celestialTile, pos, Quaternion.identity);
        }
        yield return null;  
    }
}

[Serializable]
public class CelestialTileSetup
{
    public CelestialTilesSO celestialTilesSO;

}
