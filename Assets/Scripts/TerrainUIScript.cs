using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TerrainUIScript : MonoBehaviour {
    private CursorScript cursor;
    private Text text;

	// Use this for initialization
	void Start () {
        cursor = GameObject.Find("Cursor").GetComponent<CursorScript>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = cursor.getCursorTerrain().name;
	}
}
