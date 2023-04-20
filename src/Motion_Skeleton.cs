using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Motion_Skeleton : MonoBehaviour
{
    public Motion_BattleUnity UnityChanScript;
    public GameObject Button_Background;
    public GameObject Monster_Background;

    GameObject Skeleton_Camera;
    GameObject Unity_Camera;

    // 필요한 컴퍼넌트
    public Animator SkeletonAnimator;
    public Animator UnityAnimator;
    public Text HP;
    public Text Notice;

    // 스켈레톤 정보
    public int Skeleton_Level;
    public float Skel_HP;
    public float Skeleton_EP;
    public float Skel_Gold;
    public int SwingQuick;
    public int SwingNormal;
    public int SwingHeavy;

    int count = 0;

    // Use this for initialization
    void Start()
    {
        Button_Background.gameObject.SetActive(true);
        Monster_Background.gameObject.SetActive(true);
        Skeleton_Camera = GameObject.Find("Skeleton_Camera");
        Unity_Camera = GameObject.Find("Unity_Camera");

        Unity_Camera.GetComponent<Camera>().enabled = false;
        Skeleton_Camera.GetComponent<Camera>().enabled = true;

        SkeletonAnimator = GetComponent<Animator>();
        Skeleton_Level = 10;
        Skel_HP = 500;
        Skeleton_EP = 1500;
        Skel_Gold = 500;

        SwingQuick = 50;
        SwingNormal = 90;
        SwingHeavy = 180;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Manager(Skel_HP);
        Sign();

        if (Skel_HP < 200)
        {
            Notice.text = "스켈레톤이 각성했습니다!! \n이제 스켈레톤이 더 강력한 \n 공격을 합니다.";
        }
    }

    public void HP_Manager(float hp)
    {
        if (hp < 0)
            hp = 0;
        HP.text = "HP : " + ((Mathf.Round(hp * 10.0f)) / 10.0f).ToString();
    }

    public void Attack()
    {
        int Attack_Rate = Random.Range(1, 101);
        int Attack_Ran_Deal = Random.Range(1, 30);

        if (Skel_HP > 200 && Motion_BattleUnity.Unity_HP > 0)
        {
            if (Attack_Rate > 40 && Motion_BattleUnity.Unity_HP > 0)
            {
                SkeletonAnimator.Play("SwingQuick");
                Motion_BattleUnity.Unity_HP -= SwingQuick;
                Notice.text = "스켈레톤이 팔을 약하게 휘둘렀습니다.\n" + SwingQuick + "의 피해를 입었습니다.";
                UnityChanScript.UnityTurn = true;
                UnityChanScript.SkillYesOrNo = true;
            }

            else if (Attack_Rate < 40 && Motion_BattleUnity.Unity_HP > 0)
            {
                SkeletonAnimator.Play("SwingNormal");
                Motion_BattleUnity.Unity_HP -= SwingNormal;
                Notice.text = "스켈레톤이 힘을 주어 휘둘렀습니다!!\n" + SwingNormal + "의 피해를 입었습니다.";
                UnityChanScript.UnityTurn = true;
                UnityChanScript.SkillYesOrNo = true;
            }
        }

        else if (Skel_HP <= 200 && Motion_BattleUnity.Unity_HP > 0)
        {
            if (Attack_Rate > 30)
            {
                SkeletonAnimator.Play("SwingHeavy");
                Motion_BattleUnity.Unity_HP -= SwingHeavy;
                Notice.text = "스켈레톤이 미쳐 날뜁니다!!" + SwingHeavy + "의 피해를 입었습니다.";
                UnityChanScript.UnityTurn = true;
                UnityChanScript.SkillYesOrNo = true;
            }
            else if (Attack_Rate < 30)
            {
                SkeletonAnimator.Play("SwingNormal");
                Motion_BattleUnity.Unity_HP -= SwingNormal;
                Notice.text = "스켈레톤이 강하게 휘둘렀습니다!!" + SwingNormal + "의 피해를 입었습니다.";
                UnityChanScript.UnityTurn = true;
                UnityChanScript.SkillYesOrNo = true;
            }
        }
    }

    public void Sign()
    {
        Notice.text = Notice.text;
        if (Motion_BattleUnity.Unity_HP <= 0)
        {
            count++;
            if (count == 1)
            {
                Motion_BattleUnity.Unity_EP *= (1 / 2);
            }
            Button_Background.gameObject.SetActive(false);
            Monster_Background.gameObject.SetActive(false);
            Skeleton_Camera.GetComponent<Camera>().enabled = false;
            Unity_Camera.GetComponent<Camera>().enabled = true;
            UnityAnimator.Play("DamageDown");
            Notice.text = "유니티쨩이 죽었습니다.\n아무키나 누르세요...";
            if (Input.anyKeyDown == true || Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
            {
                Motion_BattleUnity.Unity_HP = 50;
                SceneManager.LoadScene(1);
            }
        }

        if (Skel_HP <= 0)
        {
            count++;
            if (count == 1)
            {
                Motion_BattleUnity.Unity_EP += Skeleton_EP;
                Motion_BattleUnity.Unity_Gold += Skel_Gold;
            }
            SkeletonAnimator.Play("Death");
            Notice.text = "스켈레톤이 죽었습니다. \n경험치 1500과 골드 1000을\n획득하였습니다.\n아무 키나 누르세요...";
            if (Input.anyKeyDown == true || Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    // 여기서부터 스킬 함수


    public void Jab()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Skel_HP > 0 && evade_Rate > 40 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true) // 스켈레톤 체력이 0이 넘고, 회피율이 70퍼 이상이며, 유니티턴/스킬유무가 예스일때 가능
        {
            SkeletonAnimator.Play("Hit");
            Skel_HP -= UnityChanScript.Jab_Deal;
            Notice.text = UnityChanScript.Jab_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
        }
        else if (Skel_HP > 0 && evade_Rate <= 40 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true)
        {
            SkeletonAnimator.Play("Jump");
            Notice.text = "스켈레톤이 잽을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void Hikick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Skel_HP > 0 && evade_Rate > 30 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 20)
        {
            SkeletonAnimator.Play("Hit2");
            Skel_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 20;
        }
        else if (Skel_HP > 0 && evade_Rate <= 30 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 20)
        {
            SkeletonAnimator.Play("Jump");
            Notice.text = "스켈레톤이 하이킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 20;
        }
        else if(Skel_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 20)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void Rising_Punch()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Skel_HP > 0 && evade_Rate > 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 25)
        {
            SkeletonAnimator.Play("Hit2");
            Skel_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 25;
        }
        else if (Skel_HP > 0 && evade_Rate <= 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 25)
        {
            SkeletonAnimator.Play("Jump");
            Notice.text = "스켈레톤이 스크류펀치를 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 25;
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 25)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void SpinKick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Skel_HP > 0 && evade_Rate > 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 30)
        {
            SkeletonAnimator.Play("Hit2");
            Skel_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 30;
        }
        else if (Skel_HP > 0 && evade_Rate <= 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 30)
        {
            SkeletonAnimator.Play("Jump");
            Notice.text = "스켈레톤이 스핀킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 30;
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 30)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void ScrewKick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Skel_HP > 0 && evade_Rate > 3 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 60)
        {
            SkeletonAnimator.Play("Hit2");
            Skel_HP -= UnityChanScript.ScrewKick_Deal;
            Notice.text = UnityChanScript.ScrewKick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 60;
        }
        else if (Skel_HP > 0 && evade_Rate <= 3 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 60)
        {
            SkeletonAnimator.Play("Jump");
            Notice.text = "스켈레톤이 스크류킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 60;
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 60)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Skel_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }
}