using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    private int _id = -1;
    private string _category;
    private int _price;
    private bool _owned = false;
    public void Buy()
    {
        GameData.instance.BuyProduct(_id, _category, false)/*)*/;
    }
    public void Sell()
    {
        GameData.instance.SellProduct(_id, _category)/*)*/;
    }
    #region Getters and setters
    public void SetId(int id) { _id = id;}
    public void SetCategory(string category) { _category = category; }
    public void SetPrice(int price)
    {
        _price = price;
        GetComponentInChildren<Text>().text = price.ToString();
    }
    public void SetOwned(bool owned) { _owned = owned; }
    public int GetPrice() { return _price; }
    public bool GetOwned() { return _owned; }
    public void TurnBlockedImageOn(bool blockedSprite)
    {
        GetComponentInChildren<BlockedIcon>().TurnBlockedImageOn(blockedSprite);
    }
    #endregion
}