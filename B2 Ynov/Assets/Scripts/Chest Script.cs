using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    private void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("PlayerNearChest", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("PlayerNearChest", false);
        }
    }

    public void DestroyChest()
    {
        ScoreManager.instance.AddScore(1); // Ajoute 1 point au score
        Destroy(gameObject); // Détruit le coffre
    }
}
