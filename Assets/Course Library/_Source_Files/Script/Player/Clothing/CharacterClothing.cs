using UnityEngine;

public class CharacterClothing : MonoBehaviour
{
    // Sprite Renderers for different body parts
    public SpriteRenderer headRenderer;
    public SpriteRenderer torsoRenderer;
    public SpriteRenderer shoesRenderer;

    // Equip clothing dynamically
    public void EquipClothing(string category, string itemName)
    {
        // Construct the path to the sprite
        string path = $"CHARACTER/{category}/{itemName}";

        // Load the sprite from the Resources folder
        Sprite newSprite = Resources.Load<Sprite>(path);

        if (newSprite == null)
        {
            Debug.LogWarning($"Sprite not found at path: {path}");
            return;
        }

        // Apply the sprite to the correct renderer
        switch (category.ToLower())
        {
            case "head":
                headRenderer.sprite = newSprite;
                break;
            case "torso":
                torsoRenderer.sprite = newSprite;
                break;
            case "shoes":
                shoesRenderer.sprite = newSprite;
                break;
            default:
                Debug.LogWarning($"Unknown category: {category}");
                break;
        }
    }

    // Example of equipping items on collision or trigger
    private void OnTriggerEnter(Collider other)
    {
        // Assuming the item has a script with the category and item name
        ItemPickup item = other.GetComponent<ItemPickup>();
        if (item != null)
        {
            EquipClothing(item.category, item.itemName);
            Destroy(other.gameObject); // Remove the item after pickup
        }
    }
}

// A simple script for the pickup items
public class ItemPickup : MonoBehaviour
{
    public string category; // "Head", "Torso", "Shoes"
    public string itemName; // Name of the sprite (e.g., "Hat1", "Jacket2")
}
