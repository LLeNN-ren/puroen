using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private timer Timer;
    public CriAtomSource GoalSound;
    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("timer").GetComponent<timer>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameManager.instance.stageNum = clear;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag=="Player"|| coll.gameObject.tag == "Shadow")
        {
            GoalSound.Play();
            GameManager.instance.stageNum += 1;
            SceneManager.LoadScene("clearScene");
            Destroy(gameObject);
            GameManager.instance.timerNum = Timer.countTime;
            Timer.time = false;
        }
    }
}
