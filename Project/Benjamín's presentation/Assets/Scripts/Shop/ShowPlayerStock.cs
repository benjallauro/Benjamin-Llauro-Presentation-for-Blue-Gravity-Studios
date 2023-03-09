using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerStock : MonoBehaviour
{
    private List<ProductData> productDatas;
    [SerializeField] private GameObject productUiPrefab;
    [SerializeField] private PlayerDressing playerDressing;

    private void Start()
    {
        ShowStock();
    }
    public void ShowStock()
    {
        ResetVisuals();
        productDatas = new List<ProductData>();

        List<ProductData> productsToAdd = new List<ProductData>();

        foreach (ProductData current in GameData.instance.GetOwnedShirts())
            productsToAdd.Add(current);
        PrepareStock(productsToAdd);
        productsToAdd.Clear();

        foreach (ProductData current in GameData.instance.GetOwnedPants())
            productsToAdd.Add(current);
        PrepareStock(productsToAdd);
        productsToAdd.Clear();

        foreach (ProductData current in GameData.instance.GetOwnedShoes())
            productsToAdd.Add(current);
        PrepareStock(productsToAdd);
        productsToAdd.Clear();
    }

    private void PrepareStock(List<ProductData> productsToAdd)
    {
        while (productsToAdd != null && productsToAdd.Count > 0)
        {
            productDatas.Add(productsToAdd[0]);
            productsToAdd.RemoveAt(0);
        }
        foreach (ProductData currentProductFromGameData in productDatas)
        {
            AddObject(currentProductFromGameData);
        }
        productDatas.Clear();
    }
    private void AddObject(ProductData currentProductFromGameData)
    {
        bool sellable = true;
        foreach(int current in playerDressing.GetClothesIDs())
        {
            if(currentProductFromGameData.id == current)
            {
                sellable = false;
            }    
        }
        GameObject obj = Instantiate(productUiPrefab, transform);
        Product objProduct = obj.AddComponent<Product>();
        Image objectImage = obj.GetComponentInChildren<Image>();
        objectImage.sprite = currentProductFromGameData.sprite;
        objProduct.SetId(currentProductFromGameData.id);
        objProduct.SetCategory(currentProductFromGameData.category);
        objProduct.SetPrice(currentProductFromGameData.price);
        if (sellable)
        {
            obj.GetComponent<Button>().onClick.AddListener(objProduct.Sell);
            objProduct.TurnBlockedImageOn(false);
        }
        else
        {
            objProduct.TurnBlockedImageOn(true);
        }
    }
    private void ResetVisuals()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}