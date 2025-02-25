using UnityEngine;
using UnityEngine.AI;

public class BarrelScript : MonoBehaviour
{
    public int LifePoint;
    private int StartLifePoint;
    public GameObject LifeBar;
    public GameObject FirePrefab;
    public GameObject Animator;

    private bool isDead = false; // Variable pour �viter les points en double

    private void Start()
    {
        StartLifePoint = LifePoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return; // Emp�che de prendre des d�g�ts apr�s la mort

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
        if (isDead) return; // V�rifie si l'objet est d�j� mort
        isDead = true;

        ScoreManager.instance.AddScore(1); // Ajoute 1 point au score
        GetComponent<Collider>().enabled = false; // D�sactive les collisions
        this.enabled = false; // D�sactive le script pour �viter toute interaction future

        Destroy(this.gameObject, 1.5f); // D�truit l'objet apr�s un d�lai

        GameObject fire = Instantiate(FirePrefab);
        fire.transform.position = transform.position;
        Destroy(fire, 5);
        Animator.GetComponent<Animator>().SetTrigger("IsDead");
        GetComponent<NavMeshAgent>().enabled = false;
    }
}
