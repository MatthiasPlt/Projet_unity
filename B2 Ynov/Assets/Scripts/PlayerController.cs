using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;

    private int ObjectsUnderPlayer = 0;

    public Vector3 CheckPointPosition;

    void Update()
    {
        

        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-Speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.Z))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0,Speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -Speed * Time.deltaTime));
        }

        if (ObjectsUnderPlayer>0 && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpHeight, 0));
        }

        if (Input.GetKey(KeyCode.R))
        {
            gameObject.GetComponent<Transform>().position = CheckPointPosition;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        ObjectsUnderPlayer++;
    }
    private void OnTriggerExit(Collider other)
    {
        ObjectsUnderPlayer--;
    }
}
