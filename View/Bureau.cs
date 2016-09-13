using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logiciel.cs.Controller;
using Logiciel.cs.Model;
namespace Logiciel.cs.View
{
    public partial class Bureau : Form
    {
        private string label { get; set; }
        private string label_group;
        private List<IGroups> listGroup = new List<IGroups>();
        private List<IProducts> listCart = new List<IProducts>();
        private List<string> listQuantityToCommand = new List<string>();
        private Users userGlobal = new Users();

        //Event Listener 
        public event EventHandler<EventArgs> requestCloseSession;
        public event EventHandler<EventArgs> loadGroupRequest;
        public event EventHandler<EventArgs> requestDisplayUsers;

        //Contructeur surchargé
        public Bureau(Users users)
        {
            userGlobal = users;
            InitializeComponent();
            this.labelLogin.Text = users.users_email;
            this.labelLevelDroit.Text = users.users_group_label;
            this.label_email2.Text = users.users_email;
            this.label1.Text = users.users_group_label;
            this.label_signature2.Text = users.users_signature;
            this.panel_parent.Visible = true;
            this.panel_stock.Visible = false;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = false;
            this.panel_list_users.Visible = true;
            this.panel_preorder.Visible = false;
        }
        
        //Contructeur permettant initialisé le group de l'utilisateur
        public Bureau(List<IGroups> ListGroup)
        {
            this.listGroup = ListGroup;
        }

        //Methode affichant l'entete 
        private void displayUsers(object sender, EventArgs e)
        {
            EventHandler<EventArgs> requestSendCtrl = requestDisplayUsers;
            if (requestSendCtrl != null)
            {
                requestSendCtrl(this, e);
            }
        }

        //Methode de deconnexion
        private void deconnexion(object sender, EventArgs e)
        {
            EventHandler<EventArgs> requestCloseSendCtrl = requestCloseSession;
            if (requestCloseSendCtrl != null)
            {
                requestCloseSendCtrl(this, e);
            }
        }

        //Methode affichant le profil de l'utilisateur 
        private void btn_profil_Click(object sender, EventArgs e)
        {
            this.panel_stock.Visible = false;
            this.panelUsers.Visible = true;
            this.panel_add_user.Visible = false;
            this.panel_list_users.Visible = false;
            this.panel_preorder.Visible = false;
        }

        //Methode affichant le panel des stock
        private void btn_stock_Click(object sender, EventArgs e)
        {
            this.panel_stock.Visible = true;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = false;
            this.panel_list_users.Visible = false;
            this.panel_create_stock.Visible = false;
            this.panel_preorder.Visible = false;
            this.gridViewStock.Rows.Clear();
            SetupDataGridViewStock();
            FillDataGridViewStock();

        }

        //Methode affichant le panel qui liste les utilisateurs
        private void btn_list_user_Click(object sender, EventArgs e)
        {
            this.panel_stock.Visible = false;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = false;
            this.panel_list_users.Visible = true;
            this.panel_preorder.Visible = false;
            this.gridViewUsers.Rows.Clear();
            SetupDataGridViewUsers();
            FillDataGridViewUsers();
        }

        //Methode envoyer les données saisis au model User pour créer un utilisateur
        private void add_user_btn_create_Click(object sender, EventArgs e)
        {

            int retour = 0;
            Users newUser = new Users();
            newUser.users_firstname = this.add_user_input_prenom.Text.ToString();
            newUser.users_lastname = this.add_user_input_nom.Text.ToString();
            newUser.users_email = this.add_user_input_email.Text.ToString();
            newUser.users_password = this.add_user_input_password.Text.ToString();
            newUser.users_group_label = label_group;
            newUser.createUser(newUser);
            if (retour != 1)
            {
                init_input_create_user();
            }
            else
            {
                MessageBox.Show("Enregistrement effectuer");
            }
        }

        //Methode reinitialisant les champs du panel de création utilisateur après enregistrement
        private void init_input_create_user()
        {
            this.add_user_input_prenom.Text = "";
            this.add_user_input_nom.Text = "";
            this.add_user_input_email.Text = "";
            this.add_user_input_password.Text = "";
        }

