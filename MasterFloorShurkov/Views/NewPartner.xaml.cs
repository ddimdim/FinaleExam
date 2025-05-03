using MasterFloorShurkov.Models;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Shapes;

namespace MasterFloorShurkov.Views
{
    /// <summary>
    /// Логика взаимодействия для NewPartner.xaml
    /// </summary>
    public partial class NewPartner :Window
    {
        private MasterFloorShContext _context = new MasterFloorShContext( );
        private Partner _partner;
        public NewPartner (Partner partner, MasterFloorShContext context)
        {
            InitializeComponent( );
            LoadTypes( );
            _context = context;
            _partner = partner;
            if (partner != null)
            {
                FillFields( );
                TitleName.Text = "Редактирование данных";
            }
                
            else
                TitleName.Text = "Добавление партнера";
        }

        //Перенос данных в окно для редактирования
        private void FillFields ()
        {
            Name.Text = _partner.NameOrganization;
            Type.SelectedValue = _partner.IdpartnerType;
            Director.Text = _partner.Director;
            PhoneNumber.Text = _partner.PhoneNumber;
            Email.Text = _partner.Email;
            Address.Text = _partner.Address;
            Rating.Text = _partner.Rating.ToString();
        }

        //Загрузка данных в comboBox
        private void LoadTypes ()
        {
            var types = _context.PartnerTypes.ToList( );
            Type.ItemsSource = types;
            Type.DisplayMemberPath = "TypeName";
            Type.SelectedValuePath = "IdpartnerType";
        }
        private void Save_Click (object sender, RoutedEventArgs e)
        {
            if (Name.Text.IsNullOrEmpty( ) || Rating.Text.IsNullOrEmpty( ) ||
                Address.Text.IsNullOrEmpty( ) || Director.Text.IsNullOrEmpty( ) ||
                PhoneNumber.Text.IsNullOrEmpty( ) || Email.Text.IsNullOrEmpty( ) ||
                Type.SelectedItem == null)
            {
                MessageBox.Show("Заполните все данные для сохранения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(Rating.Text, out int rating) || rating < 0 || rating > 10)
            {
                MessageBox.Show("Введите рейтинг корректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_partner == null)
            {
                _partner = new Partner( );
                _context.Partners.Add(_partner);
            }

            _partner.NameOrganization = Name.Text;
            _partner.IdpartnerType = (int?) Type.SelectedValue;
            _partner.Rating = rating;
            _partner.Address = Address.Text;
            _partner.Director = Director.Text;
            _partner.PhoneNumber = PhoneNumber.Text;
            _partner.Email = Email.Text;

            _context.SaveChanges( );
            DialogResult = true;
        }
        private void Cancel_Click (object sender, RoutedEventArgs e)
        {
            var warning = MessageBox.Show("Вы уверены, что хотите выйти из окна?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (warning == MessageBoxResult.Yes)
                Close( );
        }

       
    }
}
