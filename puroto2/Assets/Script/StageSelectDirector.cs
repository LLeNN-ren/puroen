using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectDirector : MonoBehaviour
{
    public static bool[] ClearStageMark;
    public GameObject Stages;
    public GameObject[] Stage = new GameObject[2];
    private int stageSelect = 0;
    private int stageSelectLog = 0;
    private int clear;
    private int coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clear = GameManager.instance.stageNum;
        coin = GameManager.instance.coinNum;
        stageSelectLog = stageSelect;
        if(Input.GetKeyDown(KeyCode.RightArrow)&&stageSelect<1)
        {
            stageSelect += 1;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)&&stageSelect>0)
        {
            stageSelect -= 1;
        }
        for(int i=0;i<2;i++)
        {
            if(i==stageSelect)
            {
                Stage[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            else
            {
                Stage[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        if(coin>=10&&clear>=1)
        {
            Stage[1].SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
           switch(stageSelect)
            {
                case 0:
                    SceneManager.LoadScene("gameScene1");
                    break;
                case 1:
                    SceneManager.LoadScene("gameScene2");
                    break;
            }
        }
    }
}
