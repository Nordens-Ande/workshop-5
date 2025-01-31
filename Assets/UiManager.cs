using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private void EnableGameObjects(string name)
    {
        Transform child = transform.Find("Menus");

        if (child.gameObject.activeSelf)
            child.gameObject.SetActive(false);
        else
            child.gameObject.SetActive(true);
    }

    private void OnPauseSettings(ValueInput input)
    {
        EnableGameObjects("Menus");
    }

    public void Resume()
    {
        EnableGameObjects("Menus");
    }

    public void Options()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Graphics()
    {

    }

    public void Audio()
    {

    }

    public void OptionsBack()
    {

    }

}
