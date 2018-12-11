using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSetup : MonoBehaviour {
    public Vector2 myTileOffset;
    public Vector2 myShipOffset;
    public GameObject myShip;
    public int resourceRarity;
    [HideInInspector]
    public GameObject[] allTiles;
    public GameObject[] ornamentsFood;
    public GameObject[] ornamentsMat;
    public Vector2 oceanFoodMat;
    public Vector2 riverFoodMat;
    public Vector2 mountainFoodMat;
    List<GameObject> oceanGameObjects = new List<GameObject>();
    Vector3 shipSpawnPosition;

    public void SetTilesAndStats () {
        allTiles = GameObject.FindGameObjectsWithTag("Tiles");
		for (int i = 0; i < allTiles.Length; i++) {
            allTiles[i].transform.position += Vector3.up * Random.Range(myTileOffset.x, myTileOffset.y);

            TileType myTType = allTiles[i].GetComponent<TileType>();
            myTType.oceanFoodMat = oceanFoodMat;
            myTType.riverFoodMat = riverFoodMat;
            myTType.mountainFoodMat = mountainFoodMat;
            myTType.SetupType();

            TileStats myTStats = allTiles[i].GetComponent<TileStats>();
            myTStats.resourceRarity = resourceRarity;
            myTStats.ornamentsFood = ornamentsFood;
            myTStats.ornamentsMat = ornamentsMat;
            myTStats.UseTypeOrNo();

            if (myTType.tileTypeIs == ("Ocean")) {
                oceanGameObjects.Add(allTiles[i]);
            }
        }
        shipSpawnPosition = oceanGameObjects[Random.Range(0, oceanGameObjects.Count + 1)].transform.position + Vector3.up * Random.Range(myShipOffset.x, myShipOffset.y);
        Instantiate(myShip, shipSpawnPosition, Quaternion.identity);
	}
}
