using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusHandler : MonoBehaviour
{
    [SerializeField] private float animationDuration;

    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;

    private const string LoadGame = "LoadGameScene", GameOptions = "LoadOptions", QuitGame = "Quit", GameCredits = "LoadCredits";
    private const string ReturnOptionsToMenu = "OptionsToMain", ReturnCreditsToMenu = "CreditsToMain";

    #region Buttons
    public void PlayButton() => Invoke(LoadGame, animationDuration);

    public void OptionsButton() => Invoke(GameOptions, animationDuration);

    public void QuitButton() => Invoke(QuitGame, animationDuration);

    public void CreditsButton() => Invoke(GameCredits, animationDuration);

    public void ReturnButton_OptionsMain() => Invoke(ReturnOptionsToMenu, animationDuration);

    public void ReturnButton_CreditsMain() => Invoke(ReturnCreditsToMenu, animationDuration);
    #endregion

    #region Loading
    [UsedImplicitly]
    private void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    [UsedImplicitly]
    private void LoadOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    [UsedImplicitly]
    private void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Button");
    }

    [UsedImplicitly]
    private void LoadCredits()
    {
        mainMenu.SetActive(false); 
        creditsMenu.SetActive(true);
    }

    [UsedImplicitly]
    private void OptionsToMain()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    [UsedImplicitly]
    private void CreditsToMain()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
}