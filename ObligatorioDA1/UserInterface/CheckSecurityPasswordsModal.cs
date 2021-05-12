using System;
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
    public partial class CheckSecurityPasswordsModal : Form
    {
        private const int PARENT_PANEL_SIZE_X = 500;
        private const int PARENT_PANEL_SIZE_Y = 34;

        private const int LABEL_SIZE_Y = 15;
        private const int LABEL_SIZE_X = 396;
        private const int LABEL_Y = 9;
        private const int LABEL_X = 3;

        private const int BUTTON_Y = 6;
        private const int BUTTON_X = 425;

        private const string BUTTON_MODIFY_TEXT = "Modify";

        private List<Password> _passwords;

        public CheckSecurityPasswordsModal(List<Password> passwords)
        {
            InitializeComponent();
            _passwords = passwords;
        }

        private void CheckSecurityPasswordsModal_Load(object sender, EventArgs e)
        {
            GeneratePasswordVisuals(_passwords);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GeneratePasswordVisuals(List<Password> passwords)
        {
            for (int i = 0; i < passwords.Count; i++)
            {
                Password currentPassword = passwords[i];

                GeneratePasswordListElement(currentPassword);
            }
        }

        private void GeneratePasswordListElement(Password password)
        {
            Panel pnlParentPanel = CreatePanelWithSize(PARENT_PANEL_SIZE_X, PARENT_PANEL_SIZE_Y);
            fwlytPasswords.Controls.Add(pnlParentPanel);

            Label lblPassword = CreateLabelWithSettings(new Size(LABEL_SIZE_X, LABEL_SIZE_Y), new Point(LABEL_X, LABEL_Y), password.ToString());
            pnlParentPanel.Controls.Add(lblPassword);

            Button btnModifyPassword = CreateButtonWithSettings(BUTTON_MODIFY_TEXT, new Point(BUTTON_X, BUTTON_Y));
            // EventHandler takes a function of object and EventArgs parameters.
            // By providing a wrapper I can call any function that takes any parameter
            btnModifyPassword.Click += new EventHandler((obj, eventArgs) => ModifyButtonsOnClick(password));
            pnlParentPanel.Controls.Add(btnModifyPassword);
        }

        private Panel CreatePanelWithSize(int sizeX, int sizeY)
        {
            Panel newPanel = new Panel();
            newPanel.Size = new Size(sizeX, sizeY);

            return newPanel;
        }

        private Label CreateLabelWithSettings(Size size, Point location, string message)
        {
            Label newLabel = new Label();

            newLabel.Text = message;
            newLabel.Size = size;
            newLabel.Location = location;

            return newLabel;
        }

        private Button CreateButtonWithSettings(string buttonText, Point location)
        {
            Button newButton = new Button();

            newButton.Text = buttonText;
            newButton.Location = location;

            return newButton;
        }

        private void ModifyButtonsOnClick(Password thePassword)
        {
            //TODO Add PasswordModify call
        }
    }
}
