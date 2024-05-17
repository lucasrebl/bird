using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public GameObject lifeLooseScreen;

    [ContextMenu("Augmenter le score")]
    public void addScore(int ScoreToAdd)
    {
        playerScore = playerScore + ScoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore >= 100)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void pauseMenu()
    {
        pauseMenuScreen.SetActive(true);
    }

    public void pauseMenuOff()
    {
        pauseMenuScreen.SetActive(false);
    }

    public void lifeLoose()
    {
        lifeLooseScreen.SetActive(true);
    }
}
