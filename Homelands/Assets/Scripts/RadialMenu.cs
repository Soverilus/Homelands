using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour {
    TileStats myStats;
    bool canBeBuiltOn = false;
    bool isCity;
    GameObject structure;
    List<GameObject> units = new List<GameObject>();
    string myFaction;
    List<GameObject> myTerritory = new List<GameObject>();
    //okay so, this is brought up from tileselection. I need to take from TileStats, and get Structures, Units, etc.

    //case for selecting "Settler"
    //case for selecting "City"
    //case for selecting "Tile"
    private void Start() {
        myStats = GetComponent<TileStats>();
    }

    private void Update() {
        canBeBuiltOn = myStats.canBeBuiltOn;
        isCity = myStats.isCity;
        structure = myStats.structure;
        units = myStats.units;
        myFaction = myStats.myFaction;
        myTerritory = myStats.myTerritory;
    }

    public void OptionsDetection() {
        foreach(GameObject gameObject in units) {
            //add gameObject to Radial menu.
        }
        if (isCity)
        foreach(GameObject gameObject in myTerritory) {
            //display territory bounds based on the object mesh bounds somehow??
        }
    }
}