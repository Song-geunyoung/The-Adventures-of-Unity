using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Motion_Rabbit : MonoBehaviour {

    public GameObject First;
    public GameObject Second;

    public Motion_BattleUnity UnityChanScript;

    GameObject Rabbit_Camera;
    GameObject Unity_Camera;

    public Animator RabbitAnimator;
    public Animator UnityAnimator;
    public Text HP;
    public Text Notice;

    public int Rabbit_Level;
    public float Rabbit_HP;
    public float Rabbit_EP;
    public float Rabbit_Gold;
    public int NormalAttack_Deal;

    int count = 0;

    // Use this for initialization
    void Start () {
        First.gameObject.SetActive(true);
        Second.gameObject.SetActive(true);

        Rabbit_Camera = GameObject.Find("Rabbit_Camera");
        Unity_Camera = GameObject.Find("Unity_Camera");

        Unity_Camera.GetComponent<Camera>().enabled = false;
        Rabbit_Camera.GetComponent<Camera>().enabled = true;

        RabbitAnimator = GetComponent<Animator>();
        Rabbit_Level = 1;
        Rabbit_HP = 20;
        Rabbit_EP = 15;
        Rabbit_Gold = 15;

        NormalAttack_Deal = 7;
    }
	
	// Update is called once per frame
	void Update () {
        HP_Manager(Rabbit_HP);
        Sign();
    }

    public void HP_Manager(float hp)
    {
        if (hp < 0)
            hp = 0;
        HP.text = "HP : " + ((Mathf.Round(hp * 10.0f))/10.0f).ToString();
    }

    public void Attack()
    {
        int Ran_Attack_Deal = Random.Range(0,3); // 추가 랜덤 딜
        if (Rabbit_HP > 0 && Motion_BattleUnity.Unity_HP > 0)
        {
            RabbitAnimator.Play("rabbit_attack");
            Motion_BattleUnity.Unity_HP -= (NormalAttack_Deal + Ran_Attack_Deal);
            Notice.text = "토끼가 공격했습니다.\n" + (NormalAttack_Deal + Ran_Attack_Deal) + "의 피해를 입었습니다.";
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
            Rabbit_Camera.GetComponent<Camera>().enabled = false;
            Unity_Camera.GetComponent<Camera>().enabled = true;
            UnityAnimator.Play("DamageDown");
            Notice.text = "유니티쨩이 죽었습니다.\n아무 키나 누르세요...";

            if (Input.anyKeyDown == true || Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (Rabbit_HP <= 0)
        {
            count++;
            if (count == 1)
            {
                Motion_BattleUnity.Unity_EP += Rabbit_EP;
                Motion_BattleUnity.Unity_Gold += Rabbit_Gold;
            }
            RabbitAnimator.Play("rabbit_die");
            Notice.text = "토끼가 죽었습니다.\n경험치 15와 골드 5를 얻었습니다.\n아무 키나 누르세요...";

            if (Input.anyKeyDown == true || Input.GetMouseButton(0) == true || Input.GetMouseButton(1) == true)
            {
                Motion_BattleUnity.Unity_HP = 50;
                SceneManager.LoadScene(1);
            }
        }
    }

    // 여기서부터 스킬 함수---------------------------------------------------------------------------


    public void Jab()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Rabbit_HP > 0 && evade_Rate > 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true)
        {
            RabbitAnimator.Play("rabbit_damage");
            Rabbit_HP -= UnityChanScript.Jab_Deal;
            Notice.text = UnityChanScript.Jab_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
        }
        else if (Rabbit_HP > 0 && evade_Rate <= 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true)
        {
            Notice.text = "토끼가 잽을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void Hikick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Rabbit_HP > 0 && evade_Rate > 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 20)
        {
            RabbitAnimator.Play("rabbit_damage");
            Rabbit_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 20;
        }
        else if (Rabbit_HP > 0 && evade_Rate <= 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 20)
        {
            Notice.text = "토끼가 하이킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 20;
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 20)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void Rising_Punch()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Rabbit_HP > 0 && evade_Rate > 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 25)
        {
            RabbitAnimator.Play("rabbit_damage");
            Rabbit_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 25;
        }
        else if (Rabbit_HP > 0 && evade_Rate <= 20 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 25)
        {
            Notice.text = "토끼가 스크류펀치를 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 25;
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 25)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void SpinKick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Rabbit_HP > 0 && evade_Rate > 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 30)
        {
            RabbitAnimator.Play("damage");
            Rabbit_HP -= UnityChanScript.Hikick_Deal;
            Notice.text = UnityChanScript.Hikick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 30;
        }
        else if (Rabbit_HP > 0 && evade_Rate <= 15 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 30)
        {
            Notice.text = "토끼가 스핀킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 30;
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 30)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }

    public void ScrewKick()
    {
        int evade_Rate = Random.Range(1, 101); // 회피율

        if (Rabbit_HP > 0 && evade_Rate > 3 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 60)
        {
            RabbitAnimator.Play("rabbit_damage");
            Rabbit_HP -= UnityChanScript.ScrewKick_Deal;
            Notice.text = UnityChanScript.ScrewKick_Deal + "의 피해를 입혔습니다.";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 60;
        }
        else if (Rabbit_HP > 0 && evade_Rate <= 3 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP >= 60)
        {
            Notice.text = "토끼가 스크류킥을 회피하였습니다!";
            UnityChanScript.UnityTurn = false;
            UnityChanScript.SkillYesOrNo = false;
            Motion_BattleUnity.Unity_MP -= 60;
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == true && UnityChanScript.SkillYesOrNo == true && Motion_BattleUnity.Unity_MP < 60)
        {
            Notice.text = "MP가 부족합니다!!";
        }
        else if (Rabbit_HP > 0 && UnityChanScript.UnityTurn == false && UnityChanScript.SkillYesOrNo == false)
        {
            Notice.text = "이미 공격을 하셨습니다!";
        }
    }
}
