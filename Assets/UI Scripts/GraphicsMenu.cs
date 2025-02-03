using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{

    GameObject playerObject;
    Dropdown resolutionDropDown;
    [SerializeField] float mouseSensitivitySlider;
    TextMeshProUGUI sensitivityValueTxt;
    string[] resolutions;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChangeSensitivity()
    {
        float newSenitivity = playerObject.GetComponent<PlayerLook>().mouseSensitivity;
    }
}
