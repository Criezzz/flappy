using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance { get; private set; }
    public GameObject player;
    public GameObject prefab;
    public GameObject cv;
    public GameObject scoreMsg;
    public bool inGame;
    public bool gameOver;
    public int score;
    public GameObject scoreRegular;

    private void Awake()
    {
        score = 0;
        Time.timeScale = 1;
        instance = this;
        inGame = false;
        gameOver = false;
        scoreRegular = cv.transform.Find("scoreRegular").gameObject;
    }   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        if (!inGame)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                
                play();
                
            }
        }
        if (inGame)
        {
            scoreRegular.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }
        if (gameOver)
        {
            Time.timeScale = 0f;
            GameObject gameoverScene = cv.transform.Find("gameover").gameObject;
            gameoverScene.SetActive( true);
            string v = score.ToString();
            scoreMsg.transform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = v;
            scoreMsg.transform.Find("bestText").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("best").ToString();
        }
    }
    private void Spawn() //3.8->0 y
    {
        Instantiate(prefab, new Vector3(7.55f, Random.Range(3.8f,  0f), 0 ), Quaternion.identity);
    }
    public void play()
    {
        inGame = true;
        cv.transform.Find("message").gameObject.SetActive(false);
        scoreRegular.SetActive(true);
        player.GetComponent<playerControl>().enabled = true;
        InvokeRepeating("Spawn", 4f, 0.8f);
    }


}
