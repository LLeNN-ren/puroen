using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgame : MonoBehaviour
{
    private Player player;
    private timer Timer;
    private PlayMenu playmenu;

    public GameObject BackTitle;
    public GameObject BackGame;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Timer = GameObject.Find("timer").GetComponent<timer>();
        playmenu = GameObject.Find("MenuButton").GetComponent<PlayMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        player.moveSpeed = playmenu.Keep;
        Timer.time = true;
        playmenu.kidou = false;

        BackTitle.SetActive(false);
        BackGame.SetActive(false);
    }
}
