using MasterFloorShurkov.Models;
using MasterFloorShurkov.ViewModels;
using MasterFloorShurkov.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterFloorShurkov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<PartnerViewModel> Partners { get; } = new( );
        private MasterFloorShContext context = new MasterFloorShContext( );
        public PartnerViewModel SelectedPartner { get; set; }
        public MainWindow ()
        {
            InitializeComponent( );
            AddData( );
            DataContext = this;
        }
        public void AddData ()
        {
            Partners.Clear( );
            var data = context.Partners
                .Include(p => p.IdpartnerTypeNavigation)
                .Include(p => p.PartnerProducts)
                .ThenInclude(pp => pp.ArticulNavigation)
                .ToList( );
            foreach (var partner in context.Partners.ToList( ))
            {
                var sale = context.PartnerProducts
                    .Where(s => s.Idpartner == partner.Idpartner)
                    .Sum(s => s.Count);
                Partners.Add(new PartnerViewModel(partner, sale));
            }
        }

        private void EditData_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if (SelectedPartner != null)
            {
                var editWindow = new NewPartner(SelectedPartner.Model, context);
                if (editWindow.ShowDialog( ) == true)
                    AddData( );
                ((ListView) sender).SelectedItem = null;
            }
            
        }

        private void Add_Click (object sender, RoutedEventArgs e)
        {
            var editWindow = new NewPartner(null, context);
            if (editWindow.ShowDialog( ) == true)
                AddData( );
        }
    }
}