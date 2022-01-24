using inl_wpf_enf.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UpdateErrandsView.xaml
    /// </summary>
    public partial class UpdateErrandsView : UserControl
    {
        private readonly IErrandsService errandsService = new ErrandsService();
        private readonly IStatusService statusService = new StatusService();
        
    public UpdateErrandsView()
        {
            
            InitializeComponent();
            cbStatus.SelectedValuePath = "Key";
            cbStatus.DisplayMemberPath = "Value";
            cbErrand.SelectedValuePath = "Key";
            cbErrand.DisplayMemberPath = "Value";
            PopulateErrands();
            PopulateStatus();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int status;

            if (!string.IsNullOrEmpty(cbErrand.SelectionBoxItem.ToString()))
            {
                if (!string.IsNullOrEmpty(cbStatus.SelectionBoxItem.ToString()) || tbDescription.Text != string.Empty)
                {
                    if (string.IsNullOrEmpty(cbStatus.SelectionBoxItem.ToString()))
                        status = 0;
                    else 
                        status = (int)cbStatus.SelectedValue;
                    if (errandsService.Update(tbDescription.Text, status, (int)cbErrand.SelectedValue))
                    {
                        ClearFields();
                        lbError.Content = "Errend updated succesfully";
                    }      
                    else
                        lbError.Content = "Could not update errend";
                }else
                    lbError.Content = "You need to update description or status";
            }
            else
                lbError.Content = "You need to select an errend to update";
            
        }
        private void PopulateErrands()
        {
            cbErrand.Items.Clear();
            foreach (var errands in errandsService.GetAll())
            {
                cbErrand.Items.Add(new KeyValuePair<int, string>(errands.Id, ($"Id: {errands.Id}\nHeader: {errands.Heading}\nCostumer: {errands.Costumer.Email}\nStatus: {errands.Satus.StatusType}")));
            }
        }
        private void PopulateStatus()
        {
            cbStatus.Items.Clear();
            foreach (var status in statusService.GetAll())
            {
                cbStatus.Items.Add(new KeyValuePair<int, string>(status.Id, status.StatusType));
            }
        }

        private void ClearFields()
        {
            cbErrand.Text = "";
            cbStatus.Text = "";
            tbDescription.Text = "";
            lbError.Content = "";
        }
    }
}
