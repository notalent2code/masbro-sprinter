using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject tilePrefab = tilePrefabs[tileIndex];

        // Check if the tilePrefab already exists in activeTiles
        if (activeTiles.Exists(tile => tile == tilePrefab))
        {
            // Choose another tile that is not in activeTiles
            int newIndex = Random.Range(0, tilePrefabs.Length);
            while (newIndex == tileIndex || activeTiles.Exists(tile => tile == tilePrefabs[newIndex]))
            {
                newIndex = Random.Range(0, tilePrefabs.Length);
            }
            tileIndex = newIndex;
            tilePrefab = tilePrefabs[tileIndex];
        }

        GameObject go = Instantiate(tilePrefab, transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
