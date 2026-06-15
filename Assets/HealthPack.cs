using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float heal = 20;
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerHealth>().AddHealth(heal);
        Destroy(gameObject);
    }
}
