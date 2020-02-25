using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rd;

    public float moveSpeed;
    public float jumpForce;
    public int count;

    public Vector3 rbVelo;

    public bool isJump;
    public bool playerMode=true;

    public GameObject normal;
    public GameObject shadow;

    public GameObject kage;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rbVelo = rd.velocity;

        rd.AddForce(new Vector3(moveSpeed * Time.deltaTime, 0, 0), ForceMode.Force);
        if(Input.GetKeyDown(KeyCode.Space)&&count<2)
        {
            rd.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            count++;
            
        }
       

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(playerMode==true)
            {
                gameObject.tag = "Shadow";
                normal.SetActive(false);
                shadow.SetActive(true);
                playerMode = false;
            }
            else
            {
                gameObject.tag = "Player";
                normal.SetActive(true);
                shadow.SetActive(false);
                playerMode = true;
            }
        }

      
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag=="ground")
        {
            isJump = false;
        }
    }
    private void OnCollisionExit(Collision coll)
    {
        if(coll.gameObject.tag=="ground"||coll.gameObject.tag=="kage")
        {
            isJump = true;
            count = 0;
        }
    }
    
}
