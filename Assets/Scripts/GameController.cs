using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int enemyWave;
    public int pickupWave;
    public float enemySpawnTime;
    public float pickupSpawnTime;
    public GameObject enemy;
    public GameObject pickup;

    public Transform topLeft;
    public Transform bottomRight;

    private void Start()
    {
        StartCoroutine(EnemySpawning());
        StartCoroutine(PickupSpawning());
    }

    IEnumerator EnemySpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnTime);
            int toSpawn = enemyWave;
            for (int i = 0; i < toSpawn; i++)
            {
                int num = Random.Range(0, 4);
                switch(num)
                {
                    //spawn top
                    case 0:
                        Vector3 spawnPosition = new Vector3(Random.Range(topLeft.position.x, bottomRight.position.x), topLeft.position.y);
                        GameObject obj = Instantiate(enemy, spawnPosition, Quaternion.identity);
                        break;
                    //spawn left
                    case 1:
                        Vector3 spawnPosition1 = new Vector3(topLeft.position.x, Random.Range(bottomRight.position.y, topLeft.position.y));
                        GameObject obj1 = Instantiate(enemy, spawnPosition1, Quaternion.identity);
                        break;
                    //spawn bottom
                    case 2:
                        Vector3 spawnPosition2 = new Vector3(Random.Range(topLeft.position.x, bottomRight.position.x), bottomRight.position.y);
                        GameObject obj2 = Instantiate(enemy, spawnPosition2, Quaternion.identity);
                        break;
                    //spawn right
                    case 3:
                        Vector3 spawnPosition3 = new Vector3(bottomRight.position.x, Random.Range(bottomRight.position.y, topLeft.position.y));
                        GameObject obj3 = Instantiate(enemy, spawnPosition3, Quaternion.identity);
                        break;
                }
            }
            enemyWave++;
        }
    }

    IEnumerator PickupSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(pickupSpawnTime);
            int toSpawn = pickupWave;
            for (int i = 0; i < toSpawn; i++)
            {
                float spawnPointX = Random.Range(topLeft.position.x + 2, bottomRight.position.x - 2);
                float spawnPointY = Random.Range(bottomRight.position.y + 2, topLeft.position.y - 2);
                Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
                GameObject obj = Instantiate(pickup, spawnPosition, Quaternion.identity);
            }
            pickupWave++;
        }
    }

    public void Restart()
    {
        PlayerController.player.transform.position = PlayerController.player.startPos;
        PlayerController.player.score = 0;
        PlayerController.player.heldPickles = 0;
        PlayerController.player.health = PlayerController.player.maxHealth;
        PlayerController.player.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
