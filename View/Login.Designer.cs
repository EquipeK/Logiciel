﻿namespace Logiciel.cs.View
{
    partial class Login
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
            this.label_login = new System.Windows.Forms.Label();
            this.label_mot_de_passe = new System.Windows.Forms.Label();
            this.button_connexion = new System.Windows.Forms.Button();
            this.text_box_login = new System.Windows.Forms.TextBox();
            this.text_box_mot_de_passe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_login
            // 
            this.label_login.AutoSize = true;
            this.label_login.Location = new System.Drawing.Point(96, 51);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(39, 13);
            this.label_login.TabIndex = 0;
            this.label_login.Text = "Login :";
            // 
            // label_mot_de_passe
            // 
            this.label_mot_de_passe.AutoSize = true;
            this.label_mot_de_passe.Location = new System.Drawing.Point(96, 112);
            this.label_mot_de_passe.Name = "label_mot_de_passe";
            this.label_mot_de_passe.Size = new System.Drawing.Size(77, 13);
            this.label_mot_de_passe.TabIndex = 0;
            this.label_mot_de_passe.Text = "Mot de passe :";

            // 
            // button_connexion
            // 
            this.button_connexion.AutoSize = true;
            this.button_connexion.Location = new System.Drawing.Point(154, 182);
            this.button_connexion.Name = "button_connexion";
            this.button_connexion.Size = new System.Drawing.Size(77, 23);
            this.button_connexion.TabIndex = 0;
            this.button_connexion.Text = "Connexion";
            this.button_connexion.Click += new System.EventHandler(this.click_connexion);
            // 
            // text_box_login
            // 
            this.text_box_login.Location = new System.Drawing.Point(99, 77);
            this.text_box_login.Name = "text_box_login";
            this.text_box_login.Size = new System.Drawing.Size(132, 20);
            this.text_box_login.TabIndex = 1;

            // 
            // text_box_mot_de_passe
            // 
            this.text_box_mot_de_passe.Location = new System.Drawing.Point(99, 142);
            this.text_box_mot_de_passe.Name = "text_box_mot_de_passe";
            this.text_box_mot_de_passe.PasswordChar = '*';
            this.text_box_mot_de_passe.Size = new System.Drawing.Size(132, 20);
            this.text_box_mot_de_passe.TabIndex = 2;
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.text_box_mot_de_passe);
            this.Controls.Add(this.text_box_login);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.label_mot_de_passe);
            this.Controls.Add(this.button_connexion);
            this.Name = "Login";
            this.Text = "Interface de connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.Label label_mot_de_passe;
        private System.Windows.Forms.Button button_connexion;
        private System.Windows.Forms.TextBox text_box_login;
        private System.Windows.Forms.TextBox text_box_mot_de_passe;

    }
}