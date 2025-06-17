using System.Collections.Generic;
using UnityEngine;

public class RandomPickup : MonoBehaviour
{
    [SerializeField] List<GameObject> pickups = new List<GameObject>();


    float finalTimer = 13.8f;
    float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= finalTimer)
        {
            // Instantiate(pickups[Random.Range(0, pickups.Count)], transform.position, Quaternion.identity);
        }
    }
}
