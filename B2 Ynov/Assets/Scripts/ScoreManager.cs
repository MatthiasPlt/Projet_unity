using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject endGamePanel; // Panneau de fin de partie
    public TMP_Text endGameText; // Texte de fin
    public TimerUi timerUi; // Référence au timer

    private void Awake()
    {
        instance = this;
    }

    private void Start() // Cette fonction doit être dans la classe
    {
        endGamePanel.SetActive(false); // Désactive l'écran de fin au début
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score : " + score;

        if (score >= 10)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        // Vérifier si une référence est null avant d'exécuter le code
        if (endGamePanel == null) Debug.LogError(" endGamePanel n'est pas assigné !");
        if (endGameText == null) Debug.LogError(" endGameText n'est pas assigné !");
        if (timerUi == null) Debug.LogError(" timerUi n'est pas assigné !");

        if (endGamePanel == null || endGameText == null || timerUi == null) return; // Stoppe si un objet est manquant

        float finalTime = timerUi.GetTime(); // Récupère le temps final
        endGamePanel.SetActive(true); //  Active le panneau de fin
        endGameText.text = "Vous avez gagné en " + finalTime.ToString("F2") + " secondes !";
        Time.timeScale = 0; //  Met le jeu en pause
    }

}
