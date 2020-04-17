using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rd;

    public float moveSpeed;
    public float jumpForce;
    public int count;
    public float maxSpeed;
    public float shadowMode=1;

    public Vector3 rbVelo;

    public bool isJump;
    public bool playerMode=true;
    public bool isDown = false;

    public GameObject normal;
    public GameObject shadow;

    public GameObject kage;

    public GameObject stageManager;

    public int stageCoin;
    public UnityEngine.UI.Text textcoin;

    public StageManager stage;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        stage = stageManager.GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rbVelo = rd.velocity;

        rd.AddForce(new Vector3(moveSpeed, 0, 0), ForceMode.Force);
        
        if(Input.GetKeyDown(KeyCode.Space)&&count<2)
        {
            rd.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            count++;
            
        }

        if(this.gameObject.transform.position.y<-16)
        {
            isDown = true;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(playerMode==true&&shadowMode>0)
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

        if(playerMode==false&&shadowMode>0)
        {
            shadowMode -= 1.0f * Time.deltaTime;
            stage.ShadowGaugeDown();
        }
        else if(playerMode==true&&shadowMode<1)
        {
            shadowMode += 0.1f * Time.deltaTime;
            stage.ShadowGaugeUp();
        }
        if(shadowMode<=0)
        {
            gameObject.tag = "Player";
            normal.SetActive(true);
            shadow.SetActive(false);
            playerMode = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            GameManager.instance.continueNum = 1;
            GameManager.instance.coinNum += 10;
        }

        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            AddCoin();
        }

        if(other.gameObject.tag == "player_wall" && this.gameObject.tag == "Player")
        {
            isDown = true;
        }
        else if (other.gameObject.tag == "shadow_wall" && this.gameObject.tag == "Shadow")
        {
            isDown = true;
        }
    }

    public void ContinuePlayer()
    {
        isDown = false;
        playerMode = true;
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
        stageCoin += 1;
        if (textcoin != null)
        {
            textcoin.text = "×" + stageCoin.ToString();
        }
    }
}
