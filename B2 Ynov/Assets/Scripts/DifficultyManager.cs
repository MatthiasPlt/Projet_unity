using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public GameObject difficultyPanel; // Panel du menu de difficulté
    public TimerUi timerUi; // Référence au timer
    public ChestSpawner chestSpawner; // Référence au spawner de coffres

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0; // Met le jeu en pause au début
    }

    public void SetDifficulty(float spawnRate)
    {
        Debug.Log(" Bouton cliqué ! Difficulté choisie : " + spawnRate); // Debug ici

        chestSpawner.spawnInterval = spawnRate;
        difficultyPanel.SetActive(false);
        timerUi.StartTimer();
        Time.timeScale = 1;
    }

}

public class ButtonTest : MonoBehaviour
{
    public void TestClick()
    {
        Debug.Log(" Le bouton fonctionne !");
    }
}



