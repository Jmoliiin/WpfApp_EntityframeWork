using inl_wpf_enf.Entities;
using inl_wpf_enf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace inl_wpf_enf.Views
{
    /// <summary>
    /// Interaction logic for NewErrandsView.xaml
    /// </summary>
    public partial class NewErrandsView : UserControl
    {
        private readonly IErrandsService errandsService = new ErrandsService();
        private readonly IAdminsService adminsService = new AdminsService();
        private readonly ICostumerService costumerService = new CostumerServices();
        private readonly IStatusService statusService = new StatusService();
        public NewErrandsView()
        {
            InitializeComponent();
            cbAdmin.SelectedValuePath = "Key";
            cbAdmin.DisplayMemberPath = "Value";

            cbStatus.SelectedValuePath = "Key";
            cbStatus.DisplayMemberPath = "Value";
            cbCostumer.SelectedValuePath = "Key";
            cbCostumer.DisplayMemberPath = "Value";

            ClearFields();
            populateCostumer();
            PopulateAdmin();
            PopulateStatus();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbHeader.Text) && !string.IsNullOrEmpty(tbDescription.Text))
            {
                if (errandsService.Create(tbHeader.Text, tbDescription.Text, (int)cbStatus.SelectedValue, (int)cbAdmin.SelectedValue, (int)cbCostumer.SelectedValue))
                {
                    ClearFields();
                    populateCostumer();
                    PopulateAdmin();
                    PopulateStatus();
                }
                else
                    lbError.Content = "Could not create a errend, Costumer not found in the system";
            }
        }
        private void ClearFields()
        {
            tbHeader.Text = "";
            tbDescription.Text = "";
            lbError.Content = "";
        }
        private void populateCostumer()
        {
            cbCostumer.Items.Clear();
            foreach (var costumer in costumerService.GetAll())
                cbCostumer.Items.Add(new KeyValuePair<int, (int,string,string)>(costumer.Id, (costumer.Id, costumer.FirstName, costumer.LastName)));
        }

        private void PopulateAdmin()
        {
            cbAdmin.Items.Clear();
            foreach (var admin in adminsService.GetAll())
                cbAdmin.Items.Add(new KeyValuePair<int,(string,string)>(admin.Id ,(admin.FirstName, admin.LastName)));
        }
        private void PopulateStatus()
        {
            cbStatus.Items.Clear();
            foreach (var status in statusService.GetAll())
                cbStatus.Items.Add(new KeyValuePair<int,string>(status.Id, status.StatusType));
        }
    }
}
