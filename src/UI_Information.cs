using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Information : MonoBehaviour
{
    public Motion_BattleUnity UnityChanScript;
   
    public Text GOLD;
    public Text EP;
    public Text LV;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        GOLD.text = "Gold : " + Motion_BattleUnity.Unity_Gold.ToString();
        EP.text = "경험치 : " + Motion_BattleUnity.Unity_EP.ToString();
        LV.text = "LV. 0" + Motion_BattleUnity.Unity_Level.ToString();

    }
}
