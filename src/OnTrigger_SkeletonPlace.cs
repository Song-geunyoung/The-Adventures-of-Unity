using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTrigger_SkeletonPlace : MonoBehaviour
{
    public Animator SkeletonAnimator;
    public Text Alrim;
    public Text Alrim_Background;

    float CheckTime;
    float Time_Std;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CheckTime <= Time_Std)
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
        Time_Std = 2;
        Alrim.text = "위험 !! 스켈레톤 출몰지역";
        Alrim_Background.text = "위험 !! 스켈레톤 출몰지역";
    }
}
