using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleLab : MonoBehaviour
{
    GameObject[] enemies;
    GameObject player;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(CheckAlive());
    }

    IEnumerator CheckAlive()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            bool enemyAlive = false;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] != null) enemyAlive = true;
            }

            bool playerAlive = player != null;

            if (!enemyAlive || !playerAlive)
            {
                break;
            }
        }

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
