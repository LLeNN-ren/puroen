using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kageyuka : MonoBehaviour
{
    BoxCollider box;
    private bool isDown=false;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)&&isDown==true)
        {
            box.isTrigger = true;
            isDown = false;
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            box.isTrigger = true;
        }
        if (coll.gameObject.tag == "Shadow")
        {
            box.isTrigger = false;
            isDown = true;
        }
    }

    private void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            box.isTrigger = false;
        }
        if (coll.gameObject.tag == "Shadow")
        {
            box.isTrigger = true;
            isDown = true;
        }
    }

    
}
