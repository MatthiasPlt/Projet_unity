using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float BumperPower;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, BumperPower, 0));
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
