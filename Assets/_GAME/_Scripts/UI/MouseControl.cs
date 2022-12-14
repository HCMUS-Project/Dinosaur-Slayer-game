using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour {

    public static MouseControl instance;
    public        Texture2D defaultCursor, clickableCursor;


    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }


    private void Start() {
        Default();
    }


    public void Clickable() {
        Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.Auto);
    }

    public void Default() {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

}
