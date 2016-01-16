using UnityEngine;
using System.Collections;
using System;

public class TileSheetScript : MonoBehaviour
{
    public int xSize;
    public int ySize;
    public int textureSize;
    public TextAsset level;
    private int[] tileMap;

    // Use this for initialization
    void Awake()
    {
        tileMap = new int[xSize * ySize];
        string levelString = level.text;
        string[] tiles = levelString.Split(new string[] { "\r\n", "\n", " " }, StringSplitOptions.None);
        for (int i = 0; i < tileMap.Length; i++)
        {
            try {
                tileMap[i] = Int32.Parse(tiles[i]);
            }
            catch (FormatException e)
            {
                tileMap[i] = (textureSize^2)-1;
                Debug.LogWarning(e.ToString());
                Debug.LogWarning(tiles[i]);
            }
        }
    }

    public Vector2[] getTile(int tileNum)
    {
        return new Vector2[] {new Vector2((tileMap[tileNum]%textureSize)*(1.0f / textureSize), 1-((tileMap[tileNum]/textureSize)*1.0f/textureSize)), new Vector2(((tileMap[tileNum] % textureSize)*(1.0f/textureSize))+(1.0f/textureSize), 1 - ((tileMap[tileNum] / textureSize) * 1.0f / textureSize)- (1.0f / textureSize)) };
    }
}
