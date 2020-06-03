using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glass : MonoBehaviour
{
    BoxCollider box;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag== "Shadow")
        {
            box.isTrigger = true;
        }
        if (coll.gameObject.tag == "Player")
        {
            box.isTrigger = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Shadow"||other)
        {
            box.isTrigger = false;
        }
        
    }


}
