using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float countTime = 0;
    public bool time = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && time == true)//タイマー停止
        {
            time = false;

        }
        if (Input.GetKeyDown(KeyCode.R) && time == false)//タイマー再開
        {
            time = true;
        }
        if (time == true)
        {
            countTime += Time.deltaTime; //スタートしてからの秒数を格納
        }

        //Debug.Log(time);

        GetComponent<Text>().text = countTime.ToString("F2"); //小数2桁にして表示
    }
}
