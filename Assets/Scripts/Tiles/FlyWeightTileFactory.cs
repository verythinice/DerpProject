using UnityEngine;
using System.Collections;

public class FlyWeightTileFactory : MonoBehaviour{
    private FlyWeightTile[] tiles;

	// Use this for initialization
	void Start () {
	    tiles = new FlyWeightTile[GetComponent<TileSheetScript>().textureSize^2];
	}

    public FlyWeightTile getTile(int i)
    {
        if (tiles[i] == null)
        {
            switch (i)
            {
                case 0: tiles[i] = new GrassTile(); break;
                case 1: tiles[i] = new WaterTile(); break;
                default:
                    break;
            }
        }
        return tiles[i];
    }
}
