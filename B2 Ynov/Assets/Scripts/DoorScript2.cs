using UnityEngine;

public class DoorScript2 : MonoBehaviour
{

    public GameObject Door;

    public GameObject StartRotation, EndRotation;

    private bool _IsPlayerInTrigger = false;
    private float _timer = 0;

    void Update()
    {
        if (_IsPlayerInTrigger)
        {
            Door.transform.rotation = Quaternion.Lerp(
                StartRotation.transform.rotation,
                EndRotation.transform.rotation, _timer /4  );
            _timer += Time.deltaTime;
        }
        else
        {
            Door.transform.rotation = Quaternion.Lerp(
                EndRotation.transform.rotation,
                StartRotation.transform.rotation, _timer /4);
            _timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _IsPlayerInTrigger = true;
        _timer = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        _IsPlayerInTrigger = false;
        _timer = 0;

    }
}
