using UnityEngine;
using System.Collections;

public abstract class FlyWeightTile{
    public string name { get; protected set; }
    public bool passable { get; protected set; }
    public bool flyable { get; protected set; }
    public int movementCost { get; protected set; }
    //More stuff here? Defense bonus, evade bonus, etc
}
