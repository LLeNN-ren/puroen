using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayer : MonoBehaviour
{
    Rigidbody rd;

    public float moveSpeed;
    public float jumpForce;
    public int count;
    //public float maxSpeed;
    public float shadowMode = 1;

    //public Vector3 rbVelo;

    
    
    public bool player_rotation = false;

    public GameObject normal;
    public GameObject shadow;

    public bool scene=false; 

    
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //rbVelo = rd.velocity;

        //rd.AddForce(new Vector3(moveSpeed, 0, 0), ForceMode.Force);

        rd.velocity = new Vector3(moveSpeed, rd.velocity.y, 0);


        if (shadowMode >= 1)
        {
            shadowMode = 1.0f;
        }



       

        if (player_rotation == true)
        {
            rd.velocity = new Vector3(-moveSpeed, rd.velocity.y, 0);
        }
        else
        {
            rd.velocity = new Vector3(moveSpeed, rd.velocity.y, 0);
        }
        // GameManager.instance.coinNum = stageCoin;
    }

    private void OnCollisionEnter(Collision coll)
    {


        if (coll.gameObject.tag == "wall" && player_rotation == false)
        {
            player_rotation = true;
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if (coll.gameObject.tag == "wall" && player_rotation == true)
        {
            player_rotation = false;
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        if(coll.gameObject.tag=="scene")
        {
            scene = true;
        }
       
    }
    
}
