using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusHandler : MonoBehaviour
{
    [SerializeField] private float animationDuration;

    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;

    private const string LoadGame = "LoadGameScene", LoadGame1 = "LoadGameScene1", GameOptions = "LoadOptions", QuitGame = "Quit", GameCredits = "LoadCredits";
    private const string ReturnOptionsToMenu = "OptionsToMain", ReturnCreditsToMenu = "CreditsToMain";

    #region Buttons
    public void PlayButton() => Invoke(LoadGame, animationDuration);
    public void Play1Button() => Invoke(LoadGame1, animationDuration);

    public void OptionsButton() => Invoke(GameOptions, animationDuration);

    public void QuitButton() => Invoke(QuitGame, animationDuration);

    public void CreditsButton() => Invoke(GameCredits, animationDuration);

    public void ReturnButton_OptionsMain() => Invoke(ReturnOptionsToMenu, animationDuration);

    public void ReturnButton_CreditsMain() => Invoke(ReturnCreditsToMenu, animationDuration);
    #endregion

    #region Loading
    private void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void LoadGameScene1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void LoadOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    private void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Button");
    }

    private void LoadCredits()
    {
        mainMenu.SetActive(false); 
        creditsMenu.SetActive(true);
    }

    private void OptionsToMain()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void CreditsToMain()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
}