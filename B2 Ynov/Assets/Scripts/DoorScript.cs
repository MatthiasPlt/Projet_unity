using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject Door1, Door2;
    private float _timer = 0;
    private bool _isPlayerInTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerInTrigger && _timer < 0.5f)
        {
            _timer += Time.deltaTime;
            Door1.transform.Rotate(new Vector3(0, 1, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isPlayerInTrigger = true;
        _timer = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        _isPlayerInTrigger = false;
    }
}
