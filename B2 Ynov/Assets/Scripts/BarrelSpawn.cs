using UnityEngine;

public class BarrelSpawn : MonoBehaviour
{

    public GameObject BarrelPrefab;
    public GameObject Player;
    private float _timer = 0;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1 )
        {
            GameObject barrel = Instantiate( BarrelPrefab );
            barrel.transform.position = transform.position;
            _timer = 0;
        }
    }
}
