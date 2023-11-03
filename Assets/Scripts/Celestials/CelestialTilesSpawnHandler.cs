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
        for(tilesNumber = 0; tilesNumber < tiles.Count; tilesNumber++)
        {
            var tile = tiles[UnityEngine.Random.Range(0, tiles.Capacity)];
            var pos = grid.GetCellCenterWorld(grid.LocalToCell(player.transform.position *tilesNumber * 100));
            Instantiate(tile.celestialTile, pos, Quaternion.identity);
        }
        yield return null;  
    }
}

[Serializable]
public class CeletialTileSetup
{
    public CelestialTilesSO celestialTilesSO;

}
