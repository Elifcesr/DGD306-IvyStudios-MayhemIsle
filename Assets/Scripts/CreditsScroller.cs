using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroller : MonoBehaviour
{
    // Credits is the variable that determines the scrolling speed.
    public float scrollSpeed = 25f;

    // It is the variable that will hold the RectTransform component.
    private RectTransform rectTransform;

    // The function that will run at startup
    void Start()
    {
        // Retrieves the RectTransform component on this GameObject.
        rectTransform = GetComponent<RectTransform>();
    }

    // Function that will run in every frame
    void Update()
    {
        // Updates the position of the object to which the 'rectTransform' component is attached.
        // scrollSpeed ​​determines the scrolling speed and scrolls independently of the frame with Time.deltaTime.
        // It moves only on the Y axis, so the X value of Vector2 is set to zero.
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}