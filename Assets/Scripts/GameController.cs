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

    private void Start()
    {
        StartCoroutine(EnemySpawning());
        StartCoroutine(PickupSpawning());
    }

    IEnumerator EnemySpawning()
    {

        enemyWave++;
        yield return new WaitForSeconds(enemySpawnTime);
    }

    IEnumerator PickupSpawning()
    {

        pickupWave++;
        yield return new WaitForSeconds(pickupSpawnTime);
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
