using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Motion_BattleUnity : MonoBehaviour {

    // 필요한 컴퍼넌트
    public Animator Song;
    public Text HP;
    public Text Unity_LV;
    public Text Unity_Mana;

    public Text SmallHPQ;
    public Text NormalHPQ;
    public Text BigHPQ;
    public Text SmallMPQ;
    public Text NormalMPQ;
    public Text BigMPQ;

    public bool UnityTurn; // 유니티쨩의 턴인가?
    public bool SkillYesOrNo; // 유니티쨩이 스킬 사용 가능한가?
    public bool Check = true;
    public static bool Check2 = true;

    public static int PrevLV = 1;
    public static int CurrLV = 1;


    // 유니티쨩 정보
    public static int Unity_Level = 1; // 레벨
    public static int Unity_HP = 100; // 체력
    public static int Unity_MP = 30; // 마나
    public float Unity_Level_Deal; // 레벨에 따른 딜량 가중치
    public static float Unity_EP = 0; // 경험치
    public static int Unity_Inventory = 3; // 유니티 인벤토리
    public static float Unity_Gold = 150; // 골드

    public static int MaxHP = 100;
    public static int MaxMP = 30;

    public static int SmallHP = 0;
    public static int NormalHP = 0;
    public static int BigHP = 0;
    public static int SmallMP = 0;
    public static int NormalMP = 0;
    public static int BigMP = 0;
    

    public float Jab_Deal;
    public float Hikick_Deal;
    public float ScrewKick_Deal;
    public float SpinKick_Deal;
    public float Rising_Punch_Deal;

    public float Jab_RanDeal;
    public float Hikick_RanDeal;
    public float ScrewKick_RanDeal;
    public float SpinKick_RanDeal;
    public float Rising_Punch_RanDeal;

    // Use this for initialization
    void Start ()
    {
        Check2 = true;
        Unity_Level_Deal = 1;

        Song = GetComponent<Animator>();

        UnityTurn = true;
        SkillYesOrNo = true;

        LevelUpCheck(Unity_EP, ref CurrLV);

        if (Unity_Level != CurrLV)
            Check = false;

        if (Check == false)
        {       
            Unity_Level = CurrLV;
            LevelUp(ref CurrLV);
            Check = true;
            Check2 = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        SmallHPQ.text = "x" + SmallHP.ToString();
        NormalHPQ.text = "x" + NormalHP.ToString();
        BigHPQ.text = "x" + BigHP.ToString();
        SmallMPQ.text = "x" + SmallMP.ToString();
        NormalMPQ.text = "x" + NormalHP.ToString();
        BigMPQ.text = "x" + BigMP.ToString();

        HP_Manager(Unity_HP);
        MP_Manager(Unity_MP);
        LV_Manager(Unity_Level);
    }

    //레벨업에 따른 변화
    public void LevelUpCheck(float ep, ref int LV)
    {
        if (0 <= ep && ep < 20)
            LV = 1;
        else if (20 <= ep && ep < 50)
            LV = 2;
        else if (50 <= ep && ep < 100)
            LV = 3;
        else if (100 <= ep && ep < 180)
            LV = 4;
        else if (180 <= ep && ep < 300)
            LV = 5;
        else if (300 <= ep && ep < 500)
            LV = 6;
        else if (500 <= ep && ep < 800)
            LV = 7;
        else if (800 <= ep && ep < 1300)
            LV = 8;
        else if (1300 <= ep && ep < 2000)
            LV = 9;
        else if (2000 <= ep && ep < 3000)
            LV = 10;
    }

    public void LevelUp(ref int level)
    {
        if (level == 1)
        {
            Unity_HP = 100;
            Unity_MP = 30;
            Unity_Level_Deal = 1;

            MaxHP = 100;
            MaxMP = 30;
        }
        if (level == 2)
        {
            Unity_HP = 110;
            Unity_MP = 50;
            Unity_Level_Deal = 1.1f;

            MaxHP = 110;
            MaxMP = 40;
        }
        if (level == 3)
        {
            Unity_HP = 120;
            Unity_MP = 70;
            Unity_Level_Deal = 1.3f;

            MaxHP = 120;
            MaxMP = 50;
        }
        if (level == 4)
        {
            Unity_HP = 130;
            Unity_MP = 90;
            Unity_Level_Deal = 1.55f;

            MaxHP = 130;
            MaxMP = 60;
        }
        if (level == 5)
        {
            Unity_HP = 145;
            Unity_MP = 110;
            Unity_Level_Deal = 1.8f;

            MaxHP = 145;
            MaxMP = 70;
        }
        if (level == 6)
        {
            Unity_HP = 170;
            Unity_MP = 130;
            Unity_Level_Deal = 2.0f;

            MaxHP = 170;
            MaxMP = 80;
        }
        if (level == 7)
        {
            Unity_HP = 190;
            Unity_MP = 150;
            Unity_Level_Deal = 2.3f;

            MaxHP = 190;
            MaxMP = 90;
        }
        if (level == 8)
        {
            Unity_HP = 220;
            Unity_MP = 160;
            Unity_Level_Deal = 2.6f;

            MaxHP = 220;
            MaxMP = 100;
        }
        if (level == 9)
        {
            Unity_HP = 250;
            Unity_MP = 170;
            Unity_Level_Deal = 3.1f;

            MaxHP = 250;
            MaxMP = 110;
        }
        if (level == 10)
        {
            Unity_HP = 300;
            Unity_MP = 180;
            Unity_Level_Deal = 3.5f;

            MaxHP = 300;
            MaxMP = 120;
        }
        if (level == 11)
        {
            Unity_HP = 350;
            Unity_MP = 200;
            Unity_Level_Deal = 4.0f;

            MaxHP = 350;
            MaxMP = 130;
        }
    }

    public void HP_Manager(float hp)
    {
        if (hp < 0)
            hp = 0;
        HP.text = "HP : " + hp.ToString() + "/" + MaxHP;
    }

    public void MP_Manager(float mp)
    {
        Unity_Mana.text = "MP : " + mp.ToString() + "/" + MaxMP;
    }
    
    public void LV_Manager(float LV)
    {
        if (Unity_Level < 10)
            Unity_LV.text = "LV. 0" + LV.ToString();
        else if (Unity_Level >= 10)
            Unity_LV.text = "LV. " + LV.ToString();
    }


    //--------포션 사용하기 함수--------
    public void Use_HP_Small()
    {
        if (SmallHP > 0)
        {
            SmallHP -= 1;
            Unity_HP += 50;
            if (Unity_HP > MaxHP)
                Unity_HP = MaxHP;
        }
    }

    public void Use_HP_Normal()
    {
        if (NormalHP > 0)
        {
            NormalHP -= 1;
            Unity_HP += 100;
            if (Unity_HP > MaxHP)
                Unity_HP = MaxHP;
        }
    }
    public void Use_HP_Big()
    {
        if (BigHP > 0)
        {
            BigHP -= 1;
            Unity_HP += 200;
            if (Unity_HP > MaxHP)
                Unity_HP = MaxHP;
        }
    }
    public void Use_MP_Small()
    {
        if (SmallMP > 0)
        {
            SmallMP -= 1;
            Unity_MP += 10;
            if (Unity_MP > MaxMP)
                Unity_MP = MaxMP;
        }
    }
    public void Use_MP_Normal()
    {
        if (NormalMP > 0)
        {
            NormalMP -= 1;
            Unity_MP += 20;
            if (Unity_MP > MaxMP)
                Unity_MP = MaxMP;
        }
    }
    public void Use_MP_Big()
    {
        if (BigMP > 0)
        {
            BigMP -= 1;
            Unity_MP += 50;
            if (Unity_MP > MaxMP)
                Unity_MP = MaxMP;
        }
    }


    // ------------------스킬함수-------------------------------

    public void Jab()
    {
        Jab_RanDeal = Random.Range(1, 3);
        Jab_Deal = 3 * Unity_Level_Deal + Jab_RanDeal * Unity_Level_Deal;

        if (UnityTurn == true && SkillYesOrNo == true)
        {
            Song.Play("Jab");
        }
    }

    public void Hikick()
    {
        Hikick_RanDeal = Random.Range(1, 4);
        Hikick_Deal = 5 * Unity_Level_Deal + Hikick_RanDeal * Unity_Level_Deal;

        if (UnityTurn == true && SkillYesOrNo == true && Unity_MP >= 20)
        {
            Song.Play("Hikick");
        }
    }

    public void Rising_Punch()
    {
        Rising_Punch_RanDeal = Random.Range(1, 25);
        Rising_Punch_Deal = 2 * Unity_Level_Deal + Rising_Punch_RanDeal * Unity_Level_Deal;

        if (UnityTurn == true && SkillYesOrNo == true && Unity_MP >= 25)
        {
            Song.Play("Rising_Punch");
        }
    }

    public void SpinKick()
    {
        SpinKick_RanDeal = Random.Range(1, 6);
        SpinKick_Deal = 7 * Unity_Level_Deal + SpinKick_RanDeal * Unity_Level_Deal;

        if (UnityTurn == true && SkillYesOrNo == true && Unity_MP >= 30)
        {
            Song.Play("SpinKick");
        }
    }

    public void ScrewKick()
    {
        ScrewKick_RanDeal = Random.Range(1, 5);
        ScrewKick_Deal = 15 * Unity_Level_Deal + ScrewKick_RanDeal * Unity_Level_Deal;

        if (UnityTurn == true && SkillYesOrNo == true && Unity_MP >= 60)
        {
            Song.Play("TurnKick" +
                "");
        }
    }
}
