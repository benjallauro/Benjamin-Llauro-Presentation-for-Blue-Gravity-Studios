using System.Collections.Generic;
using UnityEngine;

public class PlayerDressing : MonoBehaviour
{
    [Header("Clothes")]
    [SerializeField] private SpriteRenderer shirt;
    [SerializeField] private SpriteRenderer[] pants;
    [SerializeField] private SpriteRenderer[] shoes;

    //Wearing clothes
    private int shirtOnId;
    private int pantsOnId;
    private int shoesOnId;

    public void Change(ProductData productData)
    {
        OwnedProduct ownedProduct = new OwnedProduct();
        ownedProduct.SetId(productData.id);
        ownedProduct.SetCategory(productData.category);
        Change(ownedProduct, true, productData);
    }
    public void Change(OwnedProduct product, bool firstDressup, ProductData dataforFirstDressup = null)
    {
        switch(product.GetCategory())
        {
            case "Shirt":
                if (firstDressup)
                    ChangeShirt(dataforFirstDressup.sprite);
                else
                    ChangeShirt(product.GetSprite());
                shirtOnId = product.GetId();
                break;
            case "Pants":
                if (firstDressup)
                    ChangePants(dataforFirstDressup.sprite);
                else
                    ChangePants(product.GetSprite());
                pantsOnId = product.GetId();
                break;
            case "Shoes":
                if (firstDressup)
                    ChangeShoes(dataforFirstDressup.sprite);
                else
                    ChangeShoes(product.GetSprite());
                shoesOnId = product.GetId();
                break;
        }
        GameData.instance.UpdateClothesMenus();
    }
    #region Individual change methods
    public void ChangeShirt(Sprite newShirt)
    {
        shirt.sprite = newShirt;
    }
    public void ChangePants(Sprite newPants)
    {
        foreach (SpriteRenderer current in pants)
            current.sprite = newPants;
    }
    public void ChangeShoes(Sprite newShoes)
    {
        foreach (SpriteRenderer current in shoes)
            current.sprite = newShoes;
    }
    #endregion

    public List<int> GetClothesIDs()
    {
        List<int> clothesIDs = new List<int>();
        clothesIDs.Add(shirtOnId);
        clothesIDs.Add(pantsOnId);
        clothesIDs.Add(shoesOnId);
        return clothesIDs;
    }
}