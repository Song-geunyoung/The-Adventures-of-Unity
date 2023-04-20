using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnTrigger_Dealer : MonoBehaviour
{
    public GameObject potionUI;

    public Text Alrim4;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay()
    {
        Alrim4.text = "상점에 진입하시려면\n엔터를 누르세요...";

        if (Input.GetKey(KeyCode.Return) == true)
        {
            potionUI.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit()
    {
        Alrim4.text = "";
    }

    public void PotionExit()
    {
        potionUI.gameObject.SetActive(false);
        Alrim4.text = "상점에 진입하시려면\n엔터를 누르세요...";
    }

}
