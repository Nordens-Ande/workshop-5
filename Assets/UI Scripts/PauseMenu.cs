using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    bool isPaused;
    GameObject playerObject;
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseStartMenuObject;
    [SerializeField] GameObject menuList;

    private void ToggleGameObjects(string name, bool state)
    {
        Debug.Log(name);
        Transform child = menuList.transform.Find(name);

        child.gameObject.SetActive(state);
        Debug.Log(name + " is: " + child.gameObject.activeSelf);
    }

    private void ToggleGameObjects(Transform child, bool state)
    {
        child.gameObject.SetActive(state);
        Debug.Log(child + " is: " + child.gameObject.activeSelf);
    }


    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        ResetPauseUI();
    }

    public void OnPauseGame(InputValue input)
    {
        if (isPaused)
        {
            UnPauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        ResetPauseUI();

        isPaused = true;
        Time.timeScale = 0;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;

        ToggleGameObjects("Menus", true);
        ToggleGameObjects("Background", true);
        ToggleGameObjects(menuList.transform.Find("Menus").Find("StartMenu"), true);
    }

    public void UnPauseGame()
    {
        ResetPauseUI();

        isPaused = false;
        Time.timeScale = 1;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        //ToggleGameObjects("StartMenu", false);
    }

    public void Options()
    {
        ToggleGameObjects("Menus", true);
        ToggleGameObjects("Background", true);
        ToggleGameObjects(menuList.transform.Find("Menus").Find("OptionsMenu"), true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetPauseUI()
    {
        foreach (Transform child in menuList.transform)
        {
            child.gameObject.SetActive(false);
            Debug.Log(child.gameObject);
        }
        foreach (Transform child in menuList.transform.Find("Menus"))
        {
            child.gameObject.SetActive(false);
            Debug.Log(child.gameObject);
        }
    }

    public void GraphicsMenu()
    {
        ResetPauseUI();

        ToggleGameObjects("Menus", true);
        ToggleGameObjects("Background", true);
        ToggleGameObjects(menuList.transform.Find("Menus").Find("GraphicsMenu"), true);
    }
}
