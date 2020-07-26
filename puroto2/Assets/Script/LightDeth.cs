using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDeth : MonoBehaviour
{
    private Player player;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Shadow")
        {
            Destroy(Player.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Shadow")
        {
            Destroy(Player.gameObject);
        }
    }
}
