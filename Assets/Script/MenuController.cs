using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject quitButton;
    public TextMeshProUGUI finalScoreText;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void ShowMenu()
    {
        finalScoreText.text = ("Your score was " + player.score.ToString());
        finalScoreText.gameObject.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
