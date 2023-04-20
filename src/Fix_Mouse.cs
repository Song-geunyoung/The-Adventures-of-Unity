using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Screen.lockCursor = true;

        if (Input.GetKey(KeyCode.Escape))
            Screen.lockCursor = false;
    }
}
