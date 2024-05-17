using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pipeMiddleScript : MonoBehaviour
{
    public logicScript logic;
    public AudioSource scoreSound;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            if (scoreSound != null)
            {
                scoreSound.Play();
            }
        }
    }
}
