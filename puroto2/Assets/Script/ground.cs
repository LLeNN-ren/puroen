﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            box.isTrigger = false;
        }
        if (coll.gameObject.tag == "Shadow")
        {
            box.isTrigger = true;
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
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            box.isTrigger = false;
        }
        if (coll.gameObject.tag == "Shadow")
        {
            box.isTrigger = true;
        }
    }
}
