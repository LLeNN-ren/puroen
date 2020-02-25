using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kage : MonoBehaviour
{
    Color color;

    private bool isColor=true;
    // Start is called before the first frame update
    void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(isColor)
        {
            color.a = 1.0f;
        }
        if(isColor==false)
        {
            color.a = 0.5f;
        }
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name=="Player")
        {
            isColor = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name=="Player")
        {
            isColor = true;
        }
    }
}
