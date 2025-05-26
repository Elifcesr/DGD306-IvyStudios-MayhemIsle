using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // UI'deki Game Over paneli
    private bool isGameOverTriggered = false;

    public void TriggerGameOver()
    {
        if (isGameOverTriggered) return; // �kinci kez tetiklenmesini engelle
        isGameOverTriggered = true;

        // Game Over panelini g�ster
        gameOverPanel.SetActive(true);

        // M�zik de�i�tir
        MusicController.instance.PlayGameOver();
    }
}