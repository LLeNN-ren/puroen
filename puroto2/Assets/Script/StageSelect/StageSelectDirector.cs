using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectDirector : MonoBehaviour
{
    //public static bool[] ClearStageMark;
    //public GameObject Stages;
    //public GameObject[] Stage = new GameObject[2];
    //private int stageSelect = 0;
    //private int stageSelectLog = 0;
    private int clear;
    private int coin;
    private Ray ray;
    private RaycastHit hit;

    private Vector3 positon;
    private Vector3 screenToWorldPointPosition;
    
    public GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //clear = GameManager.instance.stageNum;
        //coin = GameManager.instance.coinNum;
        //stageSelectLog = stageSelect;

        ray = new Ray();
        hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray.origin,ray.direction,out hit, 
            Mathf.Infinity))
        {
            
            if(hit.collider.gameObject.tag=="stage")
            {
                hit.collider.gameObject.GetComponent<stage>().pickUp = true;
                //hit.collider.gameObject.GetComponent<stage>().PickUp();
                if(Input.GetMouseButtonDown(0))
                {
                    hit.collider.gameObject.GetComponent<stage>().StageSelect();
                }
            }
            
        }
        


        positon = Input.mousePosition;
        positon.z = 10.0f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(positon);
        pointer.transform.position = new Vector3(screenToWorldPointPosition.x, -10.0f, screenToWorldPointPosition.z);

       

    }

    
}
