using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemSE : MonoBehaviour
{
    public CriAtomSource Decision;
    public CriAtomSource Select;
    public CriAtomSource Back;
    public CriAtomSource Taiko;
    public CriAtomSource Title;
    int controlFlag=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (SceneManager.GetActiveScene().name == "title")
            {
                Decision.Play();
            }
            if (SceneManager.GetActiveScene().name == "StageSelect")
            {
                Decision.Play();
            }
        }
        if (SceneManager.GetActiveScene().name == "clearScene")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (controlFlag == 0) 
                {
                    Taiko.Play();
                    controlFlag += 1;
                }else if (controlFlag == 1)
                {
                    Taiko.Play();
                    controlFlag += 1;
                }else if (controlFlag == 2)
                {
                    Title.Play();
                    Taiko.Play();
                    controlFlag += 1;
                }else
                {
                    Decision.Play();
                }

            }
            
        }
        else
        {
            controlFlag = 0;
        }
    }
}
