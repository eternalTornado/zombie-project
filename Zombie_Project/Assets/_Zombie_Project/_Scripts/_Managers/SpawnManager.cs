using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public GameObject bulletPrefab;
    public int poolSizeForBullet = 20;
    private Queue<GameObject> bulletPool;
    public GameObject normalZombiePrefab;
    public int poolSizeForNormalZombie = 10;
    private Queue<GameObject> normalZombiePool;
    public GameObject bossZombiePrefab;
    public int poolSizeForBossZombie = 10;
    private Queue<GameObject> bossZombiePool;

    private void Start()
    {
        InitializeBulletPool();
        InitializeNormalZombiePool();
        InitializeNormalBossPool();
    }

    private void InitializeBulletPool()
    {
        bulletPool = new();
        for (int i = 0; i < poolSizeForBullet; i++)
        {
            var bullet = GameObject.Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    /// <summary>
    /// Get a bullet from pool
    /// </summary>
    /// <returns></returns>
    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            return bulletPool.Dequeue();
        }

        //Instantiate new bullet
        return GameObject.Instantiate(bulletPrefab);
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    private void InitializeNormalZombiePool()
    {
        normalZombiePool = new();
        for (int i = 0; i < poolSizeForNormalZombie; i++)
        {
            var normalZombie = Instantiate(bossZombiePrefab);
            normalZombie.SetActive(false);
            normalZombiePool.Enqueue(normalZombie);
        }
    }

    public GameObject GetNormalZombie()
    {
        if (normalZombiePool.Count > 0)
        {
            return normalZombiePool.Dequeue();
        }

        return Instantiate(normalZombiePrefab);
    }

    public void ReturnNormalZombie(GameObject zombie)
    {
        zombie.SetActive(false);
        normalZombiePool.Enqueue(zombie);
    }

    private void InitializeNormalBossPool()
    {
        bossZombiePool = new();
        for (int i = 0; i < poolSizeForBossZombie; i++)
        {
            var bossZombie = GameObject.Instantiate(bossZombiePrefab);
            bossZombie.SetActive(false);
            bossZombiePool.Enqueue(bossZombie);
        }
    }

    public GameObject GetBossZombie()
    {
        if (bossZombiePool.Count > 0) return bossZombiePool.Dequeue();

        return Instantiate(bossZombiePrefab);
    }

    public void ReturnBossZombie(GameObject bossZombie)
    {
        bossZombie.SetActive(false);
        bossZombiePool.Enqueue(bossZombie);
    }
}
