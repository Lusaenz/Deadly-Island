using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject powerupPrefab;
  private float spawanRange = 9.0f;
  public int enemyCount;
  public int waveNumer = 1;
  void Start()
  {
    SpawnEnemyWave(waveNumer);
    Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
  }

  void Update()
  {
    enemyCount = FindObjectsOfType<Enemy>().Length;

    if (enemyCount == 0)
    {
      waveNumer++;
      SpawnEnemyWave(waveNumer);
      Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
  }

  void SpawnEnemyWave(int enemiesToSpawn)
  {
    for (int i = 0; i < enemiesToSpawn; i++)
    {
      Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
  }
  private Vector3 GenerateSpawnPosition()
  {
    float spawanPosX = Random.Range(-spawanRange, spawanRange);
    float spawanPosZ = Random.Range(-spawanRange, spawanRange);

    Vector3 randomPos = new Vector3(spawanPosX, 0, spawanPosZ);
    return randomPos;
  }
}
