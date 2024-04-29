using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};

    [SerializeField]
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine() {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f);

        while (true) {
            foreach (float posX in arrPosX) {
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posX, index);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(float posX, int index) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
