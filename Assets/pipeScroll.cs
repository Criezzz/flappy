using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScroll : MonoBehaviour
{
    public float scrollingSpeed = 5.3f; // to match ground speed

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(scrollingSpeed * Time.deltaTime, 0 , 0 );
    }
}
