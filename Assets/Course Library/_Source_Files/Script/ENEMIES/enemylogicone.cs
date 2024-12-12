using UnityEngine;
using UnityEngine.AI;

public class EnemyLogicOne : MonoBehaviour
{
    private Transform player; // Reference to the player's transform
    private NavMeshAgent agent; // Reference to the NavMeshAgent component

    private void Start()
    {
        // Get the NavMeshAgent component attached to this GameObject
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing on this GameObject.");
        }

        // Find the player dynamically by tag
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure the Player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (agent != null && player != null)
        {
            // Set the destination of the NavMeshAgent to the player's position
            agent.SetDestination(player.position);
        }
    }
}
