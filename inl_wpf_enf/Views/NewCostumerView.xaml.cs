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
    /// Interaction logic for NewCostumerView.xaml
    /// </summary>
    public partial class NewCostumerView : UserControl
    {
        private readonly ICostumerService costumerService = new CostumerServices();
        public NewCostumerView()
        {
            
            InitializeComponent();

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbMobileNumber.Text) && 
                !string.IsNullOrEmpty(tbStreetName.Text) && !string.IsNullOrEmpty(tbPostalCode.Text) && !string.IsNullOrEmpty(tbCity.Text) &&
                !string.IsNullOrEmpty(tbCountry.Text))
            {
                if (costumerService.Create(tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbMobileNumber.Text, tbStreetName.Text, tbPostalCode.Text, tbCity.Text, tbCountry.Text))
                    ClearFields();
                else
                    lbError.Content = "A costumer with the same email address already exists.";
            }
        }
        private void ClearFields()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            tbMobileNumber.Text = "";
            tbStreetName.Text = "";
            tbPostalCode.Text = "";
            tbCity.Text = "";
            tbCountry.Text = "";
            lbError.Content = "";
        }

    }
}
