using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public logicScript logic;
    public AudioSource hitSound;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
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

            if (logic != null)
            {
                logic.addScore(2);
                StartCoroutine(ShowsScoreAddKillMonsterScreen());
            }
            Destroy(gameObject);
        }
    }
    IEnumerator ShowsScoreAddKillMonsterScreen()
    {
        logic.scroreIncreaseKillMonster();
        yield return new WaitForSeconds(1f);
        logic.scroreIncreaseKillMonsterScreen.SetActive(false);
    }

}
