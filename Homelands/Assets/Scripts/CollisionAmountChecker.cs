using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAmountChecker : MonoBehaviour {
    [HideInInspector]
    public int mountOfCollisions;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == ("Tiles"))
        mountOfCollisions++;
        //Debug.Log(mountOfCollisions);
    }
}
