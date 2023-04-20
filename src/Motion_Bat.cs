using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Motion_Bat : MonoBehaviour
{

    public GameObject First;
    public GameObject Second;

    public Motion_BattleUnity UnityChanScript;

    GameObject bat_Camera;
    GameObject Unity_Camera;

    public Animator batAnimator;
    public Animator UnityAnimator;
    public Text HP;
    public Text Notice;

    public int bat_Level;
    public float bat_HP;
    public float bat_EP;
    public float bat_Gold;
    public int NormalAttack_Deal;

    int count = 0;

    // Use this for initialization
    void Start()
    {
        First.gameObject.SetActive(true);
        Second.gameObject.SetActive(true);

        bat_Camera = GameObject.Find("Bat_Camera");
        Unity_Camera = GameObject.Find("Unity_Camera");

        Unity_Camera.GetComponent<Camera>().enabled = false;
        bat_Camera.GetComponent<Camera>().enabled = true;

        batAnimator = GetComponent<Animator>();
        bat_Level = 3;
        bat_HP = 40;
        bat_EP = 25;
        bat_Gold = 30;

        NormalAttack_Deal = 7;
    }

    // Update is called once per frame
    void Update()
    {
        HP_Manager(bat_HP);
        Sign();
    }

    public void HP_Manager(float hp)
    {
        if (hp < 0)
            hp = 0;
        HP.text = "HP : " + ((Mathf.Round(hp * 10.0f)) / 10.0f).ToString();
    }

    public void Attack()
    {
        int Ran_Attack_Deal = Random.Range(0, 3); // 추가 랜덤 딜
        if (bat_HP > 0 && Motion_BattleUnity.Unity_HP > 0)
        {
            batAnimator.Play("bat_attack");
            Motion_BattleUnity.Unity_HP -= (NormalAttack_Deal + Ran_Attack_Deal);
            Notice.text = "박쥐가 공격했습니다.\n" + (NormalAttack_Deal + Ran_Attack_Deal) + "의 피해를 입었습니다.";
            UnityChanScript.UnityTurn = true;
            UnityChanScript.SkillYesOrNo = true;
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
            First.gameObject.SetActive(false);
            Second.gameObject.SetActive(false);
            bat_Camera.GetComponent<Camera>().enabled = false;
            Unity_Camera.GetComponent<Camera>().enabled = true;
            UnityAnimator.Play("DamageDown");
            Notice.text = "유니티쨩이 죽었습니다.\n아무 키나 누르세요...";

            if (Input.anyKeyDown == true || Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
            {
                Motion_BattleUnity.Unity_HP = 50;
                SceneManager.LoadScene(1);
            }
        }

        if (bat_HP <= 0)
        {
            count++;
            if (count == 1)
            {
                Motion_BattleUnity.Unity_EP += bat_EP;
                Motion_BattleUnity.Unity_Gold += bat_Gold;
            }
            batAnimator.Play("bat_die");
            Notice.text = "박쥐가 죽었습니다.\n경험치 25와 골드 10를 얻었습니다.\n아무 키나 누르세요...";

            if (Input.anyKeyDown == true || Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    // 여기서부터 스킬 함수---------------------------------------------------------------------------


    public void Jab()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (bat_HP > 0 && evade_Rate > 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true)
        {
            batAnimator.Play("bat_damage");
            bat_HP -= UnityChanScript.Jab_Deal;
            Notice.text = UnityChanScript.Jab_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
        }
        else if (bat_HP > 0 && evade_Rate <= 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true)
        {
            Notice.text = "박쥐가 잽을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void Hikick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (bat_HP > 0 && evade_Rate > 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 20)
        {
            batAnimator.Play("bat_damage");
            bat_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 20;
        }
        else if (bat_HP > 0 && evade_Rate <= 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 20)
        {
            Notice.text = "박쥐가 하이킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 20;
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 20)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void Rising_Punch()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (bat_HP > 0 && evade_Rate > 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 25)
        {
            batAnimator.Play("bat_damage");
            bat_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 25;
        }
        else if (bat_HP > 0 && evade_Rate <= 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 25)
        {
            Notice.text = "박쥐가 스크류펀치를 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 25;
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 25)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void SpinKick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (bat_HP > 0 && evade_Rate > 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 30)
        {
            batAnimator.Play("damage");
            bat_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 30;
        }
        else if (bat_HP > 0 && evade_Rate <= 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 30)
        {
            Notice.text = "박쥐가 스핀킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 30;
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 30)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void ScrewKick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (bat_HP > 0 && evade_Rate > 3 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 60)
        {
            batAnimator.Play("bat_damage");
            bat_HP -= UnityChanScript.ScrewKick_Deal;
            Notice.text = UnityChanScript.ScrewKick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 60;
        }
        else if (bat_HP > 0 && evade_Rate <= 3 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 60)
        {
            Notice.text = "박쥐가 스크류킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 60;
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 60)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (bat_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }
}
