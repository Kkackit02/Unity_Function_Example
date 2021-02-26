using UnityEngine;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
        public static ItemDatabase instance;
        public List<Item> items = new List<Item>();

        void Awake()
        {
                instance = this;
                Add("Durumary", 1, 1, "Durumary", ItemType.Equipment, "어스의 비밀이 적힌 두루마리이다.");
                Add("Bottle", 1, 50, "Bottle", ItemType.Consumption, "빈병이다. 던질 수 있을 것 같다.");
                Add("Heal", 1, 50, "Heal", ItemType.Consumption, "체력을 회복 할 수 있다.");
                Add("Bread", 1, 50, "D_Four", ItemType.Consumption, "맛있어 보이는 빵이다.");
                Add("E", 1, 50, "E_Five", ItemType.Consumption, "어스의 비밀들이 담겨져있다.");
                Add("F", 1, 50, "F_Six", ItemType.Consumption, "6번 아이템입니다");
        }

        // Use this for initialization
        void Start()
        {
                //Add("A", 1, 500, "A", ItemType.Equipment);
                //Add("B", 1, 50, "B", ItemType.Consumption);
        }

        //파일 이름, 개수, 가격, 아이템 이름, 아이템 타입
        void Add(string itemName, int itemValue, int itemPrice, string itemDesc, ItemType itemType, string Explanation)
        {
                items.Add(new Item(itemName, itemValue, itemPrice, itemDesc, itemType, 0, Resources.Load<Sprite>("ItemImages/" + itemName) , Explanation));
        }
}