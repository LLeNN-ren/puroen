using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabejump : MonoBehaviour
{
    private Player player; //プレイヤーのスクリプトの情報を回収
    private Rigidbody Prig;　//プレイヤーのrig
    private kabejamp_just just;
    public GameObject Player; //プレイヤーのトランスフォームとかを取り出す

    public float a; //BOXコライダーの大きさを１ずらしたら0.5数値をずらす（ずらした半分）
    public float j;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.Find("Player").GetComponent<Player>();
      Prig = GameObject.Find("Player").GetComponent<Rigidbody>();
      just = GameObject.Find("Just_kabejamp").GetComponent<kabejamp_just>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform Ptransform = Player.transform;
        Vector3 Ppos = Ptransform.position;
        Vector3 Prota = Player.transform.localEulerAngles;

        Vector3 Thispos = transform.position;
        if (Prota.y >= 180.0)
        {
            Thispos.x = Ppos.x - a;
            Thispos.y = Ppos.y - 2.0f;
            Thispos.z = Ppos.z;

            transform.position = Thispos;
        }
        if (Prota.y <= 10.0)
        {
            Thispos.x = Ppos.x + a;
            Thispos.y = Ppos.y - 2.0f;
            Thispos.z = Ppos.z;

            transform.position = Thispos;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        Vector3 Prota = Player.transform.localEulerAngles;

        if (other.gameObject.tag == "wall" && just.JUST == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Prig.AddForce(Player.transform.up * (player.jumpForce + j), ForceMode.Impulse);

                if (player.player_rotation == false)
                {
                    player.player_rotation = true;
                    Player.transform.Rotate(0.0f, 180.0f, 0.0f);
                }
                else if (player.player_rotation == true)
                {
                    player.player_rotation = false;
                    Player.transform.Rotate(0.0f, 180.0f, 0.0f);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "wall" && just.JUST == true)
        {
            just.JUST = false;
        }
    }
}
