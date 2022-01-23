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
    /// Interaction logic for ErrandsView.xaml
    /// </summary>
    public partial class ErrandsView : UserControl
    {
        private readonly IErrandsService errandsService = new ErrandsService();    
        public ErrandsView()
        {
            InitializeComponent();
            lvUsers.Items.Clear();
            foreach (var errands in errandsService.GetAll())
            {
                lvUsers.Items.Add(errands);
                
            }   
        }
    }
}
