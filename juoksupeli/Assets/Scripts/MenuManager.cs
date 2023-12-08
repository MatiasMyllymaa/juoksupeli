using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }
    public static GameObject mainMenu, settingsMenu, shopMenu;
    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        shopMenu = canvas.transform.Find("ShopMenu").gameObject;
        

        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if(!IsInitialised)
            Init();
        switch(menu)
        {
            case Menu.PLAY:
                LoadGameScene();
                break;
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            case Menu.SHOP:
                shopMenu.SetActive(true);
                break;
            case Menu.EXIT:
                Application.Quit();
                break;
        }

        callingMenu.SetActive(false);
    }
    private static void LoadGameScene()
    {
        string gameSceneName = "GameScene";
        Scene currentScene = SceneManager.GetActiveScene();

        // Only load the scene if the current scene is not the game scene
        if (currentScene.name != gameSceneName)
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            // If the scene is already loaded, unload and then load again
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
