using UnityEngine;
using System.Collections;

public class GrassTile : FlyWeightTile {
    public GrassTile()
    {
        this.name = "grass";
        this.passable = true;
        this.movementCost = 1;
    }
}
