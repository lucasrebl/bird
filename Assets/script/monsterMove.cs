using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{
    public float moveSpeed = 0;
    public float deathZone = -45;
    public logicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    void Update()
    {
        if (!logic.pauseMenuScreen.activeSelf)
        {
            AdjustMoveSpeed();

            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deathZone)
            {
                Destroy(gameObject);
            }
        }
    }

    void AdjustMoveSpeed()
    {
        int score = logic.playerScore;

        if (score < 10)
        {
            moveSpeed = 0;
        }
        else if (score >= 10 && score < 20)
        {
            moveSpeed = 2;
        }
        else if (score >= 20 && score < 30)
        {
            moveSpeed = 4;
        }
        else if (score >= 30 && score < 40)
        {
            moveSpeed = 5;
        }
        else
        {
            moveSpeed = 0;
        }
    }
}
