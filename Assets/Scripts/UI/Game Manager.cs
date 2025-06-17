using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;
     private bool isPaused = false;
    int enemies = 0;

    const string ENEMIES_STRING = "Enemies : ";

    private void Start()
    {

        GameObject[] enemigosIniciales = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = enemigosIniciales.Length;


        enemiesLeftText.text = ENEMIES_STRING + enemies.ToString();
    }

    public void AdjustEnemies(int amount)
    {
        enemies += amount;
        enemiesLeftText.text = ENEMIES_STRING + enemies.ToString();

        Debug.Log($"Enemigos restantes: {enemies}");

        if (enemies <= 0)
        {
            youWinText.SetActive(true);
        }
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void RestarLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    
    
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            Debug.Log("Juego reanudado");
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            Debug.Log("Juego pausado");
        }
    }

}
