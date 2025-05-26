using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // UI'deki Game Over paneli
    private bool isGameOverTriggered = false;

    public void TriggerGameOver()
    {
        if (isGameOverTriggered) return; // Ýkinci kez tetiklenmesini engelle
        isGameOverTriggered = true;

        // Game Over panelini göster
        gameOverPanel.SetActive(true);

        // Müzik deðiþtir
        MusicController.instance.PlayGameOver();
    }
}