using UnityEngine;
using UnityEngine.UI; // Needed for working with UI components like sliders

public class EnemyBullet : MonoBehaviour
{
   
    public float speed = 10f; // Speed of the bullet
    public float damage = 10f; // Damage dealt to the player

    // Update is called once per frame
    void Update()
    {
        // Move the bullet forward in its local space
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Try to find a HealthManager or Slider component on the player
            HEALTH healthManager = other.GetComponent<HEALTH>();

            if (healthManager != null)
            {
                // Reduce the player's health
                healthManager.TakeDamage(damage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
