using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabeanime : MonoBehaviour
{
    private Animator animCon;

    // Start is called before the first frame update
    void Start()
    {
        animCon = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animCon.SetBool("kabejump1", true);
        }
    }
}
