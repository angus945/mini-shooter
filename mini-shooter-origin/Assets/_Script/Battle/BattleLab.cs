using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleLab : MonoBehaviour
{
    public static BattleLab instance;

    public GameObject[] enemies { get; private set; }
    public GameObject player { get; private set; }

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        if (enemies == null || enemies.Length == 0) return;
        if (player == null) return;

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
