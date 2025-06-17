using UnityEngine;

public class HealthAmount : Pickup
{
    [SerializeField] int healAmount = 2;
    protected override void OnPickup(ActivateWeapon activateWeapon)
    {

        PlayerHealth playerHealth = activateWeapon.GetComponentInParent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);
        }
    }
}
