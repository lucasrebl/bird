using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject monster;
    public float spawnRate = 5;
    public float timer = 0;
    public float heightOffset = 10;
    public logicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        spawnPipe();
    }

    void Update()
    {
        if (!logic.pauseMenuScreen.activeSelf)
        {
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0;
            }
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        if (logic.playerScore >= 2 && Random.Range(0, 2) == 0)
        {
            float randomY = Random.Range(lowestPoint, highestPoint);

            Instantiate(monster, new Vector3(transform.position.x, randomY + 1f, 0), transform.rotation);
        }
    }
}
