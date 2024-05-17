using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public logicScript logic;
    public AudioSource hitSound;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);

            logicScript logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
            if (logic != null)
            {
                logic.addScore(2);
            }

            if (hitSound != null) 
            {
                hitSound.Play();
            }

            Destroy(gameObject);
        }
    }
}
