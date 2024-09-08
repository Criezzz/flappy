using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 4f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            direction = Vector3.up * strength;

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
}
