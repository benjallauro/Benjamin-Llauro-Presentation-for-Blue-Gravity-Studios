using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowShopStock : MonoBehaviour
{
    private List<ProductData> productDatas;
    [SerializeField] private GameObject productUiPrefab;

    private void Start()
    {
        ShowStock();
    }
    public void ShowStock()
    {
        ResetVisuals();
        productDatas = new List<ProductData>();

        List<ProductData> productsToAdd = new List<ProductData>();

        foreach (ProductData current in GameData.instance.GetShirtsInStock())
            productsToAdd.Add(current);
        PrepareStock(productsToAdd);
        productsToAdd.Clear();

        foreach (ProductData current in GameData.instance.GetPantsInStock())
            productsToAdd.Add(current);
        PrepareStock(productsToAdd);
        productsToAdd.Clear();

        foreach (ProductData current in GameData.instance.GetShoesInStock())
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
            GameObject obj = Instantiate(productUiPrefab, transform);
            Product objProduct = obj.AddComponent<Product>();
            obj.GetComponentInChildren<Image>().sprite = currentProductFromGameData.sprite;
            objProduct.SetId(currentProductFromGameData.id);
            objProduct.SetCategory(currentProductFromGameData.category);
            objProduct.SetPrice(currentProductFromGameData.price);
            obj.GetComponent<Button>().onClick.AddListener(objProduct.Buy);
        }
        productDatas.Clear();
    }
    private void ResetVisuals()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}