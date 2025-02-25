using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float MoveSpeed;
    public float RotationSpeed;
    public float JumpHeight;

    private int _objectsUnderPlayer;

    void Update()
    {
        //Gestion de la rotation en fonction des mouvements de souris sur l'axe X
        transform.Rotate(new Vector3(0, Input.mousePositionDelta.x * RotationSpeed ,0));

        //Calcul de la nouvelle vitesse en fontion des Axes (zqsd et fleches)
        Vector3 CurrentSpeed = 
            transform.forward * Input.GetAxis("Vertical") * MoveSpeed + 
            transform.right * Input.GetAxis("Horizontal") * MoveSpeed;

        CurrentSpeed.y = GetComponent<Rigidbody>().linearVelocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && _objectsUnderPlayer > 0)
        {
            CurrentSpeed.y += JumpHeight;
        }

        GetComponent<Rigidbody>().linearVelocity = CurrentSpeed;

    }

    public void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0,1000,0));  
    }

    private void OnTriggerEnter(Collider other)
    {
        _objectsUnderPlayer++;
    }
    private void OnTriggerExit(Collider other)
    {
        _objectsUnderPlayer--;
    }
}
