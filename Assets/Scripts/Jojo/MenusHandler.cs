using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenusHandler : MonoBehaviour
{
    

    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;

    [Header("PlayAnim")] 
    [SerializeField] private List<Button> buttons;
    [SerializeField] private float playAnimationDuration;
    [SerializeField] private float buttonAnimationDuration;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject titlePanel;

    private const string LoadGame = "LoadGameScene", GameOptions = "LoadOptions", GameCredits = "LoadCredits";
    private const string ReturnOptionsToMenu = "OptionsToMain", ReturnCreditsToMenu = "CreditsToMain";

    #region Buttons
    public void PlayButton()
    {
        Invoke(LoadGame, playAnimationDuration);

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        
        titlePanel.SetActive(false);
        
        anim.Play("DoorPlay");
    }

    public void OptionsButton() => Invoke(GameOptions, buttonAnimationDuration);

    public void CreditsButton() => Invoke(GameCredits, buttonAnimationDuration);

    public void ReturnButton_OptionsMain() => Invoke(ReturnOptionsToMenu, buttonAnimationDuration);

    public void ReturnButton_CreditsMain() => Invoke(ReturnCreditsToMenu, buttonAnimationDuration);
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