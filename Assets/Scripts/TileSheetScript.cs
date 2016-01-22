using UnityEngine;
using System.Collections;
using System;

public class TileSheetScript : MonoBehaviour
{
    public int xSize;
    public int ySize;
    public int textureSize;
    public TextAsset level;
    private int[,] tileMap;

    // Use this for initialization
    void Awake()
    {
        tileMap = new int[xSize,ySize];
        string levelString = level.text;
        string[] tiles = levelString.Split(new string[] { "\r\n", "\n", " " }, StringSplitOptions.None);
        for (int i = 0, n=0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++, n++)
            {
                try
                {
                    tileMap[i,j] = Int32.Parse(tiles[n]);
                }
                catch (FormatException e)
                {
                    tileMap[i,j] = (textureSize ^ 2) - 1;
                    Debug.LogWarning(e.ToString());
                    Debug.LogWarning(tiles[n]);
                }
            }
        }
    }

    public Vector2[] getTile(int x, int y)
    {
        return new Vector2[] { new Vector2((tileMap[x,y] % textureSize) * (1.0f / textureSize), 1 - ((tileMap[x,y] / textureSize) * 1.0f / textureSize)), new Vector2(((tileMap[x,y] % textureSize) * (1.0f / textureSize)) + (1.0f / textureSize), 1 - ((tileMap[x,y] / textureSize) * 1.0f / textureSize) - (1.0f / textureSize)) };
    }

    public int[,] getMap()
    {
        return tileMap;
    }
}
