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

        Vector3 pipePosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        GameObject newPipe = Instantiate(pipe, pipePosition, transform.rotation);

        if (logic.playerScore > 1)
        {
            spawnMonster(newPipe);
        }
    }

    void spawnMonster(GameObject pipe)
    {
        float monsterMinY = pipe.transform.position.y - heightOffset / 2;
        float monsterMaxY = pipe.transform.position.y + heightOffset / 2;
        Vector3 monsterPosition = new Vector3(pipe.transform.position.x, Random.Range(monsterMinY, monsterMaxY), 0);

        Instantiate(monster, monsterPosition, Quaternion.identity, pipe.transform);
    }
}
