using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance { get; private set; }
    public GameObject prefab;
    public bool inGame;
    public bool gameOver;

    private void Awake()
    {
        instance = this;
        inGame = false;
        gameOver = false;
    }   
    void Update()
    {
        if (inGame == false)
        {
            inGame = true;
            InvokeRepeating("Spawn",4f, 0.8f);
        }
        if (gameOver)
        {
            Time.timeScale = 0f;

        }
    }
    void Spawn() // 3.2 -> 0.4 y
    {
        Instantiate(prefab, new Vector3(7.55f, Random.Range(4f,  0f), 0 ), Quaternion.identity);
    }
}
