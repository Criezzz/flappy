using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance { get; private set; }
    public GameObject player;
    public GameObject prefab;
    public GameObject cv;
    public bool inGame;
    public bool gameOver;

    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
        inGame = false;
        gameOver = false;
    }   
    void Update()
    {
        if (!inGame)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                play();
            }
        }
        if (gameOver)
        {
            Time.timeScale = 0f;
            cv.transform.Find("playButton").gameObject.SetActive( true);

        }
    }
    private void Spawn() //4->0 y
    {
        Instantiate(prefab, new Vector3(7.55f, Random.Range(4f,  0f), 0 ), Quaternion.identity);
    }
    public void play()
    {
        inGame = true;
        cv.transform.Find("message").gameObject.SetActive(false);
        player.GetComponent<playerControl>().enabled = true;
        InvokeRepeating("Spawn", 4f, 0.8f);
    }
    
}
