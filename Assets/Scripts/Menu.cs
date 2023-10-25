using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "gameScene";

    // Start is called before the first frame update
    public void StartGame()
    {
       SceneManager.LoadScene(gameSceneName); 
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

}
