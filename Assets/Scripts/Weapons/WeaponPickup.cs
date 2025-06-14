using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponScriptable weaponScriptable;

    const string PLAYER_STRING = "Player";

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag(PLAYER_STRING))
    //     {
    //         ActivateWeapon activateWeapon = other.GetComponentInChildren<ActivateWeapon>();
    //         activateWeapon.SwitchWeapon(weaponScriptable);
    //         Destroy(gameObject);
    //     }
    // }

    protected override void OnPickup(ActivateWeapon activateWeapon)
    {
        activateWeapon.SwitchWeapon(weaponScriptable);
    }
}
