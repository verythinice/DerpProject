using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntityUIScript : MonoBehaviour {
    private CursorScript cursor;
    private Text text;

    // Use this for initialization
    void Start()
    {
        cursor = GameObject.Find("Cursor").GetComponent<CursorScript>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject character = cursor.getCursorCharacter();
        if (character!= null)
        {
            text.text = character.name;
        }
        else
        {
            text.text = "";
        }
    }
}
