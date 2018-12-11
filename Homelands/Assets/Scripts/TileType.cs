using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileType : MonoBehaviour {
    public string tileTypeIs;

    [HideInInspector]
    public Vector2 oceanFoodMat;
    [HideInInspector]
    public Vector2 riverFoodMat;
    [HideInInspector]
    public Vector2 mountainFoodMat;
    [HideInInspector]
    public Vector2 actualFoodMat;

    [HideInInspector]
    public bool useTileType = false;
    
    public void SetupType() {
        switch (tileTypeIs) {
            case "Ocean":
                actualFoodMat = oceanFoodMat;
                useTileType = true;
                break;

            case "River":
                actualFoodMat = riverFoodMat;
                useTileType = true;
                break;

            case "Mountains":
                actualFoodMat = mountainFoodMat;
                useTileType = true;
                break;
        }
    }
}
