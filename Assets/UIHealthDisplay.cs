using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;

    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInitialized += OnHealthInitialized;
    }

    public void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
    }

    public void OnHealthInitialized(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }
}
