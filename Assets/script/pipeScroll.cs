using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScroll : MonoBehaviour
{
    public float scrollingSpeed = 5.3f; // to match ground speed
    private bool crossed;
    // Update is called once per frame
    private void Awake()
    {
        crossed = false;
    }
    void Update()
    {
        if (transform.position.x <= gameManager.instance.player.transform.position.x-2 && crossed == false)
        {
            gameManager.instance.score += 1 ;
            AudioManager.instance.playSound("point");
            if(gameManager.instance.score > PlayerPrefs.GetInt("best"))
            {
                PlayerPrefs.SetInt("best", gameManager.instance.score);
            }
            crossed = true;
        }
        if(transform.position.x < -11.6f)
        {
            Destroy(gameObject);
        }
        transform.position -= new Vector3(scrollingSpeed * Time.deltaTime, 0 , 0 );
    }
}
