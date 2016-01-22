using UnityEngine;
using System.Collections;

public abstract class FlyWeightTile{
    protected string name { get; set; }
    protected bool passable { get; set; }
    protected int movementCost { get; set; }
    //More stuff here? Defense bonus, evade bonus, etc
}
