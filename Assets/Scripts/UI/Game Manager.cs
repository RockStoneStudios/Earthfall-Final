using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    int enemies = 0;

    const string ENEMIES_STRING = "Enemies : ";

    public void AdjustEnemies(int amount)
    {
        enemies += amount;
        enemiesLeftText.text = ENEMIES_STRING + enemies.ToString();

        if (enemies <= 0)
        {
            youWinText.SetActive(true);
        }
    }

    public void RestarLevel()
    {
        Debug.Log("Entreee");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Debug.LogWarning("Hello");
        Application.Quit();
    }
}
