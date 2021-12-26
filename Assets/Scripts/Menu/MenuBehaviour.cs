using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    [Header("ButtonReferences")]
    [Header("MainMenu")]
    [SerializeField] private Button _playButton = null;
    [SerializeField] private Button _optionsButton = null;
    [SerializeField] private Button _quitButton = null;
    [Header("OptionsMenu")]
    [SerializeField] private Button _returnToMainMenuButton = null;


    [Header("MainMenuSettings")]
    [Space(10)]
    [SerializeField] private GameObject _mainMenuObj = null;
    [SerializeField] private string _sceneNameToLoad = null;

    [Header("OptionsMenuSettings")]
    [Space(20)]
    [SerializeField] private GameObject _optionsMenuObj = null; 

    private void OnEnable()
    {
        InitializeStartMenu();

        //MainMenu
        _playButton.onClick.AddListener(OnPlayClick);
        _optionsButton.onClick.AddListener(OnOptionsClick);
        _quitButton.onClick.AddListener(OnQuitClick);

        //OptionsMenu
        _returnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void InitializeStartMenu()
    {
        _mainMenuObj.SetActive(true);
        _optionsMenuObj.SetActive(false);
    }

    #region MainMenu
    private void OnPlayClick()
    {
        SceneManager.LoadSceneAsync(_sceneNameToLoad);
    }

    private void OnOptionsClick()
    {
        _mainMenuObj.SetActive(false);
        _optionsMenuObj.SetActive(true);
    }

    private void OnQuitClick()
    {
        Application.Quit();
    }
    #endregion

    #region OptionsMenu
    private void ReturnToMainMenu()
    {
        _mainMenuObj.SetActive(true);
        _optionsMenuObj.SetActive(false);
    }
    #endregion
}
