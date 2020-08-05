using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour
{
    public GameObject kabe;
    public TitlePlayer player;
    public Fade fade;

   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<TitlePlayer>();
        //fade = GameObject.Find("Fade").GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            kabe.SetActive(false);
            
        }
        
        if (fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("StageSelect");
        }
    }

   
}
