using UnityEngine;
using UnityEngine.AI;

public class BarrelScript : MonoBehaviour
{
    public int LifePoint;
    private int StartLifePoint;
    public GameObject LifeBar;
    public GameObject FirePrefab;
    public GameObject Animator;

    private bool isDead = false; // Variable pour éviter les points en double

    private void Start()
    {
        StartLifePoint = LifePoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return; // Empêche de prendre des dégâts après la mort

        if (collision.gameObject.CompareTag("Potion"))
        {
            LifePoint--;
            LifeBar.transform.localScale = new Vector3((float)LifePoint / (float)StartLifePoint, 1, 1);

            if (LifePoint <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (isDead) return; // Vérifie si l'objet est déjà mort
        isDead = true;

        ScoreManager.instance.AddScore(1); // Ajoute 1 point au score
        GetComponent<Collider>().enabled = false; // Désactive les collisions
        this.enabled = false; // Désactive le script pour éviter toute interaction future

        Destroy(this.gameObject, 1.5f); // Détruit l'objet après un délai

        GameObject fire = Instantiate(FirePrefab);
        fire.transform.position = transform.position;
        Destroy(fire, 5);
        Animator.GetComponent<Animator>().SetTrigger("IsDead");
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
