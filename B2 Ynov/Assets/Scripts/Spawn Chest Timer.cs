using UnityEngine;
using System.Collections;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chestPrefab; // Assigner le prefab du coffre dans l'inspecteur
    public Transform spawnPoint; // Position d'apparition du coffre
    public Transform player; // Référence du joueur
    public float spawnInterval = 30f; // Temps entre chaque apparition

    private bool spawning = false;

    public void StartSpawning()
    {
        if (!spawning)
        {
            spawning = true;
            StartCoroutine(SpawnChestRoutine());
        }
    }

    private IEnumerator SpawnChestRoutine()
    {
        while (spawning)
        {
            GameObject newChest = Instantiate(chestPrefab, spawnPoint.position, spawnPoint.rotation);

            // Assigner le joueur au script ChestScript du coffre
            ChestScript chestScript = newChest.GetComponent<ChestScript>();
            if (chestScript != null)
            {
                chestScript.player = player;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
