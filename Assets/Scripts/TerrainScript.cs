using UnityEngine;
using System.Collections;

public class TerrainScript : MonoBehaviour {
    private int[,] locations;
    private FlyWeightTileFactory factory;

	// Use this for initialization
	void Start () {
        locations = GetComponent<TileSheetScript>().getMap();
        factory = GetComponent<FlyWeightTileFactory>();
	}

    public FlyWeightTile getTile(int x, int y)
    {
        return factory.getTile(locations[x, y]);
    }
}
