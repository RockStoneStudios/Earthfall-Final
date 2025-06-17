using UnityEngine;

public class EnemieFinal : MonoBehaviour
{
    const string playerTag = "Player";
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] GameObject enemieFinal;
    [SerializeField] GameManager gameManager;
    GameObject[] enemies;
    bool bossDefeated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            enemieFinal.SetActive(true);
            // Encuentra todos los objetos con el tag "Enemy"
            enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            foreach (GameObject enemy in enemies)
            {
                // Asegúrate de no destruir al jefe final si también tiene ese tag
                if (enemy != this.gameObject)
                {
                    Destroy(enemy);
                }
            }

            Debug.Log("¡Todos los enemigos normales han sido destruidos!");
        }
    }


    void Update()
    {
        if (enemieFinal == null)
        {
            gameManager.AdjustEnemies(-1);
            Invoke("QuitGame", 1.2f);

        }
    }
    
    void QuitGame(){
        Application.Quit();
    }
}
