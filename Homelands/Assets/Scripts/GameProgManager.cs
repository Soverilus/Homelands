using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgManager : MonoBehaviour {
    public CameraMovement myCamMove;
    public TileSetup myTileSetup;
    enum GameProg { Setup, Gameplay, Endgame }
    GameProg gameProg = GameProg.Setup;
    bool hasStarted = false;

    void Start() {
        if ((myTileSetup == null)){
            myTileSetup = GetComponent<TileSetup>();
        }
    }

    void Update() {
        switch (gameProg) {
            case GameProg.Setup:
                if (!hasStarted) {
                    myCamMove.camLock = true;
                    myTileSetup.SetTilesAndStats();
                    hasStarted = true;
                }
                CollisionAmountChecker background = GameObject.FindGameObjectWithTag("Background").GetComponent<CollisionAmountChecker>();
                //Debug.Log(background.mountOfCollisions);
                if (background.mountOfCollisions > 600) {
                    myCamMove.camLock = false;
                    gameProg = GameProg.Gameplay;
                }
                break;

            case GameProg.Gameplay:
                break;

            case GameProg.Endgame:
                break;

            default:
                break;
        }
    }

}
