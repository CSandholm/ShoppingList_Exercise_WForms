using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5
{
    public partial class MainForm : Form
    {
        ItemManager itemManager = new ItemManager(); //new itemManager object
        public MainForm()
        {
            InitializeComponent();
            InizializeGUI();
        }

        //initiate GUI/controls
        private void InizializeGUI()
        {
            //fill the combobox with options
            cmbUnits.Items.AddRange(Enum.GetNames(typeof(UnitTypes)));
            //set default unit
            cmbUnits.SelectedIndex = (int)UnitTypes.piece;
        }

        //refresh GUI
        private void UpdateGUI()
        {
            lstItems.Items.Clear();
            lstItems.Items.AddRange(itemManager.GetItemInfoStrings());
        }

        //Add Button: read data, if not correct data an error will display, otherwise data is presented in the ReadInput
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = false;

            ShoppingItem item = ReadInput(out success);
            if (success)
            {
                itemManager.AddItem(item);
                UpdateGUI();
            }
        }

        //method for validating input
        private ShoppingItem ReadInput(out bool success)
        {
            success = false;

            ShoppingItem item = new ShoppingItem();

            //read description
            item.Description = ReadDescription(out success);
            if (!success)
            {
                return null; //abort
            }
            //read amount
            item.Amount = ReadAmount(out success);
            if (!success)
            {
                return null; //abort
            }
            //read unit
            item.Unit = ReadUnit(out success);

            return item;
        }

        //read and validate amount
        private double ReadAmount(out bool success)
        {
            double amount = 0.0;
            success = false;

            if(!double.TryParse(txtAmount.Text, out amount))
            {
                GiveMessage("Wrong amount");
                txtAmount.Focus();
                txtAmount.SelectionStart = 0;
                txtAmount.SelectionLength = txtAmount.TextLength;
            }
            else
            {
                success = true;
            }

            return amount;
        }

        //read and validate unit
        private UnitTypes ReadUnit(out bool success)
        {
            success = false;

            UnitTypes unit = UnitTypes.lb;

            if(cmbUnits.SelectedIndex >= 0)
            {
                success = true;
                unit = (UnitTypes)cmbUnits.SelectedIndex;
            }
            else
            {
                GiveMessage("Wrong unit!");
            }
            return unit;
        }

        //read and validate description
        private string ReadDescription(out bool success)
        {
            success = false;

            string text = txtDesc.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                success = true;
            }
            else{
                GiveMessage("Add a description!");
            }
            return text;
        }

        //method for giving error messages
        private void GiveMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //change button, change the selected index's values for new ones
        private void btnChange_Click(object sender, EventArgs e)
        {

            bool success = false;

            ShoppingItem item = ReadInput(out success);
            if (success)
            {
                itemManager.ChangeItem(item, lstItems.SelectedIndex);
                GiveMessage("Item changed!");
                UpdateGUI();
            }

        }

        //delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstItems.SelectedIndex < 0)
            {
                return;
            }

            //empty textboxes
            txtAmount.Text = "";
            txtDesc.Text = "";
            //delete item object
            itemManager.DeleteItem(lstItems.SelectedIndex);

            UpdateGUI();
            GiveMessage("Item removed!");
        }

        //method for showing selected index's info in textboxes and cmb
        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedIndex < 0)
            {
                return;
            }

            ShoppingItem item = itemManager.GetItem(lstItems.SelectedIndex);
            txtAmount.Text = item.Amount.ToString();
            txtDesc.Text = item.Description;
            cmbUnits.SelectedIndex = (int)item.Unit;
        }
    }
}
