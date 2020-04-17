using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject[] continuePoint;
    public GameObject shadowGauge;

    private Player player;
   
    // Start is called before the first frame update
    void Start()
    {
        if(playerObj!=null&&continuePoint!=null&&continuePoint.Length>0)
        {
            playerObj.transform.position = continuePoint[0].transform.position;
            player = playerObj.GetComponent<Player>();
            
        }
    }

    void Update()
    {
        if(player.IsDown())
        {
            playerObj.transform.position = continuePoint[GameManager.instance.continueNum].transform.position;
            player.ContinuePlayer();
            
        }
    }

    public void ShadowGaugeUp()
    {
        shadowGauge.GetComponent<Image>().fillAmount =player.shadowMode;
    }

    public void ShadowGaugeDown()
    {
        shadowGauge.GetComponent<Image>().fillAmount=player.shadowMode;
    }
}
