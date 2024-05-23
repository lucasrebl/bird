using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartMove : MonoBehaviour
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
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deathZone)
            {
                Destroy(gameObject);
            }
        }
    }
}
