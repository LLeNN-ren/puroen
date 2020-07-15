using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clearDirector : MonoBehaviour
{
    //public GameObject Scenes;
    //public GameObject[] Scene = new GameObject[2];
    //private int sceneSelect = 0;

    
    private Ray ray;
    private RaycastHit hit;

    public GameObject timeText;
    public GameObject time;
    public GameObject home;
    public GameObject restart;


    private int count=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            count++;
        }
        switch(count)
        {
            case 0:
                timeText.SetActive(false);
                time.SetActive(false);
                restart.SetActive(false);
                home.SetActive(false);
                break;
            case 1:
                timeText.SetActive(true);
                break;
            case 2:
                time.SetActive(true);
                
                break;
            case 3:
                restart.SetActive(true);
                home.SetActive(true);
                break;
        }
        ray = new Ray();
        hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit,
            Mathf.Infinity))
        {

            if (hit.collider.gameObject.tag == "home")
            {
                hit.collider.gameObject.GetComponent<backScene>().pickUp = true;
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.gameObject.GetComponent<backScene>().BackStageSelect();
                    count = 0;
                }
            }
            if (hit.collider.gameObject.tag == "restart")
            {
                hit.collider.gameObject.GetComponent<backScene>().pickUp = true;
               
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.gameObject.GetComponent<backScene>().Restart();
                    count = 0;
                }
            }
            
        }

        //if (Input.GetKeyDown(KeyCode.RightArrow) && sceneSelect < 1)
        //{
        //    sceneSelect += 1;
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow) && sceneSelect > 0)
        //{
        //    sceneSelect -= 1;
        //}
        //for (int i = 0; i < 2; i++)
        //{
        //    if (i == sceneSelect)
        //    {
        //        Scene[i].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        //    }
        //    else
        //    {
        //        Scene[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //    }
        //}



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    switch (sceneSelect)
        //    {
        //        case 0:
        //            SceneManager.LoadScene(GameManager.instance.sceneRestart);
        //            break;
        //        case 1:
        //            SceneManager.LoadScene("title");
        //            break;
        //    }
        //}
    }
}
