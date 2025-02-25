using UnityEngine;

public class MoveLerpScript : MonoBehaviour
{
    public GameObject StartPos, EndPos;
    private float _timer = 0;
    public AnimationCurve curve;
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        transform.position = Vector3.Lerp(StartPos.transform.position,
            EndPos.transform.position, curve.Evaluate(_timer) );

        //(Mathf.Sin(_timer)+1) /2
    }
}
