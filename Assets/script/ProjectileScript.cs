using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public logicScript logic;
    public AudioSource hitSound;
    public float destroyDelay = 3f;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        StartCoroutine(DestroyAfterDelay());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitSound != null)
        {
            hitSound.Play();
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            if (logic != null)
            {
                logic.addScore(2);

            }
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
