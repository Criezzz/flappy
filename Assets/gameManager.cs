using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject prefab;
    public bool inGame;
    public bool gameOver;

    private void Awake()
    {

        inGame = false;
        gameOver = false;
    }   
    void Update()
    {
        if (inGame == false)
        {
            inGame = true;
            InvokeRepeating("Spawn",0.1f, 1f);
        }
    }
    void Spawn() // 3.2 -> 0.4 y
    {
        Instantiate(prefab, new Vector3(7.55f, Random.Range(3.2f, 0.4f), 0 ), Quaternion.identity);
    }
}
