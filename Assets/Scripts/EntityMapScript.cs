using UnityEngine;
using System.Collections;

public class EntityMapScript : MonoBehaviour {
    private GameObject[,] entities;

    // Use this for initialization
    void Awake() {
        TileSheetScript map = GetComponent<TileSheetScript>();
        entities = new GameObject[map.xSize, map.ySize];
    }

    public void addObject(GameObject inputObject, int x, int y)
    {
        if (entities[x, y] == null)
        {
            entities[x, y] = inputObject;
        }
        else
        {
            throw new System.Exception("Object already exists in location");
        }
    }

    public GameObject removeObject(int x, int y)
    {
        GameObject result = entities[x,y];
        entities[x, y] = null;
        return result;
    }

    public void moveObject(int x, int y, int newX, int newY)
    {
        if (entities[newX, newY] == null)
        {
            entities[newX, newY] = entities[x,y];
            entities[x, y] = null;
        }
        else
        {
            throw new System.Exception("Object already exists in location");
        }
    }

    public GameObject getObject(int x, int y)
    {
        return entities[x, y]; 
    }
}
