using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    const string PLAYER_STRING = "Player";


    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActivateWeapon activateWeapon = other.GetComponentInChildren<ActivateWeapon>();
            OnPickup(activateWeapon);
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnPickup(ActivateWeapon activateWeapon);
}
