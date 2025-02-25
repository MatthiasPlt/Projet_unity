using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public GameObject difficultyPanel; // Panel du menu de difficult�
    public TimerUi timerUi; // R�f�rence au timer
    public ChestSpawner chestSpawner; // R�f�rence au spawner de coffres

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0; // Met le jeu en pause au d�but
    }

    public void SetDifficulty(float spawnRate)
    {
        Debug.Log(" Bouton cliqu� ! Difficult� choisie : " + spawnRate); // Debug ici

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



