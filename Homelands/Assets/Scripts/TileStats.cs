using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStats : MonoBehaviour {
    //for now hide thisvv
    [HideInInspector]
    public int resourceRarity;
    //for now hide this^^

    TileType myType;
    bool yes = false;
    bool tileActive = false;

    [HideInInspector]
    public GameObject[] ornamentsFood;
    [HideInInspector]
    public GameObject[] ornamentsMat;

    public int food;
    public int materials;
    public bool canBeBuiltOn = false;
    [HideInInspector]
    public bool isCity;
    [HideInInspector]
    public GameObject structure;
    [HideInInspector]
    public List<GameObject> units = new List<GameObject>();
    public string myFaction = "Neutral";
    public List<GameObject> myTerritory = new List<GameObject>();

	void CheckType() {
        myType = GetComponent<TileType>();
        yes = myType.useTileType;
	}

    public void UseTypeOrNo() {
        CheckType();
        if (yes) {
            canBeBuiltOn = false;
            food = Mathf.RoundToInt(myType.actualFoodMat.x);
            materials = Mathf.RoundToInt(myType.actualFoodMat.y);
        }
        else {
            canBeBuiltOn = true;
            SetupTileCounter();
        }
    }

    void SetupTileCounter() {
        int myTileContains = Random.Range(0, resourceRarity);
        int myTileQuality = Random.Range(0, 2);
        switch (myTileContains) {
            case 0:
                Instantiate(ornamentsFood[myTileQuality], new Vector3(transform.position.x, transform.position.y + 100, transform.position.z), Quaternion.identity);
                food = 2 + myTileQuality;
                materials = 0;
                break;
            case 1:
                Instantiate(ornamentsMat[myTileQuality], new Vector3(transform.position.x, transform.position.y + 100, transform.position.z), Quaternion.identity);
                materials = 2 + myTileQuality;
                food = 0;
                break;
            default:
                food = 1 + myTileQuality;
                materials = 1 + myTileQuality;
                break;
        }
    }

        private void OnCollisionEnter(Collision collision) {
        if (!tileActive) {
            if (collision.gameObject.tag == "TileOrnament") {
                //activate something on ornament collision
            }
        }
    }
}
