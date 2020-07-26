using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rd;

    public float moveSpeed;
    public float shadowkasoku;//7/20追加影エリア内に速さ変更の数値
    public float mem;
    public float jumpForce;
    public int count;
    //public float maxSpeed;
    public float shadowMode=1;

    public bool tito = true;

    //public Vector3 rbVelo;

    public bool isJump;
    public bool playerMode=true;
    public bool isDown = false;
    public bool player_rotation = false;

    public GameObject normal;
    public GameObject shadow;

    public GameObject kage;

    public GameObject stageManager;

    public int stageCoin;
    public UnityEngine.UI.Text textcoin;

    public StageManager stage;

    public CriAtomSource jumpSound;
    public CriAtomSource shadowInSound;
    public CriAtomSource shadowOutSound;
    public CriAtomSource soulGetSound;
    public CriAtomSource landingSound;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        stage = stageManager.GetComponent<StageManager>();
        mem = moveSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        //rbVelo = rd.velocity;
        
        //rd.AddForce(new Vector3(moveSpeed, 0, 0), ForceMode.Force);

        rd.velocity= new Vector3(moveSpeed, rd.velocity.y, 0);
        

        if (shadowMode >= 1)
        {
            shadowMode = 1.0f;
        }



        if (Input.GetKeyDown(KeyCode.Space)&&isJump == false)
        {
            rd.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            count++;
            jumpSound.Play();

        }

        if(this.gameObject.transform.position.y<-16)
        {
            isDown = true;
        }

        if(Input.GetKeyDown(KeyCode.Z)|| shadowMode <= 0)
        {
            if(playerMode==true&&shadowMode>0)
            {
                gameObject.tag = "Shadow";
                normal.SetActive(false);
                shadow.SetActive(true);
                playerMode = false;
                shadowInSound.Play();

            }
            else
            {
                gameObject.tag = "Player";
                normal.SetActive(true);
                shadow.SetActive(false);
                playerMode = true;
                shadowOutSound.Play();
            }
        }

        /*if(playerMode==false&&shadowMode>0)
        {
            shadowMode -= 0.2f * Time.deltaTime;
            stage.ShadowGaugeDown();
        }
        else if(playerMode==true&&shadowMode<1)
        {
            shadowMode += 0.1f * Time.deltaTime;
            stage.ShadowGaugeUp();
        }*/

        if (player_rotation==true)
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
        if(coll.gameObject.tag=="ground" || coll.gameObject.tag == "kage")
        {
            //isJump = false;
            landingSound.Play();
        }
        if (coll.gameObject.tag == "glass" && player_rotation == false)
        {
            player_rotation = true;
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if(coll.gameObject.tag=="glass"&&player_rotation==true)
        {
            player_rotation = false;
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        /*if (coll.gameObject.tag == "wall" && player_rotation == false)
        {
            player_rotation = true;
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if (coll.gameObject.tag == "wall" && player_rotation == true)
        {
            player_rotation = false;
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        }*/
        //死亡判定こいつらじゃ無理だった↓
        //GameManegerをタイトルシーンからゲームシーンにコピペしました。タイトルシーンから開始するなら動く↓ので消した方がいい。作ってるときだけはあるとゲームシーンからすぐ始められて便利そうなだけ。
        if (coll.gameObject.tag == "wall")
        {
            isDown = true;
        }
        else if (coll.gameObject.tag == "wall")
        {
            isDown = true;
        }
    }

    private void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "ground" || coll.gameObject.tag == "kage")
        {
            isJump = false;
            //landingSound.Play();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            GameManager.instance.continueNum = 1;
            //GameManager.instance.coinNum += 10;
        }

        if (other.gameObject.tag == "coin")
        {
            shadowMode += 0.05f;
            moveSpeed += 0.0f;
            Destroy(other.gameObject);
            AddCoin();
        }

        if(other.gameObject.tag == "player_wall" && gameObject.tag == "Player")
        {
            isDown = true;
        }
        else if (other.gameObject.tag == "shadow_wall" && gameObject.tag == "Shadow")
        {
            isDown = true;
        }



    }

    //ここなおしました7/20↓byぱる
    private void OnTriggerStay(Collider other)
    {
            if (other.gameObject.tag == "room")
            {
               if (playerMode == false)
               {
                   moveSpeed = shadowkasoku;
                   Debug.Log(other.name + "Stay");
               }
               else if(playerMode == true)
               {
                   moveSpeed = mem;
               }
            }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "room")
        {
            moveSpeed = mem;
        }
    }
    //ここなおしました7/20↑

    public IEnumerator ContinuePlayer()
    {
        isDown = false;
        playerMode = true;
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, 5.0f, 0.0f);
        moveSpeed = 0;
        yield return new WaitForSeconds(0.45f);
        moveSpeed = 7;
        yield break;
    }
    
    public bool IsDown()
    {
        if(isDown)
        {
            return true;
        }
        return false;
    }

    public void AddCoin()
    {
        soulGetSound.Play();
        stageCoin += 1;
        if (textcoin != null)
        {
            textcoin.text = "×" + stageCoin.ToString();
        }
    }
}
