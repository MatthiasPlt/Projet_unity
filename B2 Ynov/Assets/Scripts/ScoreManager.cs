using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject endGamePanel; // Panneau de fin de partie
    public TMP_Text endGameText; // Texte de fin
    public TimerUi timerUi; // R�f�rence au timer

    private void Awake()
    {
        instance = this;
    }

    private void Start() // Cette fonction doit �tre dans la classe
    {
        endGamePanel.SetActive(false); // D�sactive l'�cran de fin au d�but
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
        // V�rifier si une r�f�rence est null avant d'ex�cuter le code
        if (endGamePanel == null) Debug.LogError(" endGamePanel n'est pas assign� !");
        if (endGameText == null) Debug.LogError(" endGameText n'est pas assign� !");
        if (timerUi == null) Debug.LogError(" timerUi n'est pas assign� !");

        if (endGamePanel == null || endGameText == null || timerUi == null) return; // Stoppe si un objet est manquant

        float finalTime = timerUi.GetTime(); // R�cup�re le temps final
        endGamePanel.SetActive(true); //  Active le panneau de fin
        endGameText.text = "Vous avez gagn� en " + finalTime.ToString("F2") + " secondes !";
        Time.timeScale = 0; //  Met le jeu en pause
    }

}
