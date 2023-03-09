using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnedProduct : MonoBehaviour
{
    Image _image;
    private int _id = -1;
    private string _category;
    public void SetSprite(Sprite sprite)
    {
        _image = GetComponent<Image>();
        _image.sprite = sprite;
    }
    #region Getters and Setters
    public string GetCategory() { return _category; }
    public Sprite GetSprite(){ return _image.sprite; }
    public int GetId() { return _id; }
    public void SetId(int id) { _id = id; }
    public void SetCategory(string category){ _category = category; }
    #endregion
}