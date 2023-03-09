using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BlockedIcon : MonoBehaviour
{
    public void TurnBlockedImageOn(bool on)
    {
        GetComponent<Image>().enabled = on;
    }
}
