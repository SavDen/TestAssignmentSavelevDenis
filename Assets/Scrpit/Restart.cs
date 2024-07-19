using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
   public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
