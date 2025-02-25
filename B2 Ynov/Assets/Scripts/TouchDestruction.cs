using UnityEngine;

public class TouchDestruction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        if ( collision.gameObject.tag != "Player" && collision.gameObject.tag != "Potion")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
