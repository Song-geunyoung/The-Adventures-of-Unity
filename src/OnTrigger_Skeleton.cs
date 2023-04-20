using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnTrigger_Skeleton : MonoBehaviour {

    public Text Alrim;
    public Text Alrim_Background;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay()
    {
        Alrim.text = "싸움에 진입하시려면 \n마우스나 엔터를 누르세요...";
        Alrim_Background.text = "싸움에 진입하시려면 \n마우스나 엔터를 누르세요...";

        if (Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true || Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene(2);
    }

    void OnTriggerExit()
    {
        Alrim.text = "";
        Alrim_Background.text = "";
    }
}
