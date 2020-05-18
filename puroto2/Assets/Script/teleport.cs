using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private Player player;

    public GameObject Player;
    public GameObject TeleportArea;

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
            //Vector3 TAposition = TeleportArea.transform.position;
            //Vector3 Pposition = Player.transform.position;
            Transform TAtransform = TeleportArea.transform;
            Vector3 TApos = TAtransform.position;

            Transform Ptransform = Player.transform;
            Vector3 Ppos = Ptransform.position;

            Ppos.x = TApos.x;
            Ppos.y = TApos.y + 2.0f;

            Player.gameObject.tag = "Player";
            player.normal.SetActive(true);
            player.shadow.SetActive(false);
            player.playerMode = true;

            Ptransform.position = Ppos;
        }
    }
}
