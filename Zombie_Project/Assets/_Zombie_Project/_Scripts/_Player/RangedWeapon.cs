using UnityEngine;

public class RangedWeapon : MonoBehaviour, IWeapon
{
    public string weaponName = "Weapon Name";
    public float repeatFireRate = 0.5f;
    public Transform firePoint; // Where the bullet will spawn
    public float bulletSpeed = 20f; // Speed of the bullet

    public void Fire()
    {
        // Implement firing logic here
        Debug.Log($"{weaponName} fired from {firePoint.position} with speed {bulletSpeed}");
        //Get a bullet from PoolManager at firePoint position and rotation
        GameObject bullet = SpawnManager.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.SetActive(true);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed; // Move Forward
    }
}
