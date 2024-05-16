using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicScript logic;
    public bool birdIsAlive = true;
    public int Life = 3;
    public DisplayLife displayLife;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        displayLife = FindObjectOfType<DisplayLife>();
        UpdateLifeText();
    }

    void Update()
    {
        if (!logic.pauseMenuScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }

            else if (Input.GetKeyDown(KeyCode.Semicolon) && birdIsAlive)
            {
                logic.loadMenu();
                birdIsAlive = false;
            }

            else if (Input.GetKeyDown(KeyCode.R) && birdIsAlive)
            {
                logic.restartGame();
            }

            else if (Input.GetKeyDown(KeyCode.P) && birdIsAlive)
            {
                logic.pauseMenu();
            }

            myRigidbody.gravityScale = 4.5f;
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.gravityScale = 0f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster") && birdIsAlive)
        {
            Life--;
            if (Life < 0)
            {
                logic.gameOver();
                birdIsAlive = false;
            }
            UpdateLifeText();
            Destroy(collision.gameObject);
        }
        else
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    void UpdateLifeText()
    {
        if (displayLife != null)
        {
            displayLife.UpdateLifeText(Life);
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
