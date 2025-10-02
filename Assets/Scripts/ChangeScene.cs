using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToGame()
    {
        PlayerPrefs.DeleteAll(); 
        SceneManager.LoadScene(1);
    }
}
