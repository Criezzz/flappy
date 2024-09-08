using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg : MonoBehaviour
{
    private MeshRenderer mesh;
    public float scrollingSpeed = 0.25f;
    // Start is called before the first frame update
    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        mesh.material.mainTextureOffset += new Vector2 (scrollingSpeed * Time.deltaTime, 0);
    }
}
