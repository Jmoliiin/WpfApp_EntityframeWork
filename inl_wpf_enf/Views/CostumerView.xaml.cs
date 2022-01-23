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
    /// Interaction logic for CostumerView.xaml
    /// </summary>
    public partial class CostumerView : UserControl
    {
        private readonly ICostumerService costumerService = new CostumerServices();
        private readonly IStatusService statusService = new StatusService();
        private readonly IAdminsService adminsService =new AdminsService();
        public CostumerView()
        {
            //lägger in status och handler här, då jag ej gjort grafiskt för att lägga till
            statusService.CreateStatus("Started");
            statusService.CreateStatus("Not started");
            statusService.CreateStatus("Completed");

            adminsService.Create("Lisa", "Andersson");
            adminsService.Create("David", "Eriksson");
            adminsService.Create("Hampus", "Öberg");



            InitializeComponent();
            //Lista ut alla costumer
            lvUsers.Items.Clear();
            foreach (var user in costumerService.GetAll())
            {
                lvUsers.Items.Add(user);
            }

        }
        
    }
}
