using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage : MonoBehaviour
{
    public string scene;
    public bool pickUp = false;
    CriAtomSource select;
    int SE_controlFlag = 0;
    // Start is called before the first frame update
    void Start()
    {
        select = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp)
        {
            pickUp = false;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            if (SE_controlFlag == 0)
            {
                select.Play();
                SE_controlFlag = 1;
            }
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            SE_controlFlag = 0;
        }
    }

    //public void PickUp()
    //{
    //    transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    //}

    //public void NoPickUp()
    //{
    //    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //}

    public void StageSelect()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameManager.instance.sceneRestart = scene;
        SceneManager.LoadScene(scene);
    }
}
