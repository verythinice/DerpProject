using UnityEngine;
using System.Collections;

public class WaterTile : FlyWeightTile {
    public WaterTile()
    {
        this.name = "water";
        this.passable = false;
        this.movementCost = 1;
    }
}
