using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTrigger_RaidiaTown : MonoBehaviour {

    public Text Alrim;
    public Text Alrim_Background;

    float CheckTime1;
    float Time_Std1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CheckTime1 <= Time_Std1)
            CheckTime1 += Time.deltaTime;

        if (CheckTime1 > Time_Std1)
        {
            Alrim.text = " ";
            Alrim_Background.text = " ";
        }
    }

    void OnTriggerEnter()
    {
        CheckTime1 = 0;
        Time_Std1 = 4;
        Alrim.text = "라이디아 마을";
        Alrim_Background.text = "라이디아 마을";
    }
}
    