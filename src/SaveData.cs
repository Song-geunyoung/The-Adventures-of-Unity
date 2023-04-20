using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour {

    public Text Potion_txt;
    public Text PotionBackground_txt;

    float CheckTime;
    float Time_Std;

    void Update()
    {
        if (CheckTime <= Time_Std)
            CheckTime += Time.deltaTime;

        if (CheckTime > Time_Std)
        {
            Potion_txt.text = "";
            PotionBackground_txt.text = "";
        }
    }


    //----------포션 구매하기 함수----------

    public void HP_Small()
    {
        CheckTime = 0;
        Time_Std = 0.5f;
        if (Motion_BattleUnity.Unity_Gold >= 5)
        {
            Motion_BattleUnity.SmallHP += 1;
            Motion_BattleUnity.Unity_Gold -= 5;
            Potion_txt.text = "구매를 완료했습니다.";
            PotionBackground_txt.text = "구매를 완료했습니다.";
        }
        else if (Motion_BattleUnity.Unity_Gold < 5)
        {
            Potion_txt.text = "돈이 부족합니다.";
            PotionBackground_txt.text = "돈이 부족합니다.";
        }
    }
    public void HP_Normal()
    {
        CheckTime = 0;
        Time_Std = 0.5f;
        if (Motion_BattleUnity.Unity_Gold >= 12)
        {
            Motion_BattleUnity.NormalMP += 1;
            Motion_BattleUnity.Unity_Gold -= 12;
            Potion_txt.text = "구매를 완료했습니다.";
            PotionBackground_txt.text = "구매를 완료했습니다.";
        }
        else if (Motion_BattleUnity.Unity_Gold < 12)
        {
            Potion_txt.text = "돈이 부족합니다.";
            PotionBackground_txt.text = "돈이 부족합니다.";
        }
    }
    public void HP_Big()
    {
        CheckTime = 0;
        Time_Std = 0.5f;
        if (Motion_BattleUnity.Unity_Gold >= 23)
        {
            Motion_BattleUnity.BigHP += 1;
            Motion_BattleUnity.Unity_Gold -= 23;
            Potion_txt.text = "구매를 완료했습니다.";
            PotionBackground_txt.text = "구매를 완료했습니다.";
        }
        else if (Motion_BattleUnity.Unity_Gold < 23)
        {
            Potion_txt.text = "돈이 부족합니다.";
            PotionBackground_txt.text = "돈이 부족합니다.";
        }
    }
    public void MP_Small()
    {
        CheckTime = 0;
        Time_Std = 0.5f;
        if (Motion_BattleUnity.Unity_Gold >= 5)
        {
            Motion_BattleUnity.SmallMP += 1;
            Motion_BattleUnity.Unity_Gold -= 5;
            Potion_txt.text = "구매를 완료했습니다.";
            PotionBackground_txt.text = "구매를 완료했습니다.";
        }
        else if (Motion_BattleUnity.Unity_Gold < 5)
        {
            Potion_txt.text = "돈이 부족합니다.";
            PotionBackground_txt.text = "돈이 부족합니다.";
        }
    }
    public void MP_Normal()
    {
        CheckTime = 0;
        Time_Std = 0.5f;
        if (Motion_BattleUnity.Unity_Gold >= 12)
        {
            Motion_BattleUnity.NormalMP += 1;
            Motion_BattleUnity.Unity_Gold -= 12;
            Potion_txt.text = "구매를 완료했습니다.";
            PotionBackground_txt.text = "구매를 완료했습니다.";
        }
        else if (Motion_BattleUnity.Unity_Gold < 12)
        {
            Potion_txt.text = "돈이 부족합니다.";
            PotionBackground_txt.text = "돈이 부족합니다.";
        }
    }
    public void MP_Big()
    {
        CheckTime = 0;
        Time_Std = 0.5f;
        if (Motion_BattleUnity.Unity_Gold >= 30)
        {
            Motion_BattleUnity.BigMP += 1;
            Motion_BattleUnity.Unity_Gold -= 30;
            Potion_txt.text = "구매를 완료했습니다.";
            PotionBackground_txt.text = "구매를 완료했습니다.";
        }
        else if (Motion_BattleUnity.Unity_Gold < 30)
        {
            Potion_txt.text = "돈이 부족합니다.";
            PotionBackground_txt.text = "돈이 부족합니다.";
        }
    }   
}