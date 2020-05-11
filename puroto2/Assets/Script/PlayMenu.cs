﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    private Player player;
    private timer Timer;

    public GameObject BackTitle;
    public GameObject BackGame;

    public float Keep;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Timer = GameObject.Find("timer").GetComponent<timer>();

        BackTitle.SetActive(false);
        BackGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        Keep = player.moveSpeed;
        player.moveSpeed = 0;
        Timer.time = false;

        BackTitle.SetActive(true);
        BackGame.SetActive(true);
    }
}
