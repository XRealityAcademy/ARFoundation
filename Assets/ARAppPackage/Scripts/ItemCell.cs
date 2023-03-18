using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    public ItemData Data { get; private set; }

    public void Populate(ItemData data)
    {
        Data = data;
        
        var previewImage = transform.GetChild(0).GetComponent<Image>();
        if (previewImage != null)
        {
            previewImage.sprite = Data.itemPreview;
            previewImage.preserveAspect = true;
        }
    }
}
