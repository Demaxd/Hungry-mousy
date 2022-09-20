using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsUI : MonoBehaviour
{
    [SerializeField]
    GameObject _menuUI;

    public void Open()
    {
        _menuUI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Close()
    {
        _menuUI.SetActive(true);
        gameObject.SetActive(false);
    }
}