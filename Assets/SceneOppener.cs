using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOppener : MonoBehaviour
{
    public string sceneName;
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}