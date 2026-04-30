using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public string lvlToOpen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(lvlToOpen);
    }
}
