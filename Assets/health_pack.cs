using UnityEngine;

public class health_pack : MonoBehaviour
{
    public float heal = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerHealth>().AddHealth(heal);
        Destroy(gameObject);
    }
}
