using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopClothesManager", menuName = "Scriptable/ClothesManagers/ShopClothesManager")]
public class ShopClothesManager : ScriptableObject
{
    [Header("Each price corresponds with the product of the same index and category.")]

    [Header("SHIRTS")]
    public Sprite[] shirts = new Sprite[1];
    public int[] shirtPrices = new int[1];
    [Header("PANTS")]
    public Sprite[] pants = new Sprite[1];
    public int[] pantsPrices = new int[1];
    [Header("SHOES")]
    public Sprite[] shoes = new Sprite[1];
    public int[] shoesPrices = new int[1];
}