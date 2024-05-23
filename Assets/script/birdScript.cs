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

    public GameObject projectilePrefab;
    public float shootForce = 50f;

    private AudioSource[] audioSources;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        displayLife = FindObjectOfType<DisplayLife>();
        UpdateLifeText();
        audioSources = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (!logic.pauseMenuScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                myRigidbody.velocity = Vector2.up * flapStrength;

                audioSources[0].Play();
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

            if (Input.GetMouseButtonDown(0) && birdIsAlive)
            {
                ShootProjectile();
            }

            if (transform.position.y > 35f || transform.position.y < -35f)
            {
                logic.gameOver();
                birdIsAlive = false;
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
        if (collision.gameObject.CompareTag("arrow"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("Monster") && birdIsAlive)
        {
            Life--;
            audioSources[1].Play();
            if (Life < 0)
            {
                logic.gameOver();
                birdIsAlive = false;
            }
            else
            {
                StartCoroutine(ShowLifeLooseScreen());
            }
            UpdateLifeText();
            Destroy(collision.gameObject);

            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else if (collision.gameObject.CompareTag("Heart") && birdIsAlive)
        {
            Life++;
            UpdateLifeText();
            Destroy(collision.gameObject);

            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else
        {
            audioSources[2].Play();
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

    void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator ShowLifeLooseScreen()
    {
        logic.lifeLoose();
        yield return new WaitForSeconds(1f);
        logic.lifeLooseScreen.SetActive(false);
    }
}
