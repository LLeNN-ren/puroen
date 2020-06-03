using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clearDirector : MonoBehaviour
{
    public GameObject Scenes;
    public GameObject[] Scene = new GameObject[3];
    private int sceneSelect = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && sceneSelect < 2)
        {
            sceneSelect += 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && sceneSelect > 0)
        {
            sceneSelect -= 1;
        }
        for (int i = 0; i < 3; i++)
        {
            if (i == sceneSelect)
            {
                Scene[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
            else
            {
                Scene[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (sceneSelect)
            {
                case 0:
                    SceneManager.LoadScene("gameScene1");
                    break;
                case 1:
                    SceneManager.LoadScene("StageSelect");
                    break;
                case 2:
                    SceneManager.LoadScene("title");
                    break;
            }
        }
    }
}
