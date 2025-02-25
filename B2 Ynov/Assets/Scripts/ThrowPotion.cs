using UnityEngine;

public class ThrowPotion : MonoBehaviour
{

    public GameObject PrefabPotion;
    public float PotionThrowPower;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject potion = Instantiate(PrefabPotion);
            potion.transform.position = transform.position + new Vector3(0,2,0);
            potion.GetComponent<Rigidbody>().AddForce(transform.forward * PotionThrowPower);
        }
    }
}
