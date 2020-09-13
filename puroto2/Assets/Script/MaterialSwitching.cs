using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitching : MonoBehaviour
{
    public Material[] material;
    private bool switching = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (switching == true)
            {
               
                this.GetComponent<Renderer>().material = material[1];
                switching = false;

            }
            else
            {
                this.GetComponent<Renderer>().material = material[0];
                switching = true;
            }
        }
    }
}
