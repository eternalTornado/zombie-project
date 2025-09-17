using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f; // Time in seconds before the bullet is deactivated
    private float timer;

    private void OnEnable()
    {
        timer = 0f; // Reset timer when bullet is activated
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            SpawnManager.Instance.ReturnBullet(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Handle collision logic here (e.g., apply damage to target)
        // For now, just deactivate the bullet on collision
        SpawnManager.Instance.ReturnBullet(this.gameObject);
    }
}
