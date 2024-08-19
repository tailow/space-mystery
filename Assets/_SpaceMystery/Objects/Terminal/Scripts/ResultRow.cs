using UnityEngine;
using UnityEngine.UI;

public class ResultRow : MonoBehaviour
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color defaultColor;

    public string[] Values;

    private void Start()
    {
        foreach (Transform column in transform)
        {
            column.GetComponent<Image>().color = defaultColor;
        }
    }

    public void Select()
    {
        foreach (Transform column in transform)
        {
            column.GetComponent<Image>().color = selectedColor;
        }
    }

    public void Deselect()
    {
        foreach (Transform column in transform)
        {
            column.GetComponent<Image>().color = defaultColor;
        }
    }
}
