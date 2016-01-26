using UnityEngine;
using System.Collections;

public class EntityMapScript : MonoBehaviour {
    private GameObject[,] entities;

    // Use this for initialization
    void Start() {
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

    public void removeObject(int x, int y)
    {
        entities[x, y] = null;
    }

    public GameObject getObject(int x, int y)
    {
        return entities[x, y]; 
    }
}
