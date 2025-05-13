using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The MusicController class manages the music in the game.
public class MusicController : MonoBehaviour
{
    // It allows an instance of the MusicController class to be created (Singleton Pattern).
    public static MusicController instance;

    // Public AudioSource variables to hold different music genres.
    public AudioSource levelMusic, MainMenuMusic, WeaponMusic, victoryMusic, gameOverMusic;

    // Awake works when an instance of this class is created.
    private void Awake()
    {
        // It assigns an instance of this class to the instance variable.
        instance = this;
    }

    // Start works before the first frame.
    // Here, instead of the main menu music, the game music starts playing.
    void Start()
    {
        PlayLevelMusic(); // Starts playing the game's level music.
    }

    // StopMusic stops all music.
    void StopMusic()
    {
        // Stops all music sources.
        levelMusic.Stop();
        MainMenuMusic.Stop();
        WeaponMusic.Stop();
        victoryMusic.Stop();
        gameOverMusic.Stop();
    }

    // PlayLevelMusic plays the music of the game level.
    public void PlayLevelMusic()
    {
        StopMusic(); // Stops all currently playing music.
        levelMusic.Play(); // Starts playing the game's level music.
    }

    // PlayMainMenu plays the main menu music.
    public void PlayMainMenu()
    {
        StopMusic(); // Stops all currently playing music.
        MainMenuMusic.Play(); // The main menu music starts playing.
    }


    // PlayBulletMusic plays the sound of a gunshot. (In this method, the music is not stopped.)
    public void PlayBulletMusic()
    {
        WeaponMusic.Play(); // The sound of a gunshot starts to ring out.
    }

    // PlayVictory plays the victory music.
    public void PlayVictory()
    {
        StopMusic(); // Stops all currently playing music.
        victoryMusic.Play();
    }

    // PlayGameOver plays the game over music.
    public void PlayGameOver()
    {
        StopMusic(); // Stops all currently playing music.
        gameOverMusic.Play(); // The end game music starts playing.
    }
}