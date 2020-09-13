using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    public CriAtomSource Title;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "title"|| SceneManager.GetActiveScene().name == "StageSelect")
        {
            CriAtomSource.Status status = Title.status;
            if (status == CriAtomSource.Status.Stop)
            {
                Title.Play();
            }
        }
    }
}
