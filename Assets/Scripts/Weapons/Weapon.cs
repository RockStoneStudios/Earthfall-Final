
using Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  
    
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] AudioClip audioShoot;
    CinemachineImpulseSource impulseSource;


    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }



    public void Shoot(WeaponScriptable weapon)
    {

        muzzleFlash.Play();
        impulseSource.GenerateImpulse();
        AudioManager.Instance.PlaySFX(audioShoot);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            
            Instantiate(weapon.HitVFX, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weapon.Damage);


        }
    }


    
}
