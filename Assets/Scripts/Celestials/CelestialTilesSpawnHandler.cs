using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialTilesSpawnHandler : MonoBehaviour
{
    [SerializeField] List<CelestialTilesSO> tiles;

    [SerializeField] float gapBetweenTilesX;
    [SerializeField] float gapBetweenTilesY;

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
        var j = 0;
        for(var i = 0; i < tilesNumber; i++)
        {
            if(i % 5 == 0)
            {
                gapBetweenTilesY += 200;
                j = 0;
            }
            var tile = tiles[UnityEngine.Random.Range(0, tiles.Capacity)];
            var pos = grid.GetCellCenterWorld(grid.LocalToCell(new Vector3(player.transform.position.x + (gapBetweenTilesX * j), player.transform.position.y + gapBetweenTilesY, 1)));
            Instantiate(tile.celestialTile, pos, Quaternion.identity);
            j++;
        }
        yield return null;  
    }
}

[Serializable]
public class CelestialTileSetup
{
    public CelestialTilesSO celestialTilesSO;

}
