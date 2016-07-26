namespace Logiciel.cs.View
{
    partial class Bureau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btn_users = new System.Windows.Forms.Button();
            this.btn_profil = new System.Windows.Forms.Button();
            this.btn_panier = new System.Windows.Forms.Button();
            this.btn_revendeur = new System.Windows.Forms.Button();
            this.btn_stock = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelLevelDroit = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.buttonDeconnexion = new System.Windows.Forms.Button();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.label_signature2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_email2 = new System.Windows.Forms.Label();
            this.label_signature = new System.Windows.Forms.Label();
            this.label_role = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.panel_stock = new System.Windows.Forms.Panel();
            this.gridViewStock = new System.Windows.Forms.DataGridView();
            this.panel_add_user = new System.Windows.Forms.Panel();
            this.add_user_btn_create = new System.Windows.Forms.Button();
            this.add_user_btn_add_group = new System.Windows.Forms.Button();
            this.add_user_input_group = new System.Windows.Forms.TextBox();
            this.add_user_input_password = new System.Windows.Forms.TextBox();
            this.add_user_input_email = new System.Windows.Forms.TextBox();
            this.add_user_input_nom = new System.Windows.Forms.TextBox();
            this.add_user_input_prenom = new System.Windows.Forms.TextBox();
            this.add_user_listbox_group = new System.Windows.Forms.ListBox();
            this.add_user_label_nom = new System.Windows.Forms.Label();
            this.add_user_label_prenom = new System.Windows.Forms.Label();
            this.add_user_label_mdp = new System.Windows.Forms.Label();
            this.add_user_label_email = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_parent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelUsers.SuspendLayout();
            this.panel_stock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStock)).BeginInit();
            this.panel_add_user.SuspendLayout();
            this.panel_parent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btn_users);
            this.panelMenu.Controls.Add(this.btn_profil);
            this.panelMenu.Controls.Add(this.btn_panier);
            this.panelMenu.Controls.Add(this.btn_revendeur);
            this.panelMenu.Controls.Add(this.btn_stock);
            this.panelMenu.Location = new System.Drawing.Point(-1, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(128, 440);
            this.panelMenu.TabIndex = 0;
            // 
            // btn_users
            // 
            this.btn_users.Location = new System.Drawing.Point(3, 107);
            this.btn_users.Name = "btn_users";
            this.btn_users.Size = new System.Drawing.Size(122, 23);
            this.btn_users.TabIndex = 4;
            this.btn_users.Text = "Utilisateurs";
            this.btn_users.UseVisualStyleBackColor = true;
            this.btn_users.Click += new System.EventHandler(this.btn_users_Click);
            // 
            // btn_profil
            // 
            this.btn_profil.Location = new System.Drawing.Point(3, 78);
            this.btn_profil.Name = "btn_profil";
            this.btn_profil.Size = new System.Drawing.Size(122, 23);
            this.btn_profil.TabIndex = 3;
            this.btn_profil.Text = "Profil";
            this.btn_profil.UseVisualStyleBackColor = true;
            this.btn_profil.Click += new System.EventHandler(this.btn_profil_Click);
            // 
            // btn_panier
            // 
            this.btn_panier.Location = new System.Drawing.Point(3, 56);
            this.btn_panier.Name = "btn_panier";
            this.btn_panier.Size = new System.Drawing.Size(122, 23);
            this.btn_panier.TabIndex = 2;
            this.btn_panier.Text = "Panier";
            this.btn_panier.UseVisualStyleBackColor = true;
            // 
            // btn_revendeur
            // 
            this.btn_revendeur.Location = new System.Drawing.Point(3, 31);
            this.btn_revendeur.Margin = new System.Windows.Forms.Padding(0);
            this.btn_revendeur.Name = "btn_revendeur";
            this.btn_revendeur.Size = new System.Drawing.Size(122, 23);
            this.btn_revendeur.TabIndex = 1;
            this.btn_revendeur.Text = "Revendeur";
            this.btn_revendeur.UseVisualStyleBackColor = true;
            // 
            // btn_stock
            // 
            this.btn_stock.Location = new System.Drawing.Point(3, 8);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(0);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(122, 23);
            this.btn_stock.TabIndex = 0;
            this.btn_stock.Text = "Stock";
            this.btn_stock.UseVisualStyleBackColor = true;
            this.btn_stock.Click += new System.EventHandler(this.btn_stock_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelLevelDroit);
            this.panelHeader.Controls.Add(this.labelLogin);
            this.panelHeader.Controls.Add(this.buttonDeconnexion);
            this.panelHeader.Location = new System.Drawing.Point(133, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(549, 43);
            this.panelHeader.TabIndex = 1;
            // 
            // labelLevelDroit
            // 
            this.labelLevelDroit.AutoSize = true;
            this.labelLevelDroit.Location = new System.Drawing.Point(259, 8);
            this.labelLevelDroit.Name = "labelLevelDroit";
            this.labelLevelDroit.Size = new System.Drawing.Size(73, 13);
            this.labelLevelDroit.TabIndex = 4;
            this.labelLevelDroit.Text = "Administrateur";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(32, 8);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(108, 13);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "john.snow@rubis.bzh";
            // 
            // buttonDeconnexion
            // 
            this.buttonDeconnexion.Location = new System.Drawing.Point(455, 3);
            this.buttonDeconnexion.Name = "buttonDeconnexion";
            this.buttonDeconnexion.Size = new System.Drawing.Size(95, 23);
            this.buttonDeconnexion.TabIndex = 2;
            this.buttonDeconnexion.Text = "Deconnexion";
            this.buttonDeconnexion.UseVisualStyleBackColor = true;
            this.buttonDeconnexion.Click += new System.EventHandler(this.deconnexion);
            // 
            // panelUsers
            // 
            this.panelUsers.Controls.Add(this.label_signature2);
            this.panelUsers.Controls.Add(this.label1);
            this.panelUsers.Controls.Add(this.label_email2);
            this.panelUsers.Controls.Add(this.label_signature);
            this.panelUsers.Controls.Add(this.label_role);
            this.panelUsers.Controls.Add(this.label_email);
            this.panelUsers.Location = new System.Drawing.Point(3, 19);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(49, 44);
            this.panelUsers.TabIndex = 2;
            // 
            // label_signature2
            // 
            this.label_signature2.AutoSize = true;
            this.label_signature2.Location = new System.Drawing.Point(147, 115);
            this.label_signature2.Name = "label_signature2";
            this.label_signature2.Size = new System.Drawing.Size(0, 13);
            this.label_signature2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(147, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 7;
            // 
            // label_email2
            // 
            this.label_email2.AutoSize = true;
            this.label_email2.Location = new System.Drawing.Point(147, 34);
            this.label_email2.Name = "label_email2";
            this.label_email2.Size = new System.Drawing.Size(0, 13);
            this.label_email2.TabIndex = 3;
            // 
            // label_signature
            // 
            this.label_signature.AutoSize = true;
            this.label_signature.Location = new System.Drawing.Point(64, 115);
            this.label_signature.Name = "label_signature";
            this.label_signature.Size = new System.Drawing.Size(58, 13);
            this.label_signature.TabIndex = 2;
            this.label_signature.Text = "Signature :";
            // 
            // label_role
            // 
            this.label_role.AutoSize = true;
            this.label_role.Location = new System.Drawing.Point(64, 78);
            this.label_role.Name = "label_role";
            this.label_role.Size = new System.Drawing.Size(35, 13);
            this.label_role.TabIndex = 1;
            this.label_role.Text = "Role :";
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(64, 35);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(38, 13);
            this.label_email.TabIndex = 0;
            this.label_email.Text = "Email :";
            // 
            // panel_stock
            // 
            this.panel_stock.Controls.Add(this.gridViewStock);
            this.panel_stock.Location = new System.Drawing.Point(22, 171);
            this.panel_stock.Name = "panel_stock";
            this.panel_stock.Size = new System.Drawing.Size(59, 79);
            this.panel_stock.TabIndex = 6;
            // 
            // gridViewStock
            // 
            this.gridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewStock.Location = new System.Drawing.Point(35, 69);
            this.gridViewStock.Name = "gridViewStock";
            this.gridViewStock.Size = new System.Drawing.Size(485, 262);
            this.gridViewStock.TabIndex = 0;
            // 
            // panel_add_user
            // 
            this.panel_add_user.Controls.Add(this.add_user_btn_create);
            this.panel_add_user.Controls.Add(this.add_user_btn_add_group);
            this.panel_add_user.Controls.Add(this.add_user_input_group);
            this.panel_add_user.Controls.Add(this.add_user_input_password);
            this.panel_add_user.Controls.Add(this.add_user_input_email);
            this.panel_add_user.Controls.Add(this.add_user_input_nom);
            this.panel_add_user.Controls.Add(this.add_user_input_prenom);
            this.panel_add_user.Controls.Add(this.add_user_listbox_group);
            this.panel_add_user.Controls.Add(this.add_user_label_nom);
            this.panel_add_user.Controls.Add(this.add_user_label_prenom);
            this.panel_add_user.Controls.Add(this.add_user_label_mdp);
            this.panel_add_user.Controls.Add(this.add_user_label_email);
            this.panel_add_user.Location = new System.Drawing.Point(0, 0);
            this.panel_add_user.Name = "panel_add_user";
            this.panel_add_user.Size = new System.Drawing.Size(550, 388);
            this.panel_add_user.TabIndex = 5;
            // 
            // add_user_btn_create
            // 
            this.add_user_btn_create.Location = new System.Drawing.Point(452, 211);
            this.add_user_btn_create.Name = "add_user_btn_create";
            this.add_user_btn_create.Size = new System.Drawing.Size(87, 23);
            this.add_user_btn_create.TabIndex = 12;
            this.add_user_btn_create.Text = "Enregistrer";
            this.add_user_btn_create.UseVisualStyleBackColor = true;
            this.add_user_btn_create.Click += new System.EventHandler(this.add_user_btn_create_Click);
            // 
            // add_user_btn_add_group
            // 
            this.add_user_btn_add_group.Location = new System.Drawing.Point(480, 26);
            this.add_user_btn_add_group.Name = "add_user_btn_add_group";
            this.add_user_btn_add_group.Size = new System.Drawing.Size(59, 23);
            this.add_user_btn_add_group.TabIndex = 11;
            this.add_user_btn_add_group.Text = "Ajouter";
            this.add_user_btn_add_group.UseVisualStyleBackColor = true;
            // 
            // add_user_input_group
            // 
            this.add_user_input_group.Location = new System.Drawing.Point(391, 26);
            this.add_user_input_group.Name = "add_user_input_group";
            this.add_user_input_group.Size = new System.Drawing.Size(74, 20);
            this.add_user_input_group.TabIndex = 10;
            // 
            // add_user_input_password
            // 
            this.add_user_input_password.Location = new System.Drawing.Point(122, 131);
            this.add_user_input_password.Name = "add_user_input_password";
            this.add_user_input_password.Size = new System.Drawing.Size(100, 20);
            this.add_user_input_password.TabIndex = 9;
            // 
            // add_user_input_email
            // 
            this.add_user_input_email.Location = new System.Drawing.Point(122, 100);
            this.add_user_input_email.Name = "add_user_input_email";
            this.add_user_input_email.Size = new System.Drawing.Size(100, 20);
            this.add_user_input_email.TabIndex = 8;
            // 
            // add_user_input_nom
            // 
            this.add_user_input_nom.Location = new System.Drawing.Point(122, 68);
            this.add_user_input_nom.Name = "add_user_input_nom";
            this.add_user_input_nom.Size = new System.Drawing.Size(100, 20);
            this.add_user_input_nom.TabIndex = 7;
            // 
            // add_user_input_prenom
            // 
            this.add_user_input_prenom.Location = new System.Drawing.Point(122, 36);
            this.add_user_input_prenom.Name = "add_user_input_prenom";
            this.add_user_input_prenom.Size = new System.Drawing.Size(100, 20);
            this.add_user_input_prenom.TabIndex = 6;
            // 
            // add_user_listbox_group
            // 
            this.add_user_listbox_group.FormattingEnabled = true;
            this.add_user_listbox_group.Location = new System.Drawing.Point(391, 52);
            this.add_user_listbox_group.Name = "add_user_listbox_group";
            this.add_user_listbox_group.Size = new System.Drawing.Size(148, 108);
            this.add_user_listbox_group.TabIndex = 5;
            this.add_user_listbox_group.SelectedIndexChanged += new System.EventHandler(this.add_user_listbox_group_SelectedIndexChanged);
            // 
            // add_user_label_nom
            // 
            this.add_user_label_nom.AutoSize = true;
            this.add_user_label_nom.Location = new System.Drawing.Point(38, 68);
            this.add_user_label_nom.Name = "add_user_label_nom";
            this.add_user_label_nom.Size = new System.Drawing.Size(35, 13);
            this.add_user_label_nom.TabIndex = 4;
            this.add_user_label_nom.Text = "Nom :";
            // 
            // add_user_label_prenom
            // 
            this.add_user_label_prenom.AutoSize = true;
            this.add_user_label_prenom.Location = new System.Drawing.Point(38, 39);
            this.add_user_label_prenom.Name = "add_user_label_prenom";
            this.add_user_label_prenom.Size = new System.Drawing.Size(49, 13);
            this.add_user_label_prenom.TabIndex = 3;
            this.add_user_label_prenom.Text = "Prénom :";
            // 
            // add_user_label_mdp
            // 
            this.add_user_label_mdp.AutoSize = true;
            this.add_user_label_mdp.Location = new System.Drawing.Point(38, 134);
            this.add_user_label_mdp.Name = "add_user_label_mdp";
            this.add_user_label_mdp.Size = new System.Drawing.Size(77, 13);
            this.add_user_label_mdp.TabIndex = 2;
            this.add_user_label_mdp.Text = "Mot de passe :";
            // 
            // add_user_label_email
            // 
            this.add_user_label_email.AutoSize = true;
            this.add_user_label_email.Location = new System.Drawing.Point(38, 103);
            this.add_user_label_email.Name = "add_user_label_email";
            this.add_user_label_email.Size = new System.Drawing.Size(38, 13);
            this.add_user_label_email.TabIndex = 1;
            this.add_user_label_email.Text = "Email :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // panel_parent
            // 
            this.panel_parent.Controls.Add(this.panel_add_user);
            this.panel_parent.Controls.Add(this.panelUsers);
            this.panel_parent.Controls.Add(this.panel_stock);
            this.panel_parent.Location = new System.Drawing.Point(133, 49);
            this.panel_parent.Name = "panel_parent";
            this.panel_parent.Size = new System.Drawing.Size(549, 391);
            this.panel_parent.TabIndex = 3;
            // 
            // Bureau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 452);
            this.Controls.Add(this.panel_parent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.Name = "Bureau";
            this.Text = "Bureau";
            this.panelMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            this.panel_stock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStock)).EndInit();
            this.panel_add_user.ResumeLayout(false);
            this.panel_add_user.PerformLayout();
            this.panel_parent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button buttonDeconnexion;
        public System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelLevelDroit;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Button btn_profil;
        private System.Windows.Forms.Button btn_panier;
        private System.Windows.Forms.Button btn_revendeur;
        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Label label_signature;
        private System.Windows.Forms.Label label_role;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_email2;
        private System.Windows.Forms.Panel panel_stock;
        private System.Windows.Forms.Label label_signature2;
        private System.Windows.Forms.DataGridView gridViewStock;
        private System.Windows.Forms.Button btn_users;
        private System.Windows.Forms.Panel panel_add_user;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label add_user_label_email;
        private System.Windows.Forms.Panel panel_parent;
        private System.Windows.Forms.Label add_user_label_mdp;
        private System.Windows.Forms.Label add_user_label_prenom;
        private System.Windows.Forms.Label add_user_label_nom;
        private System.Windows.Forms.ListBox add_user_listbox_group;
        private System.Windows.Forms.TextBox add_user_input_group;
        private System.Windows.Forms.TextBox add_user_input_password;
        private System.Windows.Forms.TextBox add_user_input_email;
        private System.Windows.Forms.TextBox add_user_input_nom;
        private System.Windows.Forms.TextBox add_user_input_prenom;
        private System.Windows.Forms.Button add_user_btn_create;
        private System.Windows.Forms.Button add_user_btn_add_group;
    }
}