        //Methode remplissant la liste de group dans le panel de création de l'utilisateur 
        private void add_user_listbox_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retourne l'item selectionné
            label_group = this.add_user_listbox_group.SelectedItem.ToString();

            // retourne un indice si la chaine selectionné exist
            int index = this.add_user_listbox_group.FindString(label_group);
            // If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
            if (index == -1)
                MessageBox.Show("Rien n'a été selectionné dans cette liste");
            else
                MessageBox.Show(label_group);
        }

        //Methode initialisant le dataGridView pour les stock
        private void SetupDataGridViewStock()
        {
            gridViewStock.ColumnCount = 5;
            gridViewStock.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            gridViewStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridViewStock.ColumnHeadersDefaultCellStyle.Font =
                new Font(gridViewStock.Font, FontStyle.Bold);
            gridViewStock.Name = "songsDataGridView";
            gridViewStock.Location = new Point(0, 35);
            gridViewStock.Size = new Size(533, 350);
            gridViewStock.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridViewStock.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            gridViewStock.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gridViewStock.GridColor = Color.Black;
            gridViewStock.RowHeadersVisible = false;

            gridViewStock.Columns[0].Name = "id";
            gridViewStock.Columns[1].Name = "Référence";
            gridViewStock.Columns[2].Name = "Nom";
            gridViewStock.Columns[3].Name = "Quantité";
            gridViewStock.Columns[4].Name = "En Ligne";
            

            gridViewStock.Columns[0].ReadOnly = true;
            gridViewStock.Columns[1].ReadOnly = true;
            gridViewStock.Columns[2].ReadOnly = true;
            gridViewStock.Columns[3].ReadOnly = true;
            gridViewStock.Columns[4].ReadOnly = true;

            gridViewStock.Columns[0].Visible = false;


            gridViewStock.SelectionMode =
               DataGridViewSelectionMode.FullRowSelect;
            gridViewStock.MultiSelect = false;

            DataGridViewButtonColumn btnColumnEdit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnColumnDel = new DataGridViewButtonColumn();

            DataGridViewCheckBoxColumn checkBoxColumnCart = new DataGridViewCheckBoxColumn();

            DataGridViewTextBoxColumn textBoxColumnQuantity = new DataGridViewTextBoxColumn();
            btnColumnEdit.HeaderText = "Actions";
            btnColumnEdit.Name = "edit";
            btnColumnEdit.Text = "Editer";
            btnColumnEdit.UseColumnTextForButtonValue = true;
            

            btnColumnDel.HeaderText = "Actions";
            btnColumnDel.Name = "delete";
            btnColumnDel.Text = "Supprimer";

            checkBoxColumnCart.HeaderText = "Panier";
            checkBoxColumnCart.Name = "command";
            checkBoxColumnCart.TrueValue = true;
            checkBoxColumnCart.FalseValue = false;
            textBoxColumnQuantity.HeaderText = "Quantité à commander";

            btnColumnDel.UseColumnTextForButtonValue = true;
            gridViewStock.Columns.Add(checkBoxColumnCart);
            gridViewStock.Columns.Add(textBoxColumnQuantity);
            gridViewStock.Columns.Add(btnColumnEdit);
            gridViewStock.Columns.Add(btnColumnDel);

            gridViewStock.CellClick += new DataGridViewCellEventHandler(gridViewStock_CellClick);
        }

        //Methode appellant le model Product pour remplir le dataGridView
        public void FillDataGridViewStock()
        {
            Products products = new Products();

            foreach (IProducts prd in products.getListProduct())
            {
                string[] row = { prd.id_products.ToString(),prd.reference, prd.name, prd.quantity.ToString(), prd.online.ToString() };
                gridViewStock.Rows.Add(row);
            }
            gridViewStock.Columns[0].DisplayIndex = 0;
            gridViewStock.Columns[1].DisplayIndex = 1;
            gridViewStock.Columns[2].DisplayIndex = 2;
            gridViewStock.Columns[3].DisplayIndex = 3;
            gridViewStock.Columns[4].DisplayIndex = 4;
        }

