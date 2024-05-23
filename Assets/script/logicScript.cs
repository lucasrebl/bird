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
    public GameObject scroreIncreaseScreen;

    public int monsterKillCount = 0;
    public DisplayMonsterKillCount displayMonsterKillCount;

    private void Start()
    {
        displayMonsterKillCount = FindObjectOfType<DisplayMonsterKillCount>();
        UpdateMonsterKillCountDisplay();
    }

    [ContextMenu("Augmenter le score")]
    public void addScore(int ScoreToAdd)
    {
        playerScore = playerScore + ScoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore >= 40)
        {
            if (monsterKillCount == 0)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public void incrementMonsterKillCount()
    {
        monsterKillCount++;
        UpdateMonsterKillCountDisplay();
    }

    void UpdateMonsterKillCountDisplay()
    {
        if (displayMonsterKillCount != null)
        {
            displayMonsterKillCount.UpdateMonsterKillText(monsterKillCount);
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

    public void scroreIncrease()
    {
        scroreIncreaseScreen.SetActive(true);
    }
}