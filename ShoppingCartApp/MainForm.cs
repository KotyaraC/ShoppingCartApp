using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShoppingCartApp
{
    public partial class MainForm : Form
    {
        private List<OrderItem> shoppingCart;

        public MainForm()
        {
            InitializeComponent(); 
            InitializeTreeView();
            shoppingCart = new List<OrderItem>();

        }

        private void InitializeTreeView()
        {
           
            productTreeView.Nodes.Clear();

            
            TreeNode meatsNode = new TreeNode("М'ясо");
            meatsNode.Nodes.Add("Куряче філе");
            meatsNode.Nodes.Add("Курячі гомілки");
            meatsNode.Nodes.Add("Балик традиційний");

            TreeNode fruktsNode = new TreeNode("Фрукти");
            fruktsNode.Nodes.Add("Банани");
            fruktsNode.Nodes.Add("Памело");
            fruktsNode.Nodes.Add("Мандаринки");

           
            productTreeView.Nodes.Add(meatsNode);
            productTreeView.Nodes.Add(fruktsNode);

            
            productTreeView.SelectedNode = productTreeView.Nodes[0];
        }


        private void InitializeComponent()
        {
            this.logListBox = new System.Windows.Forms.ListBox();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.calendarDatePicker = new System.Windows.Forms.MonthCalendar();
            this.addToCartButton = new System.Windows.Forms.Button();
            this.productTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 15;
            this.logListBox.Location = new System.Drawing.Point(12, 318);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(420, 154);
            this.logListBox.TabIndex = 0;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(12, 240);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(192, 23);
            this.itemNameTextBox.TabIndex = 1;
            // 
            // calendarDatePicker
            // 
            this.calendarDatePicker.Location = new System.Drawing.Point(268, 18);
            this.calendarDatePicker.Name = "calendarDatePicker";
            this.calendarDatePicker.TabIndex = 2;
            // 
            // addToCartButton
            // 
            this.addToCartButton.Location = new System.Drawing.Point(303, 230);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(84, 41);
            this.addToCartButton.TabIndex = 3;
            this.addToCartButton.Text = "Добавити";
            this.addToCartButton.UseVisualStyleBackColor = true;
            this.addToCartButton.Click += new System.EventHandler(this.addToCartButton_Click_1);
            // 
            // productTreeView
            // 
            this.productTreeView.Location = new System.Drawing.Point(12, 12);
            this.productTreeView.Name = "productTreeView";
            this.productTreeView.Size = new System.Drawing.Size(225, 163);
            this.productTreeView.TabIndex = 4;
            this.productTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.productTreeView_AfterSelect);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 489);
            this.Controls.Add(this.productTreeView);
            this.Controls.Add(this.addToCartButton);
            this.Controls.Add(this.calendarDatePicker);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.logListBox);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void productTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedProduct = e.Node.Text;

            itemNameTextBox.Text = selectedProduct;
        }
        private void addToCartButton_Click_1(object sender, EventArgs e)
        {
            string itemName = itemNameTextBox.Text;
            DateTime selectedDate = calendarDatePicker.SelectionStart;

            if (!string.IsNullOrEmpty(itemName))
            {
                OrderItem orderItem = new OrderItem(itemName, selectedDate);
                shoppingCart.Add(orderItem);

                string logEntry = $"Додано в корзину: {itemName} ({selectedDate.ToShortDateString()})";
                logListBox.Items.Add(logEntry);
            }
            else
            {
                MessageBox.Show("Введіть назву товару.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public class OrderItem
        {
            public string ItemName { get; set; }
            public DateTime DateAdded { get; set; }

            public OrderItem(string itemName, DateTime dateAdded)
            {
                ItemName = itemName;
                DateAdded = dateAdded;
            }

            public override string ToString()
            {
                return $"{ItemName} ({DateAdded.ToShortDateString()})";
            }
        }
    }
}
