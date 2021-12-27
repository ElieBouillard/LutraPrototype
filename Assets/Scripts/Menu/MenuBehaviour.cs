using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuBehaviour : MonoBehaviour
{
    [Header("ButtonReferences")]
    [Header("MainMenu")]
    [SerializeField] private Button _playButton = null;
    [SerializeField] private Button _optionsButton = null;
    [SerializeField] private Button _quitButton = null;
    [Header("OptionsMenu")]
    [SerializeField] private bool _inGameOptions = false;
    [SerializeField] private Slider _mouseSensitivitySlider = null;
    [SerializeField] private TMP_Text _mouseSensitivityText = null;
    [SerializeField] private Button _returnToMainMenuButton = null;
    [SerializeField] private LoadParameters _loadParameters = null;

    [Header("MainMenuSettings")]
    [Space(10)]
    [SerializeField] private GameObject _mainMenuObj = null;
    [SerializeField] private string _sceneNameToLoad = null;

    [Header("OptionsMenuSettings")]
    [Space(20)]
    [SerializeField] private GameObject _optionsMenuObj = null;

    private bool _inGameOptionsMenuIsOpen = false;

    private void OnEnable()
    {
        InitializeStartMenu();

        //MainMenu
        _playButton.onClick.AddListener(OnPlayClick);
        _optionsButton.onClick.AddListener(OnOptionsClick);
        _quitButton.onClick.AddListener(OnQuitClick);

        //OptionsMenu
        _returnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
        _mouseSensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    private void Update()
    {
        InGameOptionsUpdate();
    }

    private void InitializeStartMenu()
    {
        if (_inGameOptions)
        {
            _mainMenuObj.SetActive(false);
            _optionsMenuObj.SetActive(false);
        }
        else
        {
            _mainMenuObj.SetActive(true);
            _optionsMenuObj.SetActive(false);
        }
        OnSensitivityChanged(PlayerPrefs.GetFloat("MouseSensitivity"));
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

    private void OnSensitivityChanged(float value)
    {
        _mouseSensitivityText.text = value.ToString("00.00");
        PlayerPrefs.SetFloat("MouseSensitivity", value);

        if (!_inGameOptions) { return; }
        _loadParameters.LoadMouseSensitivity();
    }

    private void InGameOptionsUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetOptionsMenu(!_inGameOptionsMenuIsOpen);
            _inGameOptionsMenuIsOpen = !_inGameOptionsMenuIsOpen;
        }
    }

    private void SetOptionsMenu(bool value)
    {
        _optionsMenuObj.SetActive(value);

        if (value) { Cursor.lockState = CursorLockMode.None; }
        else { Cursor.lockState = CursorLockMode.Locked; }
    }
    #endregion
}
