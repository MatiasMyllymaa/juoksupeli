using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnClick_Settings()
    {
        MenuManager.OpenMenu(Menu.SETTINGS, gameObject);
    }
    public void OnClick_Shop() 
    {
        MenuManager.OpenMenu(Menu.SHOP, gameObject);
    }
    public void OnClick_Exit()
    {
        MenuManager.OpenMenu(Menu.EXIT, gameObject);
    }
}
