using System.Collections.Generic;
using UnityEngine;

public class Campos : MonoBehaviour
{
    [SerializeField] List<GameObject> objetos = new List<GameObject>();

    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            foreach (GameObject obj in objetos) {
                obj.SetActive(true);
            }
        }
    }
}
