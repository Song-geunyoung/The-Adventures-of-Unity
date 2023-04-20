using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTrriger_Rabbit : MonoBehaviour {

    int RandomCheck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        RandomCheck = Random.Range(1, 101);

        if (1 <= Motion_BattleUnity.Unity_Level && Motion_BattleUnity.Unity_Level < 2)
        {
            if (RandomCheck > 20)
                SceneManager.LoadScene(3);
            else if (RandomCheck <= 20)
                SceneManager.LoadScene(4);
        }
        else if (2 <= Motion_BattleUnity.Unity_Level && Motion_BattleUnity.Unity_Level < 4)
        {
            if (0 < RandomCheck && RandomCheck <= 20)
                SceneManager.LoadScene(3);
            else if (20 <= RandomCheck && RandomCheck < 80)
                SceneManager.LoadScene(4);
            else if (80 <= RandomCheck && RandomCheck <= 100)
                SceneManager.LoadScene(5);
        }
        else if (4 <= Motion_BattleUnity.Unity_Level && Motion_BattleUnity.Unity_Level < 6)
        {
            if (0 < RandomCheck && RandomCheck <= 20)
                SceneManager.LoadScene(3);
            else if (20 <= RandomCheck && RandomCheck < 65)
                SceneManager.LoadScene(4);
            else if (65 <= RandomCheck && RandomCheck <= 100)
                SceneManager.LoadScene(5);
        }
        else if (6 <= Motion_BattleUnity.Unity_Level)
        {
            if (0 < RandomCheck && RandomCheck <= 20)
                SceneManager.LoadScene(3);
            else if (20 <= RandomCheck && RandomCheck < 50)
                SceneManager.LoadScene(4);
            else if (50 <= RandomCheck && RandomCheck <= 100)
                SceneManager.LoadScene(5);
        }
    }
}