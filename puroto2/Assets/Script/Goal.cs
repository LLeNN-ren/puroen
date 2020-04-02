using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
   // private int clear=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameManager.instance.stageNum = clear;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag=="Player")
        {
            Destroy(gameObject);
            GameManager.instance.stageNum += 1;
            SceneManager.LoadScene("clearScene");
        }
    }
}
