using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject monster;
    public GameObject heart;
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

        if (logic.playerScore > 1 && Random.Range(0, 3) < 2)
        {
            spawnMonster(newPipe);
        }
        else if (Random.Range(0, 5) < 4)
        {
            spawnHeart(newPipe);
        }
    }

    void spawnMonster(GameObject pipe)
    {
        float monsterMinY = pipe.transform.position.y - heightOffset / 2;
        float monsterMaxY = pipe.transform.position.y + heightOffset / 2;
        Vector3 monsterPosition = new Vector3(pipe.transform.position.x, Random.Range(monsterMinY, monsterMaxY), 0);

        if (!isPositionOccupied(monsterPosition))
        {
            Instantiate(monster, monsterPosition, Quaternion.identity, pipe.transform);
        }
    }

    void spawnHeart(GameObject pipe)
    {
        float heartMinY = pipe.transform.position.y - heightOffset / 2;
        float heartMaxY = pipe.transform.position.y + heightOffset / 2;
        Vector3 heartPosition = new Vector3(pipe.transform.position.x, Random.Range(heartMinY, heartMaxY), 0);

        if (!isPositionOccupied(heartPosition))
        {
            Instantiate(heart, heartPosition, Quaternion.identity, pipe.transform);
        }
    }

    bool isPositionOccupied(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Monster") || collider.CompareTag("Heart"))
            {
                return true;
            }
        }
        return false;
    }
}
