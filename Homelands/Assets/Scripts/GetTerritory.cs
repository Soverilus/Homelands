using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTerritory : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == ("Tiles")) {
            //add tile to my income and territory
            //add building options on my turn
        }
    }
}
