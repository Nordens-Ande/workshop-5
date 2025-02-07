using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;


public class GraphicsMenu : MonoBehaviour
{

    GameObject playerObject;
    [SerializeField] GameObject resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    [SerializeField] TextMeshProUGUI sensitivityValueTxt;
    Resolution[] resolutions;
    bool fullscreen;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");


        float tempSens = playerObject.GetComponent<PlayerLook>().mouseSensitivity;
        sensitivityValueTxt.text = tempSens.ToString();
        mouseSensitivitySlider.value = tempSens/100;

        PopulateResDropdown();

    }

    

    public void ChangeSensitivity()
    {
        int newSenitivity = (int)(100 * mouseSensitivitySlider.value);

        sensitivityValueTxt.text = newSenitivity.ToString();
        playerObject.GetComponent<PlayerLook>().mouseSensitivity = newSenitivity;


    }


    public void ToggleFullscreen()
    {
        fullscreen = !fullscreen;
        Screen.fullScreen = fullscreen;
    }


    public void ChangeResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void PopulateResDropdown()
    {
        int currentResIndex = 0;
        TMP_Dropdown tempDropdwon = resolutionDropDown.GetComponent<TMP_Dropdown>();
        
       
        string[] options;
        resolutions = Screen.resolutions;
        options = new string[resolutions.Length];
        for (int i = 0; i < resolutions.Length; i++) 
        {
            options[i] = resolutions[i].ToString();
            if (options[i] == Screen.currentResolution.ToString())
            {
                currentResIndex = i;
            }
        }

        Debug.Log(options);

        tempDropdwon.ClearOptions();
        tempDropdwon.AddOptions(options.ToList());
        tempDropdwon.value = currentResIndex;
        tempDropdwon.RefreshShownValue();

    }

}
