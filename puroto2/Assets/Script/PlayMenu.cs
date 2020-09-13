﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    private Player player;
    private timer Timer;

    public GameObject BackTitle;
    public GameObject BackGame;

    public float Keep_move;
    public float Keep_Skasoku;
    public float Keep_mem;
    public bool kidou;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Timer = GameObject.Find("timer").GetComponent<timer>();

        BackTitle.SetActive(false);
        BackGame.SetActive(false);
        kidou = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (kidou == false)
        {
            Keep_move = player.moveSpeed;
            Keep_Skasoku = player.shadowkasoku;
            Keep_mem = player.mem;
            player.moveSpeed = 0;
            player.shadowkasoku = 0;
            player.mem = 0;
            Timer.time = false;

            BackTitle.SetActive(true);
            BackGame.SetActive(true);
            kidou = true;
        }
    }
}