        //Methode de listener sur les certainnes column du datagridview
        private void gridViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Products products;
            switch (e.ColumnIndex)
            {
                case 7:
                    //edit
                    products = new Products();
                    products = products.getProduct(Int32.Parse(this.gridViewStock.SelectedCells[0].Value.ToString()));
                    MessageBox.Show(products.name);
                    this.btn_create_product.Click += new System.EventHandler(this.btn_create_product_Click);
                    this.input_create_stock_name.Text = products.name;
                    this.input_create_stock_slug.Text = products.slug;
                    this.input_create_stock_reference.Text = products.reference;
                    this.input_create_stock_quantity.Text = products.quantity.ToString();
                    this.rich_text_box_create_stock.Text = products.description1;

                    //InterfaceDeDonnees inter = new InterfaceDeDonnees();
                    //List<ICategory> categoriesWithProduct = new List<ICategory>();
                    //categoriesWithProduct = inter.getProductWithCategories(Int32.Parse(this.gridViewStock.SelectedCells[0].Value.ToString()));
                    
                    //foreach(Category ctg in categoriesWithProduct){

                    //}

                    this.panel_create_stock.Visible = true;
                    this.panel_list_users.Visible = false;
                    this.panel_add_user.Visible = false;
                    this.panel_stock.Visible = false;
                    break;
                case 8:
                    //remove
                    products = new Products();
                    this.gridViewStock.Rows.RemoveAt(this.gridViewStock.SelectedCells[0].RowIndex);
                    products.deleteProduct(this.gridViewStock.SelectedCells[0].Value.ToString());
                    break;
            }
        }

        //Methode initialisant le dataGridView pour les utilisateurs
        private void SetupDataGridViewUsers()
        {
            gridViewUsers.ColumnCount = 5;
            gridViewUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            gridViewUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridViewUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font(gridViewStock.Font, FontStyle.Bold);
            gridViewUsers.Name = "songsDataGridView";
            gridViewUsers.Location = new Point(0, 35);
            gridViewUsers.Size = new Size(533, 350);
            gridViewUsers.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridViewUsers.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            gridViewUsers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gridViewUsers.GridColor = Color.Black;
            gridViewUsers.RowHeadersVisible = false;

            gridViewUsers.Columns[0].Name = "id";
            gridViewUsers.Columns[1].Name = "Prénom";
            gridViewUsers.Columns[2].Name = "Nom";
            gridViewUsers.Columns[3].Name = "Email";
            gridViewUsers.Columns[4].Name = "Groupe";

            gridViewUsers.Columns[0].ReadOnly = true;
            gridViewUsers.Columns[1].ReadOnly = true;
            gridViewUsers.Columns[2].ReadOnly = true;
            gridViewUsers.Columns[3].ReadOnly = true;
            gridViewUsers.Columns[4].ReadOnly = true;

            gridViewUsers.Columns[0].Visible = false;


            gridViewUsers.SelectionMode =
               DataGridViewSelectionMode.FullRowSelect;
            gridViewUsers.MultiSelect = false;

            DataGridViewButtonColumn btnColumnEdit = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnColumnDel = new DataGridViewButtonColumn();

            btnColumnEdit.HeaderText = "Actions";
            btnColumnEdit.Name = "edit";
            btnColumnEdit.Text = "Editer";
            btnColumnEdit.UseColumnTextForButtonValue = true;


            btnColumnDel.HeaderText = "Actions";
            btnColumnDel.Name = "delete";
            btnColumnDel.Text = "Supprimer";
            btnColumnDel.UseColumnTextForButtonValue = true;

            gridViewUsers.Columns.Add(btnColumnEdit);
            gridViewUsers.Columns.Add(btnColumnDel);

            gridViewUsers.CellClick += new DataGridViewCellEventHandler(gridViewUser_CellClick);
        }

        //Methode appellant le model User pour remplir le dataGridView
        public void FillDataGridViewUsers()
        {
            Users users = new Users();

            foreach (IUsers usr in users.getListUsers())
            {
                string[] row = { usr.id_users.ToString(), usr.users_firstname, usr.users_lastname, usr.users_email, usr.users_id_group.ToString() };
                gridViewUsers.Rows.Add(row);
            }
            gridViewUsers.Columns[0].DisplayIndex = 0;
            gridViewUsers.Columns[1].DisplayIndex = 1;
            gridViewUsers.Columns[2].DisplayIndex = 2;
            gridViewUsers.Columns[3].DisplayIndex = 3;
            gridViewUsers.Columns[4].DisplayIndex = 4;
        }

        //Methode de listener sur le click de certaines column du datagridview
        private void gridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Users users = new Users();
            
            switch (e.ColumnIndex)
            {
                case 5:
                    //edit
                    users = users.getUser(Int32.Parse(this.gridViewUsers.SelectedCells[0].Value.ToString()));
                    this.add_user_btn_create.Click += new System.EventHandler(this.add_user_btn_create_Click);
                    this.add_user_input_prenom.Text = users.users_firstname;
                    this.add_user_input_nom.Text = users.users_lastname;
                    this.add_user_input_email.Text = users.users_email;
                    this.add_user_input_password.Text = users.users_password;
                    this.panel_stock.Visible = false;
                    this.panelUsers.Visible = false;
                    this.panel_add_user.Visible = true;
                    this.panel_list_users.Visible = false;

                    break;
                case 6:
                    //remove
                    this.gridViewUsers.Rows.RemoveAt(this.gridViewUsers.SelectedCells[0].RowIndex);
                    users.deleteUser(this.gridViewUsers.SelectedCells[0].Value.ToString());
                    break;
            }
        }

        //Methode affichant le panel de creation user et affichant liste des groupes 
        private void btn_create_user_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> requestFillGroup = loadGroupRequest;
            if (requestFillGroup != null)
            {
                requestFillGroup(this, e);

            }
            cs.Model.InterfaceDeDonnees inter = new InterfaceDeDonnees();
            inter.ListerTable();
            this.listGroup = inter.Groups;
            this.add_user_listbox_group.Items.Clear();
            foreach (IGroups group in this.listGroup)
            {
                if (group.groups_label != null)
                {
                    Groups grp = new Groups();
                    grp.groups_label = group.groups_label;
                    this.add_user_listbox_group.Items.Add(grp.groups_label);
                }
            }

            this.panel_stock.Visible = false;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = true;
            this.panel_list_users.Visible = false;
            this.panel_preorder.Visible = false;
        }

        ////Methode affichant le panel de creation d'un produit et affichant liste des categories de produits 
        private void btn_create_product_Click(object sender, EventArgs e)
        {
            InterfaceDeDonnees inter = new InterfaceDeDonnees();
            inter.ListerTable();
            this.checked_list_box_create_stock.Items.Clear();
            foreach (ICategory ctg in inter.Categories)
            {
                if (ctg.id_category != 0)
                {
                    Category category = new Category();
                    category.id_category = ctg.id_category;
                    category.category_name = ctg.category_name;
                    this.checked_list_box_create_stock.Items.Add(category);
                }
            }
            this.checked_list_box_create_stock.DisplayMember = "category_name";
            this.checked_list_box_create_stock.ValueMember = "id_category";
            this.panel_create_stock.Visible = true;
            this.panel_list_users.Visible = false;
            this.panel_add_user.Visible = false;
            this.panel_stock.Visible = false;
            this.panel_preorder.Visible = false;
        }

        //Methode appelant le model pour la creation des produits en fonction de la saisie
        private void btn_create_stock_Click(object sender, EventArgs e)
        {
            List<int> ids_category = new List<int>();
            Products product = new Products();
            foreach (var value in this.checked_list_box_create_stock.CheckedItems)
            {
                Category category = (Category)value;
                ids_category.Add(category.id_category);
            }
            product.name = this.input_create_stock_name.Text;
            product.reference = this.input_create_stock_reference.Text;
            product.slug = this.input_create_stock_slug.Text;
            product.quantity = Int32.Parse(this.input_create_stock_quantity.Text);
            product.description1 = this.rich_text_box_create_stock.Text;
            product.createProduct(product, ids_category);
        }

        //Methode permettant de remplir le panier pour les commandes
        private void btn_stock_preorder_Click(object sender, EventArgs e)
        {
            int id_preoder = 0;
            InterfaceDeDonnees inter = new InterfaceDeDonnees();

            id_preoder = inter.createPreOrder(userGlobal);

            foreach (DataGridViewRow dataGridRow in this.gridViewStock.Rows)
            {
                if (dataGridRow.Cells["command"].Value != null && (bool)dataGridRow.Cells["command"].Value)
                {
                    Products product = new Products();
                    product.id_products = Int32.Parse(dataGridRow.Cells[0].Value.ToString());
                    product.reference = dataGridRow.Cells[1].Value.ToString();
                    product.name = dataGridRow.Cells[2].Value.ToString();
                    product.quantity = Int32.Parse(dataGridRow.Cells[3].Value.ToString());
                    listCart.Add(product);
                    //MessageBox.Show(product.name);
                    listQuantityToCommand.Add(dataGridRow.Cells[6].Value.ToString());
                    inter.createPreOrderToProduct(id_preoder, product.id_products, Int32.Parse(dataGridRow.Cells[6].Value.ToString()));
                }

            }
            
            this.panel_preorder.Visible = true;
            this.panel_stock.Visible = false;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = false;
            this.panel_list_users.Visible = false;
            SetupDataGridViewCart();
            FillDataGridViewCart();

            
        }

        //Methode affichant le panel Panier
        private void btn_panier_Click(object sender, EventArgs e)
        {
            this.panel_preorder.Visible = true;
            this.panel_stock.Visible = false;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = false;
            this.panel_list_users.Visible = false;
            SetupDataGridViewCart();
            FillDataGridViewCart();
        }

        //Methode d'initialisation du dataGridView panier
        private void SetupDataGridViewCart()
        {
            gridViewCart.ColumnCount = 4;
            gridViewCart.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            gridViewCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridViewCart.ColumnHeadersDefaultCellStyle.Font =
                new Font(gridViewStock.Font, FontStyle.Bold);
            gridViewCart.Name = "songsDataGridView";
            gridViewCart.Location = new Point(0, 35);
            gridViewCart.Size = new Size(533, 350);
            gridViewCart.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            gridViewCart.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            gridViewCart.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gridViewCart.GridColor = Color.Black;
            gridViewCart.RowHeadersVisible = false;

            gridViewCart.Columns[0].Name = "id";
            gridViewCart.Columns[1].Name = "Référence";
            gridViewCart.Columns[2].Name = "Nom du produit";
            gridViewCart.Columns[3].Name = "Quantité à commander";

            gridViewCart.Columns[0].ReadOnly = true;
            gridViewCart.Columns[1].ReadOnly = true;
            gridViewCart.Columns[2].ReadOnly = true;
            gridViewCart.Columns[3].ReadOnly = true;

            gridViewCart.Columns[0].Visible = false;


            gridViewCart.SelectionMode =
               DataGridViewSelectionMode.FullRowSelect;
            gridViewCart.MultiSelect = false;

            DataGridViewButtonColumn btnColumnDel = new DataGridViewButtonColumn();

            btnColumnDel.HeaderText = "Actions";
            btnColumnDel.Name = "delete";
            btnColumnDel.Text = "Supprimer";
            btnColumnDel.UseColumnTextForButtonValue = true;

            gridViewCart.Columns.Add(btnColumnDel);

            gridViewCart.CellClick += new DataGridViewCellEventHandler(gridViewCart_CellClick);
        }

        //Methode remplissant le datagridview panier par rapport à la liste de checkbox 
        public void FillDataGridViewCart()
        {
            Products product = new Products();
            for (int i = 0; i < listCart.Count; i++)
            {
                string[] row = { listCart[i].id_products.ToString(), listCart[i].reference.ToString(), listCart[i].name.ToString() };
                string[] row2 = { listQuantityToCommand[i].ToString() };
                gridViewCart.Rows.Add(row);
                gridViewCart.Rows.Add(row2);
            }

            gridViewCart.Columns[0].DisplayIndex = 0;
            gridViewCart.Columns[1].DisplayIndex = 1;
            gridViewCart.Columns[2].DisplayIndex = 2;
            gridViewCart.Columns[3].DisplayIndex = 3;
        }

        //Methode de listener sur certaine column du datagridView panier
        private void gridViewCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            //switch (e.ColumnIndex)
            //{ 
            //    case 6:
            //        //remove
            //        this.gridViewUsers.Rows.RemoveAt(this.gridViewUsers.SelectedCells[0].RowIndex);
            //        users.deleteUser(this.gridViewUsers.SelectedCells[0].Value.ToString());
            //        break;
            //}
        }

    }
}
