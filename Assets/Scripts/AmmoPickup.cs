using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoAmount = 100;

    protected override void OnPickup(ActivateWeapon activateWeapon)
    {
        activateWeapon.AdjustAmmo(ammoAmount);
    }
}
