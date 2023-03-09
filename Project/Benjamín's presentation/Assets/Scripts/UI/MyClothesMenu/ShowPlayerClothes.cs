using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerClothes : MonoBehaviour
{
    private List<ProductData> productDatas;
    [SerializeField] private GameObject productUiPrefab;
    [SerializeField] private PlayerDressing playerDressing;

    public void ShowClothes()
    {
        ResetVisuals();
        productDatas = new List<ProductData>();
        List<ProductData> productsToAdd = new List<ProductData>();

        foreach (ProductData current in GameData.instance.GetOwnedShirts())
            productsToAdd.Add(current);
        PrepareClothes(productsToAdd);
        productsToAdd.Clear();
        
        foreach (ProductData current in GameData.instance.GetOwnedPants())
            productsToAdd.Add(current);
        PrepareClothes(productsToAdd);
        productsToAdd.Clear();

        foreach (ProductData current in GameData.instance.GetOwnedShoes())
            productsToAdd.Add(current);
        PrepareClothes(productsToAdd);
        productsToAdd.Clear();
    }

    private void PrepareClothes(List<ProductData> productsToAdd)
    {
        while (productsToAdd != null && productsToAdd.Count > 0)
        {
            productDatas.Add(productsToAdd[0]);
            productsToAdd.RemoveAt(0);
        }
        foreach (ProductData currentProductFromGameData in productDatas)
        {
            AddProduct(currentProductFromGameData);
        }
        productDatas.Clear();
    }
    private void AddProduct(ProductData currentProductFromGameData)
    {
        GameObject obj = Instantiate(productUiPrefab, transform);
        OwnedProduct objProduct = obj.AddComponent<OwnedProduct>();
        obj.GetComponent<Image>().sprite = currentProductFromGameData.sprite;
        objProduct.SetId(currentProductFromGameData.id);
        objProduct.SetCategory(currentProductFromGameData.category);
        objProduct.SetSprite(obj.GetComponent<Image>().sprite);
        obj.GetComponent<Button>().onClick.AddListener(() => playerDressing.Change(objProduct, false));
    }
    private void ResetVisuals()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}