using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    //creates a box in Unity to store our empty and full heart sprites 
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public UnityEngine.UI.Image[] hearts;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}