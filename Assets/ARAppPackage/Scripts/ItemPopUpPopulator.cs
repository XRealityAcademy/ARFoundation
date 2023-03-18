using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemPopUpPopulator : MonoBehaviour
{
    [SerializeField] private ScrollMenu itemMenu;

    [SerializeField] private Image itemPreview;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI info1Text;
    [SerializeField] private TextMeshProUGUI info2Text;
    
    public void Populate()
    {
        var item = itemMenu.SelectedItem;

        itemPreview.sprite = item.Data.itemPreview;

        if (item.Data.itemPreview != null)
        {
            var text = itemPreview.sprite.texture;
            var rectTrans = itemPreview.GetComponent<RectTransform>();
            float rate = (float)text.width / text.height;
            
            rectTrans.sizeDelta = new Vector2(rectTrans.rect.height * rate, rectTrans.rect.height);
        }
        
        nameText.text = item.Data.itemName;
        info1Text.text = item.Data.info1;
        info2Text.text = item.Data.info2;
    }
}
