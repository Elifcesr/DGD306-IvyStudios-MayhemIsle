using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    //creates a box in Unity to store our empty and full heart sprites 
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public UnityEngine.UI.Image[] hearts;

    public Image portraitImage;
    public Sprite portrait;

    public EnemyHealth enemyHealth;
    public EnemyHealth enemy2Health;
    public EnemyHealth enemy3Health;
    public EnemyHealth bossHealth;
    public EnemyHealth boss2Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
    }

    public void FindClosestEnemy()
    {
        //tells the script to search the entire (infinite) bounds of the scene.
        float closestEnemyDistance = Mathf.Infinity;
        EnemyHealth nearestEnemy = null;

        // makes a list of objects that have the EnemyHealth script attached to them
        EnemyHealth[] potentialTargets = FindObjectsOfType<EnemyHealth>();

        //will run this loop for every single potential target in our list of enemies
        foreach(EnemyHealth currentEnemy in potentialTargets)
        {
            //sqrMagnitude : using this here saves us some efficiency as we use this instead of using a Distance function
            float distanceAway = (currentEnemy.transform.position - transform.position).sqrMagnitude;
            if(distanceAway < closestEnemyDistance)
            {
                closestEnemyDistance = distanceAway;
                nearestEnemy = currentEnemy;

                maxHealth = nearestEnemy.maxHealth;
                health = nearestEnemy.currentHealth;
                portraitImage.sprite = nearestEnemy.portrait;
            }
        }
        // only turns on the enemy UI if they are close to the player
        if(closestEnemyDistance <= 25)
        {
            HealthBarOn();
        }
        else
        {
            HealthBarOff();
        }
    }

    public void HealthBarOff()
    {
        portraitImage.enabled = false;
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }
    public void HealthBarOn()
    {
        portraitImage.enabled = true;
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