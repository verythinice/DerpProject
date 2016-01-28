using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
    private int x;
    private int y;
    private bool verticalDown;
    private bool horizontalDown;
    private TerrainScript terrain;
    private EntityMapScript entities;
    private string state;

	// Use this for initialization
	void Start () {
        //x 0 at origin, more positive to the right
        x = 0;
        //y 0 at origin, more positive down
        y = 0;
        horizontalDown = false;
        verticalDown = false;
        GameObject map = GameObject.Find("Map");
        terrain = map.GetComponent<TerrainScript>();
        entities = map.GetComponent<EntityMapScript>();
        state = "default";
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0)
        {
            if (!verticalDown)
            {
                verticalDown = true;
                if (vertical > 0)
                {
                    y -= 1;
                }
                else if (vertical < 0)
                {
                    y += 1;
                }
            }
        }
        else
        {
            verticalDown = false;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            if (!horizontalDown)
            {
                horizontalDown = true;
                if (horizontal > 0)
                {
                    x += 1;
                }
                else if (horizontal < 0)
                {
                    x -= 1;
                }
            }
        }
        else
        {
            horizontalDown = false;
        }
        transform.position = new Vector2(x + 0.5f, -(y + 0.5f));
        //print(terrain.getTile(x, y));
	}
}
