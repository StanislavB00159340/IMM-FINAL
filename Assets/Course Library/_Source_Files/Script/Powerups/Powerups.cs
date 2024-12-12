using UnityEngine;

public class Powerups : MonoBehaviour
{
   [Header("Powerup Configuration")]
    public Sprite[] powerupSprites; // Array of PNGs (animations) for power-ups
    public SpriteRenderer spriteHolder; // Reference to SpriteHolder's SpriteRenderer
    public string[] powerupNames; // Names corresponding to each power-up (e.g., "Balenciaga", "Oakley")

    private int currentPowerupIndex; // Tracks the currently active power-up

    private void Start()
    {
        // Select and display a random power-up at the start
        SpawnRandomPowerup();
    }

    public void SpawnRandomPowerup()
    {
        if (powerupSprites.Length == 0 || powerupNames.Length == 0)
        {
            Debug.LogWarning("PowerupSprites or PowerupNames are not set in the inspector!");
            return;
        }

        // Randomly select a power-up
        currentPowerupIndex = Random.Range(0, powerupSprites.Length);

        // Assign the sprite to the SpriteHolder
        if (spriteHolder != null)
        {
            spriteHolder.sprite = powerupSprites[currentPowerupIndex];
        }
        else
        {
            Debug.LogWarning("SpriteHolder is not assigned in the PowerupManager!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player interacts with the power-up
        if (other.CompareTag("Player"))
        {
            // Apply the power-up effect
            string selectedPowerup = powerupNames[currentPowerupIndex];
            Debug.Log($"Player picked up: {selectedPowerup}");

            // Trigger clothing change on the player
            CharacterClothing characterClothing = other.GetComponent<CharacterClothing>();
            if (characterClothing != null)
            {
                ApplyPowerupEffect(characterClothing, selectedPowerup);
            }

            // Respawn a new power-up
            SpawnRandomPowerup();
        }
    }

    private void ApplyPowerupEffect(CharacterClothing characterClothing, string powerupName)
    {
        // Match powerup names to clothing slots and sprites
        switch (powerupName)
        {
            case "Balenciaga":
                characterClothing.EquipClothing("Shoes", "Balenciaga");
                break;

            case "BigRedBoots":
                characterClothing.EquipClothing("Shoes", "BigRedBoots");
                break;

            case "Gucci Jacket":
                characterClothing.EquipClothing("Torso", "GucciJacket");
                break;

            case "NorthFace":
                characterClothing.EquipClothing("Torso", "NorthFaceJacket");
                break;

            case "Oakley":
                characterClothing.EquipClothing("Head", "Oakley");
                break;

            case "Rayban":
                characterClothing.EquipClothing("Head", "Rayban");
                break;

            default:
                Debug.LogWarning($"No effect defined for: {powerupName}");
                break;
        }
    }
}