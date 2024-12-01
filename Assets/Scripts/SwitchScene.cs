using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Scene.01.01.Hall");
    }
}
