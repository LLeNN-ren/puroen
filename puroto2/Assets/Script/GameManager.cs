using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int stageNum=0;
    public int continueNum=0;
    public int coinNum = 0;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
   
}
