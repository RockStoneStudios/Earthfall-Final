using System.Collections;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [SerializeField] Transform turrentHead;
    [SerializeField] Transform playerTargetPoint;
    [SerializeField] Transform projectileSpawnPosition;
    [SerializeField] GameObject projectil;
    [SerializeField] float fireRate = 2.1f;
    [SerializeField] int damage = 2;
    PlayerHealth player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }


    void Update()
    {
        turrentHead.LookAt(playerTargetPoint);
    }

    private IEnumerator FireRoutine()
    {
        while (player)
        {
            yield return new WaitForSeconds(fireRate);
            Projectil newProjectile = Instantiate(projectil, projectileSpawnPosition.position, turrentHead.rotation).GetComponent<Projectil>();
            newProjectile.transform.LookAt(playerTargetPoint);
            newProjectile.Init(damage);
        }
    }
}
