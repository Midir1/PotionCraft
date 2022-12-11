using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusHandler : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;

    [Header("PlayAnim")] 
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private float playAnimationDuration;
    [SerializeField] private float buttonAnimationDuration;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject titlePanel;

    private bool alreadyClicked;

    private const string LoadGame = "LoadGameScene", GameOptions = "LoadOptions", GameCredits = "LoadCredits";
    private const string ReturnOptionsToMenu = "OptionsToMain", ReturnCreditsToMenu = "CreditsToMain";

    #region Buttons
    public void PlayButton()
    {
        if (alreadyClicked) return;
        alreadyClicked = true;
        
        Invoke(LoadGame, playAnimationDuration);

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);
        }
        
        titlePanel.SetActive(false);
        
        anim.Play("DoorPlay");
    }

    public void OptionsButton()
    {
        if (alreadyClicked) return;
        alreadyClicked = true;
        
        Invoke(GameOptions, buttonAnimationDuration);
    }

    public void CreditsButton()
    {
        if (alreadyClicked) return;
        alreadyClicked = true;
        
        Invoke(GameCredits, buttonAnimationDuration);
    }

    public void ReturnButton_OptionsMain()
    {
        if (alreadyClicked) return;
        alreadyClicked = true;
        
        Invoke(ReturnOptionsToMenu, buttonAnimationDuration);
    }

    public void ReturnButton_CreditsMain()
    {
        if (alreadyClicked) return;
        alreadyClicked = true;
        
        Invoke(ReturnCreditsToMenu, buttonAnimationDuration);
    }

    #endregion

    #region Loading
    [UsedImplicitly]
    private void LoadGameScene()
    {
        alreadyClicked = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    [UsedImplicitly]
    private void LoadOptions()
    {
        alreadyClicked = false;
        
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    [UsedImplicitly]
    private void LoadCredits()
    {
        alreadyClicked = false;
        
        mainMenu.SetActive(false); 
        creditsMenu.SetActive(true);
    }

    [UsedImplicitly]
    private void OptionsToMain()
    {
        alreadyClicked = false;
        
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    [UsedImplicitly]
    private void CreditsToMain()
    {
        alreadyClicked = false;
        
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
}