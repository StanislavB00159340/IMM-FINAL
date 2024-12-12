using UnityEngine;

namespace Course_Library._Source_Files.Script.Powerups
{
    public class PowerupDisplay : MonoBehaviour
    {   
        public string selectedPowerup;
        public string[] powerups = new string[6]; // Array to hold available power-ups
        private string[] powerupNames = { "balenciaga", "Big Red Boots", "Gucci", "jordans", "northface", "oakley", "rayban" };

        public Animator powerupAnimator; // Reference to the Animator component

        private void Start()
        {
            // Populate the `powerups` array with random names
            for (int i = 0; i < powerups.Length; i++)
            {
                powerups[i] = powerupNames[Random.Range(0, powerupNames.Length)];
            }

            // Randomly select one from the `powerups` array
             selectedPowerup = ChooseRandomPowerup();

            // Play the animation for the selected power-up
            PlayPowerupAnimation(selectedPowerup);
        }

        private string ChooseRandomPowerup()
        {
            // Randomly select one from the available power-ups
            int randomIndex = Random.Range(0, powerups.Length);
            string chosenPowerup = powerups[randomIndex];
            Debug.Log($"Chosen Powerup: {chosenPowerup}");
            return chosenPowerup;
        }

        private void PlayPowerupAnimation(string powerupName)
        {
            // Play the animation matching the power-up name
            if (powerupAnimator != null)
            {
                powerupAnimator.Play(powerupName);
            }
            else
            {
                Debug.LogWarning("Powerup Animator is not assigned!");
            }
        }
    }
}
