using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Transform BG;
    public float scrollSpeed;

    private float bgWidth;

    void Start()
    {
        bgWidth = BG.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    void Update()
    {
        BG.position = new Vector3(BG.position.x - (scrollSpeed * Time.deltaTime), BG.position.y);
        
        if (BG.position.x < -bgWidth - 1)
        {
            BG.position += new Vector3(bgWidth * 2f, 0f, 0f);
        }
    }
}