using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMain : MonoBehaviour
{
    [UsedImplicitly]
    public void Return()
    {
        Invoke(nameof(Quit), 0.4f);
    }

    private void Quit()
    {
        SceneManager.LoadScene(0);
    }
}