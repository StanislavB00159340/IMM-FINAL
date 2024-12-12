using UnityEngine;

public class BorderDelete : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Destroy any object that enters the trigger
        if (other.tag == "Bullet" || other.tag == "EnemyBullet")
        {
              Destroy(other.gameObject);
        }

      
    }
}

