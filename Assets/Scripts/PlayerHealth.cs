using Cinemachine;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;

    int currentHealth;
    int gameOverVortualCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
    }



    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = gameOverVortualCameraPriority;
            Destroy(this.gameObject);
        }
    }

    void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
