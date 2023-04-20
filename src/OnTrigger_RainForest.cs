using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTrigger_RainForest : MonoBehaviour {

    public Text Alrim;
    public Text Alrim_Background;

    float CheckTime;
    float Time_Std;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(CheckTime <= Time_Std)
            CheckTime += Time.deltaTime;

        if (CheckTime > Time_Std)
        {
            Alrim.text = " ";
            Alrim_Background.text = " ";
        }
	}

    void OnTriggerEnter()
    {
        CheckTime = 0;
        Time_Std = 4;
        Alrim.text = "하급몬스터 출몰지역";
        Alrim_Background.text = "하급몬스터 출몰지역";
    }
}
