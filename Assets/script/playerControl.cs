using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Vector3 direction;
    public float gravity;
    public float strength;
    private void Start()
    {
        
        gravity = -18f;
        strength = 5f;
        tap();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            tap();

        }
        direction.y += gravity * Time.deltaTime;
        float zRotation = transform.eulerAngles.z;
        float normalizedZ = Mathf.DeltaAngle(0, zRotation); // This gives you the angle in a range from -180 to 180

        if (normalizedZ > -90)
        {
            transform.Rotate(0, 0, -170*Time.deltaTime);
        }
        
        transform.position += direction * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("MainCamera"))
        {
            AudioManager.instance.playSound("hit");
            gameManager.instance.gameOver = true;

        }
    }
    private void tap()
    {
        if (gameManager.instance.gameOver) { return; }
        transform.rotation = Quaternion.Euler(0, 0, 45);
        direction = Vector3.up * strength;
    }
}
