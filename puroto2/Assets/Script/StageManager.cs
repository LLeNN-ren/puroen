using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform checkPoint;
    private GameObject playerObject;
    private Player player;

    void Awake()
    {
        playerObject = Instantiate(playerPrefab, checkPoint.position, Quaternion.identity) as GameObject;
        player = playerObject.GetComponent<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void toContinue()
    {
    }
}
