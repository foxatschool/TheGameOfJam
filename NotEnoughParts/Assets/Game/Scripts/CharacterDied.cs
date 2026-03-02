using UnityEngine;

public class CharacterDied : MonoBehaviour
{
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject LosePanel;

    public void Die()
    {
        Time.timeScale = 0f;
        playerPanel.SetActive(false);
        pausePanel.SetActive(false);
        LosePanel.SetActive(true);
    }
}
