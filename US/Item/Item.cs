using UnityEngine;

public enum ItemType
{
        Equipment,//장비
        Consumption,//소모
        Misc//기타
}
[System.Serializable]
public class Item
{

        public string itemName;
        public int itemValue;
        public int itemPrice;
        public string itemDesc;
        public ItemType itemType;
        public int itemCount;
        public Sprite itemImage;
        public string Explanation;



        public Item(string _itemName, int _itemValue, int _itemPrice, string _itemDesc, ItemType _itemType, int _itemCount, Sprite _itemImage, string _Explanation)
        {
                itemName = _itemName;
                itemValue = _itemValue;
                itemPrice = _itemPrice;
                itemDesc = _itemDesc;
                itemType = _itemType;
                itemCount = _itemCount;
                itemImage = _itemImage;
                Explanation = _Explanation;
        }

    
}