using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    enum TurnType {FirstTurn, FirstConflict, Turn, Conflict, Income}
    enum TurnFaction {Native, Colonial, Combined}
    bool combinedExists;
    bool wasNative;

    TurnType turnState = TurnType.FirstTurn;
    TurnFaction factionState = TurnFaction.Colonial;
    private void Update() {
        switch (turnState) {
            case TurnType.FirstTurn:
                //select first colonised tile
                //then build stuff on the tiles around it
                //spawn barbarian camp next to first colonialised tile
                //firstconflict turn
                break;
            case TurnType.FirstConflict:
                //conflict with barbarians
                //barbarians CANNOT win
                //Cycle Faction, cycle to Turn
                break;
        }
    }
    void CycleFaction() {
        switch (factionState) {
            case TurnFaction.Native:
                if (combinedExists && !wasNative) {
                    wasNative = true;
                    factionState = TurnFaction.Combined;
                }
                else factionState = TurnFaction.Colonial;
                break;
            case TurnFaction.Colonial:
                if (combinedExists && wasNative) {
                    wasNative = false;
                    factionState = TurnFaction.Combined;
                }
                else factionState = TurnFaction.Native;
                break;
        }
    }
}