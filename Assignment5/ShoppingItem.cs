using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class ShoppingItem
    {
        private string description; //description of the item
        private double amount;      //the amount of the same item
        private UnitTypes unit;     //units kg, lb, ft etc.

        //constructor with three parameters
        public ShoppingItem(string name, double amount, UnitTypes unit) //from input: txtDesc, txtAmount, cmbUnits
        {
            this.description = name;
            this.amount = amount;
            this.unit = unit;
        }

        //default constructor with given default values
        public ShoppingItem() : this("Unknown", 1.0, UnitTypes.piece) //default values for description, amount, unit
        {

        }

        //constructor with one parameter, description.
        public ShoppingItem(string name): this(name, 1.0, UnitTypes.piece) //default for amount, unit
        {
            this.description = name;
        }

        //properties for description
        public string Description
        {
            get 
            { 
                return description; 
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    description = value;
                }
            }
        }
        //properties for amount
        public double Amount
        {
            get { return amount; }
            set
            {
                if(amount > 0) //wont accept numbers amount below 1
                {
                    amount = value;
                }
            }
        }
        //properites for unit
        public UnitTypes Unit
        {
            get { return unit; }
            set
            {
                if(Enum.IsDefined(typeof(UnitTypes), value)) //make sure value is defined in enum
                {
                    unit = value;
                }
            }
        }
        //ToString method to present results, with adjusted text, in the listbox
        public override string ToString()
        {
            string textOut = string.Empty;
            textOut = $"{description,-45} {amount,6:f2} {unit,-6}";
            return textOut;
        }
    }
}
