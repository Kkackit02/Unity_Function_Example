using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
        public static Inventory instance;
        public Transform slot;
        public List<Slot> slotScripts = new List<Slot>();
        public GameObject Slot;
       
        // Use this for initialization
        void Start()
        {
                SlotMake(3, 0.06f);


                AddItem(1, 0);
                AddItem(2, 0);
                AddItem(3, 0);
                //AddItem(0, 0);

        }

        public void Add_Bottle()
        {
                AddItem(1, 1);
        }

        public void Add_Heal()
        {
                AddItem(2, 1);
        }
        public void AddSil()
        {
                AddItem(0, 1);
        }

        public void Minus_Bottle()
        {
                AddItem(1, -1);

        }


        public void AddDuru()
        {
                SlotMake(1, 0.06f);
                AddItem(0, 1);
        }
                public void Minus_Heal()
                {
                        AddItem(2, -1);
                }

                void AddItem(int number, int itemCount)
        {
                int sameItemSlotNumber = -1;
                if (ItemDatabase.instance.items[number].itemType != ItemType.Equipment)
                {
                        for (int i = 0; i < slotScripts.Count; i++)
                        {
                                if (slotScripts[i].item.itemName == ItemDatabase.instance.items[number].itemName && slotScripts[i].item.itemCount < 99)
                                {
                                        
                                        sameItemSlotNumber = i;
                                        break;
                                }
                        }
                }

                //Debug.Log("-2");
                if (sameItemSlotNumber == -1)
                {
                        
                        for (int i = 0; i < slotScripts.Count; i++)
                        {

                                if (slotScripts[i].item.itemValue == 0)
                                {
                                        
                                        slotScripts[i].item = ItemDatabase.instance.items[number];
                                        slotScripts[i].item.itemCount += itemCount;
                                        ItemImageChange(slotScripts[i]);
                                        break;
                                }
                        }
                }
                else
                {
                        
                        Item item = ItemDatabase.instance.items[number];
                        item.itemCount += itemCount;
                        slotScripts[sameItemSlotNumber].item = item;
                        ItemImageChange(slotScripts[sameItemSlotNumber]);
                }
        }

        public void ItemImageChange(Slot _slot)
        {
                if (_slot.item.itemValue == 0)
                {
                        
                        _slot.transform.GetChild(0).gameObject.SetActive(false);
                }


                else
                {
                        
                        _slot.transform.GetChild(0).gameObject.SetActive(true);
                        //Debug.Log(_slot.transform.GetChild(0).gameObject);
                        _slot.transform.GetChild(0).GetComponent<Image>().sprite = _slot.item.itemImage;
                        if (_slot.item.itemType != ItemType.Equipment)
                                _slot.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                        else
                                _slot.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                        _slot.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = "" + _slot.item.itemCount;

                }
                
        }




        void SlotMake(int xCount, float xInterval)
        {
                Vector2 panelSize = new Vector2(GetComponent<RectTransform>().rect.width, GetComponent<RectTransform>().rect.height);
                float xWidthRate = (1 - xInterval * (xCount + 1)) / xCount;

                        for (int x = 0; x < xCount; x++)
                        {
                                Transform newSlot = Instantiate(slot);
                                newSlot.name = "Slot" + "." + (x);
                                newSlot.parent = transform;
                                RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                                slotRect.anchorMin = new Vector2(xWidthRate * x + xInterval * (x + 1), 1 );
                                slotRect.anchorMax = new Vector2(xWidthRate * (x + 1) + xInterval * (x + 1), 1);
                                slotRect.offsetMin = Vector2.zero;
                                slotRect.offsetMax = Vector2.zero;

                                slotScripts.Add(newSlot.GetComponent<Slot>());
                                newSlot.GetComponent<Slot>().number = x;

                        }

        }
}