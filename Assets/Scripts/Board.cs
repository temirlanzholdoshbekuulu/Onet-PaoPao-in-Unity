﻿using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int gridHeight;
    public int gridWidth;
    [SerializeField] Transform[] tilePrefabs;
    [SerializeField] Transform emptyTilePrefab;
    [SerializeField] CheckPairs checkPairsClass;
    public Tile[,] tiles;
    public List<Transform> availableTiles = new List<Transform>();
    public int tilesCount;

    void Start()
    {
        SpawnGrid();
    }
    void DuplicateTiles()
    {
        foreach (Transform tilePrefab in tilePrefabs)
        {
            for (int i = 0; i < 4; i++)
            {
                availableTiles.Add(tilePrefab);
            }
        }
    }
    public void SpawnGrid()
    {
        tiles = new Tile[gridWidth, gridHeight];
        DuplicateTiles();
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                tilesCount = tilesCount + 1;
                Tile tile = (IsOnBorder(x, y) ? emptyTilePrefab.GetComponent<Tile>() : SelectRandomTile());
                tiles[x, y] = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity, this.gameObject.transform);
            }
        }
    }

    bool IsOnBorder(int x, int y)
    {
        return x == 0 || x == gridWidth-1 || y == 0 || y == gridHeight -1;
    }

    Tile SelectRandomTile()
    {
        int randomTileIndex = Random.Range(0, availableTiles.Count);
        Tile randomTile = availableTiles[randomTileIndex].GetComponent<Tile>();
        availableTiles.RemoveAt(randomTileIndex);
        return randomTile;
    }
    
}