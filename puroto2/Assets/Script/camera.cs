using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public GameObject came1;
    public GameObject came2;
    public Player playersc;

    // Start is called before the first frame update
    void Start()
    {
        playersc= GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+35.0f, player.transform.position.y + 7.0f, -30.0f);

        if(transform.position.x>=235)
        {
            transform.position = new Vector3(came1.transform.position.x, player.transform.position.y + 7.0f, -30.0f);
        }

        

        if(playersc.player_rotation)
        {
            transform.position = new Vector3(player.transform.position.x-30.0f , player.transform.position.y + 7.0f, -30.0f);
            if (transform.position.x <= -30.0f)
            {
                transform.position = new Vector3(came2.transform.position.x, player.transform.position.y + 7.0f, -30.0f);
            }
        }
    }
}
