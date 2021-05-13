﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace UserInterface
{
    public partial class PasswordMoreInfoModal : Form
    {

        private int _timeLeft;
        public PasswordMoreInfoModal(Password password)
        {
            InitializeComponent();
            dtmPasswordLastModified.Format = DateTimePickerFormat.Custom;
            dtmPasswordLastModified.CustomFormat = "MM/yyyy";


            _timeLeft = 30;
            timerPasswordMoreInfo.Start();
            txtbxPasswordCategory.Text = password.Category.ToString();
            txtbxPasswordNotes.Text = password.Notes;
            txtbxPasswordSite.Text = password.Site;
            txtbxPasswordString.Text = password.PasswordString;
            txtbxPasswordSecurityLevel.Text = password.SecurityLevel.ToString();
            txtbxPasswordUsername.Text = password.Username;
            dtmPasswordLastModified.Value = password.LastModification;
            Label userLabel;
            foreach (string username in password.UsersSharedWith)
            {
                userLabel = CreateSharedWithUserLabel(username);
                fwlytSharedWith.Controls.Add(userLabel);
            }
        }

        private Label CreateSharedWithUserLabel(string username)
        {
            Label newUserLabel = new Label();
            newUserLabel.Height = 20;
            newUserLabel.Width = 118;
            newUserLabel.Text = username;
            return newUserLabel;
        }

        private void timerPasswordMoreInfo_Tick(object sender, EventArgs e)
        {
            txtbxTimeLeft.Text = _timeLeft.ToString();
            _timeLeft--;
            if(_timeLeft <= 0)
            {
                this.Close();
            }
        }
    }
}
