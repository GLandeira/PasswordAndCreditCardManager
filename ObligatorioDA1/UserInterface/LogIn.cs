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
    public partial class LogIn : UserControl
    {
        private UserManager _userManager;

        public LogIn(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;
        }
    }
}
