using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage : MonoBehaviour
{
    public string scene;
    public bool pickUp = false;
    public GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(pickUp)
        {
            pickUp = false;
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            pointer.transform.position = new Vector3(gameObject.transform.position.x,-10.0f,0.0f);
        }
       else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);


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
