using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMenu : MonoBehaviour
{
    [SerializeField] private ARApp arApp;
    [SerializeField] private Transform content;
    [SerializeField] private Transform middle;
    [SerializeField] private float selectedSize;
    [SerializeField] private PlaceObjectOnPlace objectPlacing;
    [SerializeField] private RectTransform selectedIndicator;
    [SerializeField] private TextMeshProUGUI selectedItemDisplay;
    [SerializeField] private TextMeshProUGUI info1Text;
    
    private Transform _closest;

    public ItemCell SelectedItem => _closest.GetComponent<ItemCell>();
    
    private void Awake()
    {
        var prefab = content.GetChild(0).gameObject;
        prefab.SetActive(false);
        
        for (int i = 0; i < arApp.Settings.ItemCount; i++)
        {
            var itemData = arApp.Settings.GetItem(i);

            var itemCell = Instantiate(prefab, content).GetComponent<ItemCell>();
            itemCell.Populate(itemData);
            itemCell.transform.localScale = Vector3.one;
            itemCell.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = float.MaxValue;
        Transform closestObject = null;

        if (_closest != null)
            selectedIndicator.position = _closest.position;
        else
            selectedIndicator.gameObject.SetActive(false);

        for (int i = 1; i < content.childCount; i++)
        {
            
            //check each item from the first one, a list of distance to the screen middle 
            float dist = Mathf.Abs(content.GetChild(i).transform.position.x - middle.position.x);
            
            //if the item distance is less than screen middle
            if (dist < minDistance)
            {
                //screen middle is equal to the item ditance
                minDistance = dist;

                //closestObject.localScale = Vector3.one;
                // assign the closest object to the qualified one
                closestObject = content.GetChild(i);
            }
        }

        if(_closest != closestObject)
        {
            _closest = closestObject;

            OnNewClosestObject(closestObject.GetComponent<ItemCell>());
        }

        closestObject.localScale = new Vector3(selectedSize, selectedSize, selectedSize);


        for (int i = 0; i < content.childCount; i++)
        {
            if (content.GetChild(i) != closestObject)
            {
                content.GetChild(i).localScale = Vector3.one;
            }
        }
       
    }

    public void OnNewClosestObject(ItemCell item)
    {
        selectedItemDisplay.text = item.Data.itemName != "" ? item.Data.itemName : "-";
        info1Text.text = item.Data.info1;
        selectedIndicator.gameObject.SetActive(true);
        objectPlacing.UpdateModel(item.Data.itemPrefab);
    }
}
