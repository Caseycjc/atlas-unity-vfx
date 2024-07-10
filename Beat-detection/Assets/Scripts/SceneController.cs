using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Method to load the RaveBall scene
    public void LoadRaveBall()
    {
        SceneManager.LoadScene("RaveBall");
    }

    // Method to load the DanceBall scene
    public void LoadDanceBall()
    {
        SceneManager.LoadScene("DanceBall");
    }

    // Method to load the CountryBall scene
    public void LoadCountryBall()
    {
        SceneManager.LoadScene("CountryBall");
    }

    // Method to restart the current game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
