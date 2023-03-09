using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text textComponent;
    public string[] buyLines;
    public string[] sellLines;
    public string _firstDialog;
    public float textSpeed;

    private int _index;
    private bool _lastOneWasBuy = false;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialog(true, true);
    }

    void StartDialog(bool buying, bool firstDialog)
    {
        _index = 0;
        StartCoroutine(TypeLine(buying, firstDialog));
    }

    IEnumerator TypeLine(bool buying, bool firstLine)
    {
        string line;
        if (firstLine)
            line = _firstDialog;
        else if (buying)
            line = buyLines[_index];
        else
            line = sellLines[_index];

            foreach (char c in line.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
    }
    public void NextLine(bool buying)
    {
        if(_lastOneWasBuy != buying)
            _index = 0;
        _lastOneWasBuy = buying;
        StopAllCoroutines();
        textComponent.text = string.Empty;
        string[] lines;

        if (buying)
            lines = buyLines;
        else
            lines = sellLines;
        if (_index <= lines.Length - 1)
        {
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(buying, false));
            _index++;
        }
        else
        {
            StartDialog(buying, false);
            _index++;
        }    
    }
}
