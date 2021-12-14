using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReloadLevel : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
