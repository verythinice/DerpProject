using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public int movement { get; private set; }
    public int x { get; private set; }
    public int y { get; private set; }
    public string entityName { get; private set; }
    private TerrainScript terrain;
    private EntityMapScript entities;

    // Use this for initialization
    void Start () {
        movement = 2;
        x = 1;
        y = 1;
        name = "Derp";
        GameObject map = GameObject.Find("Map");
        terrain = map.GetComponent<TerrainScript>();
        entities = map.GetComponent<EntityMapScript>();
        entities.addObject(gameObject, x, y);
    }
	
    public void move(int newX, int newY)
    {
        //TODO: make animations and stuff
        //Right now it just moves instantly
        x = newX;
        y = newY;
        entities.moveObject(x, y, newX, newY);
    }

	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(x + 0.5f, -(y + 0.5f));
    }
}
