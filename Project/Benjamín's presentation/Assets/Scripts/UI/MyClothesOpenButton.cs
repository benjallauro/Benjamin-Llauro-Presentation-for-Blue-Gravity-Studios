using UnityEngine;
using UnityEngine.UI;

public class MyClothesOpenButton : MonoBehaviour
{
    [SerializeField] private Button button;

    [Header("Player clothes menu")]
    [SerializeField] private GameObject playerClothesMenuObject;
    [SerializeField] private ShowPlayerClothes playerClothesMenu;

    [Header("Button Image and sprites")]
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite openedSprite;
    [SerializeField] private Sprite closedSprite;
    private void Start()
    {
        button.onClick.AddListener(ButtonPressed);
    }
    public void ButtonPressed()
    {
        if (playerClothesMenuObject.activeSelf)
        {
            buttonImage.sprite = closedSprite;
            playerClothesMenuObject.SetActive(false);
        }
        else
        {
            buttonImage.sprite = openedSprite;
            playerClothesMenuObject.SetActive(true);
            playerClothesMenu.ShowClothes();
        }
    }
}
