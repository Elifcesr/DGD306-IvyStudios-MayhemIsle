using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // It is a singleton instance of WaveManager.
    public static WaveManager instance;

    // Stores wave objects
    public WaveObject[] waves;

    // Total number of enemies in all waves
    public int enemyAmount = 0;

    // The Index of the current wave
    public int currentWave;

    // It is the time left until the next wave starts.
    public float timeToNextWave;

    // Controls the generation of waves.
    public bool canSpawnWaves;

    private void Awake()
    {
        // Assign singleton instance
        instance = this;
    }

    // It is run once at startup
    void Start()
    {
        // Starts first wave spawn time.
        timeToNextWave = waves[0].timeToSpawn;

        // Calculates the total number of enemies in all waves.
        for (int i = 0; i < waves.Length; i++)
        {
            foreach (var wave in waves[i].theWave.gameObject.transform)
            {
                int temp = 0;
                temp++;
                enemyAmount += temp; // Adds each enemy to the count
            }
        }
    }

    // Called once per frame
    void Update()
    {
        // It controls whether spawn wave is active or not
        if (canSpawnWaves)
        {
            // Decreases countdown to next wave
            timeToNextWave -= Time.deltaTime;

            // When the duration reaches zero it spawns the wave
            if (timeToNextWave <= 0)
            {
                // Creates the current wave at the WaveManager's position
                Instantiate(waves[currentWave].theWave, transform.position, transform.rotation);

                // If there are more waves, it moves on to the next one
                if (currentWave < waves.Length - 1)
                {
                    currentWave++;
                    timeToNextWave = waves[currentWave].timeToSpawn; // It sets the time for the new wave
                }
                else
                {
                    // If all waves are completed, it stops the spawn process.
                    canSpawnWaves = false;
                }
            }
        }
    }

    // It is used to continue the wave spawn.
    public void ContinueSpawning()
    {
        // If there are more waves and time is not up, the spawn process continues.
        if (currentWave < waves.Length - 1 && timeToNextWave > 0)
        {
            canSpawnWaves = true;
        }
    }
}

// Class that represents the wave object
[System.Serializable]
public class WaveObject
{
    public float timeToSpawn; // This is the time when the wave will spawn.
    public EnemyWave theWave; // Reference to actual enemy wave
}
