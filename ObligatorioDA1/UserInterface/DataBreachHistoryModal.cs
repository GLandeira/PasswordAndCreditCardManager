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
    public partial class DataBreachHistoryModal : Form
    {

        private User _currentUser;
        private DataBreach _selectedDataBreach;

        public DataBreachHistoryModal()
        {
            _currentUser = UserManager.Instance.LoggedUser;
            InitializeComponent();
            DataBreachLoad();
        }

        public void DataBreachLoad()
        {
            BindingSource dataBreachDataSource = new BindingSource();
            List<DataBreach> dataBreaches = _currentUser.UserDataBreaches.DataBreaches.ToList();
            dataBreachDataSource.DataSource = dataBreaches;

            grdvwDataBreachesHistory.DataSource = dataBreachDataSource;
        }

        private void grdvwDataBreachesHistory_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataBreach selectedRowDataBreach = (DataBreach)grdvwDataBreachesHistory.Rows[e.RowIndex].DataBoundItem;
            _selectedDataBreach = selectedRowDataBreach;
        }

        private void grdvwDataBreachesHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_selectedDataBreach != null)
            {
                Form DataBreachesHistoryresultModal = new DataBreachesHistoryResultModal(_selectedDataBreach);
                DataBreachesHistoryresultModal.ShowDialog();
            }
        }

        private void DataBreachHistoryModal_Load(object sender, EventArgs e)
        {

        }
    }
}
