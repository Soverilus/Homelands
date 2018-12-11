using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStateSelection : MonoBehaviour {
    MeshRenderer myMR;
    Material myMaterial;
    public Material highlightMaterial;
    public bool selectable;

    private void Start() {
        myMR = GetComponent<MeshRenderer>();
        myMaterial = myMR.material;
    }

    void OnMouseEnter() {
        //Debug.Log("the mouse entered this");
        if (selectable) {
            myMR.material = highlightMaterial;
            //show income, taxation, and pollution in radial fade.
        }
    }

    void OnMouseExit() {
        myMR.material = myMaterial;
    }

    void OnMouseDown() {
        Debug.Log("I have clicked");
        if (selectable){
           //select this tile, open radial menu for options
        }
    }
    void OnMouseUp() {
        //on center of radial, do nothing. on outside, do option
    }
}
