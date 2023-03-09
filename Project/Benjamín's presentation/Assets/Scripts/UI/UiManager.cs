using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Text cashText;
    [SerializeField] private string cashTextBaseText;

    public static UiManager instance;
    //List of owned clothes.

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void UpdateText()
    {
        cashText.text = cashTextBaseText + GameData.instance.cash;
    }
}