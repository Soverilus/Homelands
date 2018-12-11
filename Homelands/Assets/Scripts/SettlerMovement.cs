using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlerMovement : MonoBehaviour {
    public bool selected = false;
    GameObject myTile;
    Vector3 targetPos;
    Vector3 oldPos;
    int myActionPoints;
    bool isShip;
    public bool isImperial;
    bool hasMyTile = false;
    int population;
    List<GameObject> moveSpaces = new List<GameObject>();

    private void Update() {
        if (oldPos != targetPos) {
            transform.position = Vector3.Lerp(oldPos, targetPos, 0.1f);
        }
        //when my new pos is my old pos and I don't have myTile
        else if (!hasMyTile) TileCheck();
    }
   public  void MoveUnitToSelection(GameObject target) {
        if (moveSpaces.Contains(target) && myActionPoints > 0 && target != myTile) {
            oldPos = transform.position;
            targetPos = target.transform.position;
            myActionPoints -= 1;
            hasMyTile = false;
        }
    }

    void TileCheck() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
            if (hit.collider.gameObject.GetComponent<TileType>() != null) {

                if (hit.collider.gameObject.GetComponent<TileType>().tileTypeIs == "Ocean") isShip = true;
                else isShip = false;

                myTile = hit.collider.gameObject;
                hasMyTile = true;
            }
        }
        else Debug.Log("There is no tile under me! Help! I'm " + gameObject.name);
    }
    private void OnTriggerStay(Collider other) {
        if (!moveSpaces.Contains(other.gameObject)) {
            moveSpaces.Add(other.gameObject);
        }
    }
}
