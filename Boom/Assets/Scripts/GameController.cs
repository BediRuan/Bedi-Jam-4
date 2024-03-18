using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using TMPro; 

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject victoryImage;
    public Button restartButton;

    private float timer = 0f;
    private bool gameWon = false;

    void Update()
    {
        if (!gameWon)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F0");

            if (timer >= 100f)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        gameWon = true;
        victoryImage.SetActive(true);
        restartButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the current scene
    }
}
