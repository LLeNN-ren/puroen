using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backScene : MonoBehaviour
{
    public bool pickUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp)
        {
            pickUp = false;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        }
    }

    public void BackStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Restart()
    {
        SceneManager.LoadScene(GameManager.instance.sceneRestart);
    }
}
