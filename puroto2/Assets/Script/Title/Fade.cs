using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public bool firstFadeInComp;

    private Image image = null;

    private int frameCount = 0;
    private float timer = 0.0f;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool compFadeIn = false;
    private bool compFadeOut = false;

    /// <summary>
    /// フェードインを開始する
    /// </summary>
    public void StartFadeIn()
    {
        if(fadeIn||fadeOut)
        {
            return;
        }
        fadeIn = true;
        compFadeIn = false;
        timer = 0.0f;
        image.color = new Color(1, 1, 1, 1);
        image.fillAmount = 1;
        image.raycastTarget = true;
    }

    /// <summary>
    /// フェードインが完了したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsFadeInComplete()
    {
        return compFadeIn;
    }

    /// <summary>
    /// フェードアウトを開始する
    /// </summary>
    public void StartFadeOut()
    {
        if (fadeIn || fadeOut)
        {
            return;
        }
        fadeOut = true;
        compFadeOut = false;
        timer = 0.0f;
        image.color = new Color(1, 1, 1, 0);
        image.fillAmount = 0;
        image.raycastTarget = true;
    }

    /// <summary>
    /// フェードアウトが完了したかどうか
    /// </summary>
    /// <returns></returns>
    public bool IsFadeOutComplete()
    {
        return compFadeOut;
    }
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if(firstFadeInComp)
        {
            FadeInComplete();
        }
        else
        {
            StartFadeIn();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            FadeInUpdate();
        }
        else if (fadeOut)
        {
            FadeOutUpdate();
        }
        
    }

    /// <summary>
    /// フェードイン中
    /// </summary>
    private void FadeInUpdate()
    {
        if(timer<1.0f)
        {
            image.color = new Color(1, 1, 1, 1 - timer);
            image.fillAmount = 1 - timer;
        }
        else
        {
            FadeInComplete();
        }
        timer += Time.deltaTime;
    }

    /// <summary>
    /// フェードアウト中
    /// </summary>
    private void FadeOutUpdate()
    {
        if(timer<1.0f)
        {
            image.color = new Color(1, 1, 1, timer);
            image.fillAmount = timer;
        }
        else
        {
            FadeOutComplete();
        }
        timer += Time.deltaTime;
    }

    /// <summary>
    /// フェードイン完了
    /// </summary>
    private void FadeInComplete()
    {
        image.color = new Color(1, 1, 1, 0);
        image.fillAmount = 0;
        image.raycastTarget = false;
        timer = 0.0f;
        fadeIn = false;
        compFadeIn = true;
    }

    /// <summary>
    /// フェードアウト完了
    /// </summary>
    private void FadeOutComplete()
    {
        image.color = new Color(1, 1, 1, 1);
        image.fillAmount = 1;
        image.raycastTarget = false;
        timer = 0.0f;
        fadeOut = false;
        compFadeOut = true;
    }
}
