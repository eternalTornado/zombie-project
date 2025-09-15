using System;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public Transform[] SpawnPoints;
    public GameObject normalZombiePrefab;
    public GameObject bossZombiePrefab;
    public int bossZombieInterval = 5;
    private int normalZombieCount = 0;

    private void OnEnable()
    {
        EventManager.GameStarted += OnGameStarted;
        EventManager.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        EventManager.GameStarted -= OnGameStarted;
        EventManager.EnemyKilled -= OnEnemyKilled;
    }

    private void OnGameStarted()
    {
        SpawnZombie();
    }

    private void OnEnemyKilled()
    {
        throw new NotImplementedException();
    }

    private void SpawnZombie()
    {
        if (normalZombieCount < bossZombieInterval)
        {
            GameObject normalZombie = SpawnManager.Instance.GetNormalZombie();
            normalZombie.transform.position = GetRandomSpawnPoint();
            normalZombie.SetActive(true);
            normalZombieCount++;
        }
        else
        {
            GameObject bossZombie = SpawnManager.Instance.GetBossZombie();
            bossZombie.transform.position = GetRandomSpawnPoint();
            bossZombie.SetActive(true);
            normalZombieCount = 0;
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        int randomIndex = UnityEngine.Random.Range(0, SpawnPoints.Length);
        return SpawnPoints[randomIndex].position;
    }
}
