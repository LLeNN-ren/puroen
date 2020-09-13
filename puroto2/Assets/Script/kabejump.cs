using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabejump : MonoBehaviour
{
    private Player player; //プレイヤーのスクリプトの情報を回収
    private Rigidbody Prig;　//プレイヤーのrig
    public Transform Player;//プレイヤーのトランスフォームとかを取り出す
    public Transform This;
    public float a; //BOXコライダーの大きさを１ずらしたら0.5数値をずらす（ずらした半分）
    public float j;

    private Animator animCon;
    CriAtomSource kabeJumpSound;

    // Start is called before the first frame update
    void Start()
    {
      animCon = GetComponent<Animator>();
      j = 2.0f;
      player = GameObject.Find("Player").GetComponent<Player>();
      Prig = GameObject.Find("Player").GetComponent<Rigidbody>();
        //just = GameObject.Find("Just_kabejamp").GetComponent<kabejamp_just>();
        kabeJumpSound = GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Ppos = Player.position;
        Vector3 Prota = Player.localEulerAngles;

        Vector3 Thispos = This.position;
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
        Vector3 Prota = Player.localEulerAngles;

        if (other.gameObject.tag == "wall" )
        {
                Prig.AddForce(Player.up * (player.jumpForce + j), ForceMode.Impulse);
                kabeJumpSound.Play();
            if (player.player_rotation == false)
                {
                    player.player_rotation = true;
                    Player.Rotate(0.0f, 180.0f, 0.0f);
                }
                else if (player.player_rotation == true)
                {
                    player.player_rotation = false;
                    Player.Rotate(0.0f, 180.0f, 0.0f);
                }
        }
        if (other.gameObject.tag == "ice_wall" && player.playerMode ==true)
        {
            Prig.AddForce(Player.up * (player.jumpForce + j), ForceMode.Impulse);
            kabeJumpSound.Play();
            if (player.player_rotation == false)
            {
                player.player_rotation = true;
                Player.Rotate(0.0f, 180.0f, 0.0f);
            }
            else if (player.player_rotation == true)
            {
                player.player_rotation = false;
                Player.Rotate(0.0f, 180.0f, 0.0f);
            }
        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "wall" && just.JUST == true)
        {
            just.JUST = false;
        }
    }*/
}
