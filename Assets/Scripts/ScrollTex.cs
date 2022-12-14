using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTex : MonoBehaviour
{
    [SerializeField] private float scrollX = 0f;
    [SerializeField] private float scrollY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
