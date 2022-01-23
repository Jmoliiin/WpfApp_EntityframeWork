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
            PopulateErrands();
            PopulateStatus();

        }

        private void PopulateErrands()
        {
            cbErrand.Items.Clear(); 
            foreach (var errands in errandsService.GetAll())
            {
                cbErrand.Items.Add(new KeyValuePair<int, string>(errands.Id, ($"Id: {errands.Id}\nHeader: {errands.Heading}\nCostumer: {errands.Costumer.Email}\nStatus: {errands.Satus.StatusType}")).Value);
            }
        }
        private void PopulateStatus()
        {
            cbStatus.Items.Clear();
            foreach(var status in statusService.GetAll())
            {
                cbStatus.Items.Add(new KeyValuePair<int,string>(status.Id, status.StatusType).Value);             
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        { 
            var _selectedErrend = cbErrand.SelectionBoxItem.ToString();
            var _selectedStatus = cbStatus.SelectionBoxItem.ToString();
            if (string.IsNullOrEmpty(_selectedErrend))
                lbError.Content = "You need to select an errend to update";
            else
            {
                if (string.IsNullOrEmpty(_selectedStatus) && string.IsNullOrEmpty(tbDescription.Text))
                    lbError.Content = "update status or description";
                else
                {
                    foreach (var errend in errandsService.GetAll())
                    {

                        var _errend = $"Id: {errend.Id}\nHeader: {errend.Heading}\nCostumer: {errend.Costumer.Email}\nStatus: {errend.Satus.StatusType}";
                        var _status1 = errend.Satus.StatusType;
                        if (_errend == _selectedErrend && _status1 != _selectedStatus)
                        {

                            foreach (var status in statusService.GetAll())
                            {
                                var _searchStatus = status.StatusType;
                                if (_selectedStatus == _searchStatus)
                                {
                                    errend.SatusId = status.Id;
                                    break;
                                }
                            }
                            if (tbDescription.Text != "") { errend.Descriptions = tbDescription.Text; }

                            errend.DateChanged = DateTime.Now;

                            errandsService.Save();
                            ClearFields();
                            PopulateErrands();

                            PopulateStatus();
                            break;
                        }

                    }
                }

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
