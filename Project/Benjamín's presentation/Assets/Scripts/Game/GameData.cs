using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    [SerializeField] private ShopClothesManager shopClothesManager;
    [SerializeField] private int startingCash;
    [SerializeField] private PlayerDressing playerDressing;

    [Header("Clothing menus")]
    [SerializeField] private ShowShopStock storeBuySection;
    [SerializeField] private ShowPlayerStock storeSellSection;
    [SerializeField] private ShowPlayerClothes playerClothesMenu;

    [Header("Dialog types")]
    [SerializeField] private Dialogue dialoge;
    public int cash { set; get; }
    private int _id = 0;

    private List<ProductData> ownedShirts;
    private List<ProductData> shirtsInStock;

    private List<ProductData> ownedPants;
    private List<ProductData> pantsInStock;

    private List<ProductData> ownedShoes;
    private List<ProductData> shoesInStock;

    #region Unity functions
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ownedShirts = new List<ProductData>();
            shirtsInStock = new List<ProductData>();
            ownedPants = new List<ProductData>();
            pantsInStock = new List<ProductData>();
            ownedShoes = new List<ProductData>();
            shoesInStock = new List<ProductData>();

            for (int i = 0; i < shopClothesManager.shirts.Length; i++)
            {
                ProductData currentProduct = new ProductData();
                currentProduct.id = _id;
                currentProduct.sprite = shopClothesManager.shirts[i];
                currentProduct.category = "Shirt";
                currentProduct.price = shopClothesManager.shirtPrices[i];
                shirtsInStock.Add(currentProduct);
                _id++;
            }
            for (int i = 0; i < shopClothesManager.pants.Length; i++)
            {
                ProductData currentProduct = new ProductData();
                currentProduct.id = _id;
                currentProduct.sprite = shopClothesManager.pants[i];
                currentProduct.category = "Pants";
                currentProduct.price = shopClothesManager.pantsPrices[i];
                pantsInStock.Add(currentProduct);
                _id++;
            }
            for (int i = 0; i < shopClothesManager.shoes.Length; i++)
            {
                ProductData currentProduct = new ProductData();
                currentProduct.id = _id;
                currentProduct.sprite = shopClothesManager.shoes[i];
                currentProduct.category = "Shoes";
                currentProduct.price = shopClothesManager.shoesPrices[i];
                shoesInStock.Add(currentProduct);
                _id++;
            }
        }
    }
    private void Start()
    {
        cash = startingCash;
        UiManager.instance.UpdateText();
        UpdateClothesMenus();
        BuyProduct(shirtsInStock[0].id, "Shirt", true, true);
        BuyProduct(pantsInStock[0].id, "Pants", true, true);
        BuyProduct(shoesInStock[0].id, "Shoes", true, true);
        playerDressing.Change(ownedShirts[0]);
        playerDressing.Change(ownedPants[0]);
        playerDressing.Change(ownedShoes[0]);
    }
    #endregion

    #region Getters
    public List<ProductData> GetShirtsInStock() { return shirtsInStock; }
    public List<ProductData> GetPantsInStock() { return pantsInStock; }
    public List<ProductData> GetShoesInStock() { return shoesInStock; }
    public List<ProductData> GetOwnedShirts() { return ownedShirts; }
    public List<ProductData> GetOwnedPants() { return ownedPants; }
    public List<ProductData> GetOwnedShoes() { return ownedShoes; }
    #endregion

    #region Buy and Sell products
    public bool BuyProduct(int id, string category, bool free, bool startingGame = false)
    {
        switch(category)
        {
            case "Shirt":

                for(int i = 0; i < shirtsInStock.Count; i++)
                {
                    if (shirtsInStock[i].id == id && (cash >= shirtsInStock[i].price || free))
                    {
                        shirtsInStock[i].owned = true;
                        ownedShirts.Add(shirtsInStock[i]);
                        ChangeCash(-shirtsInStock[i].price);
                        shirtsInStock.Remove(shirtsInStock[i]);
                        storeBuySection.ShowStock();
                        storeSellSection.ShowStock();
                        UpdateClothesMenus();
                        if(!startingGame)
                            dialoge.NextLine(true);
                        return true;
                    }
                }
                break;
            case "Pants":
                for (int i = 0; i < pantsInStock.Count; i++)
                {
                    if (pantsInStock[i].id == id && (cash >= pantsInStock[i].price || free))
                    {
                        pantsInStock[i].owned = true;
                        ownedPants.Add(pantsInStock[i]);
                        ChangeCash(-pantsInStock[i].price);
                        pantsInStock.Remove(pantsInStock[i]);
                        storeBuySection.ShowStock();
                        storeSellSection.ShowStock();
                        UpdateClothesMenus();
                        if (!startingGame)
                            dialoge.NextLine(true);
                        return true;
                    }
                }
                break;
            case "Shoes":
                for (int i = 0; i < shoesInStock.Count; i++)
                {
                    if (shoesInStock[i].id == id && (cash >= shoesInStock[i].price || free))
                    {
                        shoesInStock[i].owned = true;
                        ownedShoes.Add(shoesInStock[i]);
                        ChangeCash(-shirtsInStock[i].price);
                        shoesInStock.Remove(shoesInStock[i]);
                        storeBuySection.ShowStock();
                        storeSellSection.ShowStock();
                        UpdateClothesMenus();
                        if (!startingGame)
                            dialoge.NextLine(true);
                        return true;
                    }
                }
                break;
        }
        return false;
    }

    public bool SellProduct(int id, string category)
    {
        switch (category)
        {
            case "Shirt":

                for (int i = 0; i < ownedShirts.Count; i++)
                {
                    if (ownedShirts[i].id == id)
                    {
                        ownedShirts[i].owned = false;
                        shirtsInStock.Add(ownedShirts[i]);
                        ChangeCash(ownedShirts[i].price);
                        ownedShirts.Remove(ownedShirts[i]);
                        storeBuySection.ShowStock();
                        storeSellSection.ShowStock();
                        UpdateClothesMenus();
                        dialoge.NextLine(false);
                        return true;
                    }
                }
                break;
            case "Pants":
                for (int i = 0; i < ownedPants.Count; i++)
                {
                    if (ownedPants[i].id == id)
                    {
                        ownedPants[i].owned = false;
                        pantsInStock.Add(ownedPants[i]);
                        ChangeCash(ownedPants[i].price);
                        ownedPants.Remove(ownedPants[i]);
                        storeBuySection.ShowStock();
                        storeSellSection.ShowStock();
                        UpdateClothesMenus();
                        dialoge.NextLine(false);
                        return true;
                    }
                }
                break;
            case "Shoes":
                for (int i = 0; i < ownedShoes.Count; i++)
                {
                    if (ownedShoes[i].id == id )
                    {
                        ownedShoes[i].owned = false;
                        shoesInStock.Add(ownedShoes[i]);
                        ChangeCash(ownedShoes[i].price);
                        ownedShoes.Remove(ownedShoes[i]);
                        storeBuySection.ShowStock();
                        storeSellSection.ShowStock();
                        UpdateClothesMenus();
                        dialoge.NextLine(false);
                        return true;
                    }
                }
                break;
        }
        return false;
    }
    #endregion

    public void ChangeCash(int amount)
    {
        cash += amount;
        UiManager.instance.UpdateText();
    }

    public void UpdateClothesMenus()
    {
        storeBuySection.ShowStock();
        storeSellSection.ShowStock();
        playerClothesMenu.ShowClothes();
    }
}