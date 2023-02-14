using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class ItemManager //container class for ShoppingItem objects
    {
        //declare a list object for ShoppingItem
        private List<ShoppingItem> itemList;

        //constructor that creates a list object 
        public ItemManager()
        {
            itemList = new List<ShoppingItem>();
        }

        //method for returning item at index position
        public ShoppingItem GetItem(int index)
        {
            if (!CheckIndex(index))
            {
                return null;
            }
            return itemList[index];
        }

        //method for making sure index isn't out of range, returns false if it is
        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < itemList.Count); //Count is a List method
        }

        //property for returning the amount of items in the list
        public int Count
        {
            get { return itemList.Count; }
        }
        
        //method for adding items to list
        public bool AddItem(ShoppingItem itemIn)
        {
            bool ok = false;
            if(itemIn != null) //if the index position is free to use
            {
                itemList.Add(itemIn);
                ok = true;
            }
            return ok;
        }

        //method for replacing one item with another
        public bool ChangeItem(ShoppingItem itemIn, int index)
        {
            bool ok = false;

            if(CheckIndex(index)) //calling CheckIndex to check index range
            {
                ok = true;
                itemList[index] = itemIn;
            }
            return ok;
        }

        //method for removing an item
        public bool DeleteItem(int index)
        {
            bool ok = false;

            if (CheckIndex(index))
            {
                itemList.RemoveAt(index);
                ok = true;
            }
            return ok;
        }

        //method to make sure every item is represented as a string for the GUI list, this as an array of strings
        public string[] GetItemInfoStrings()
        {
            string [] stringItemInfoStrings = new string[itemList.Count]; //string array size set to amount of items in the list

            int i = 0;
            foreach(ShoppingItem Itemobj in itemList)
            {
                stringItemInfoStrings[i] = Itemobj.ToString();
                i++;
            }

            return stringItemInfoStrings;
        }
    }
}
