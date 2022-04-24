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
using AFO_Transport.Model;
using Microsoft.EntityFrameworkCore;

namespace AFO_Transport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyContext _context = new MyContext();

        private Transport transportSelected ;
        public MainWindow()
        {
            InitializeComponent();

            //dgPersonne.ItemsSource = _context.Personnes.Local.ToObservableCollection();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
           _context.Transports.Include(x => x.Personnes).Load();
            dgTransport.ItemsSource = _context.Transports.Local.ToObservableCollection();
            Type.ItemsSource = new List<string>() { "Train", "Avion", "Bateau", "Soucoupe volante"};
        }

        private void BtnAjout_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNom.Text) == false || string.IsNullOrEmpty(TxtPrenom.Text))
            {
                _context.Personnes.Add(new Personne() { Nom = TxtNom.Text, Prenom = TxtPrenom.Text, Sexe = Sexe.Text, IdTransportNavigation = (Transport)dgTransport.SelectedItem, OptionSm = LblOptionSm.Content.ToString() });
                _context.SaveChanges();
            }
            
        }

        private void BtnSup_Click(object sender, RoutedEventArgs e)
        {
            if (dgPersonne.SelectedItem != null)
            {
                _context.Remove((Personne)dgPersonne.SelectedItem);
                _context.SaveChanges();
            }
        }
        
        private void Rbtn_Checked(object sender, RoutedEventArgs e)
        {
            if (RbtnTrain.IsChecked == true)
            {
                dgTransport.ItemsSource = _context.Transports.Local.ToObservableCollection().Where(x => x.TypeTransport == "Train");

            }
            else if (RbtnAvion.IsChecked == true)
            {
                dgTransport.ItemsSource = _context.Transports.Local.ToObservableCollection().Where(x => x.TypeTransport == "Avion");
            }
            else if (RbtnBateau.IsChecked == true)
            {
                dgTransport.ItemsSource = _context.Transports.Local.ToObservableCollection().Where(x => x.TypeTransport == "Bateau");
            }
            else
            {
                dgTransport.ItemsSource = _context.Transports.Local.ToObservableCollection().Where(x => x.TypeTransport == "Soucoupe Volante");
            }

        }
        
        private void RbtnSM_Checked(object sender, RoutedEventArgs e)
        {
            if (RbtnSM.IsChecked == true)
            {
                LblOptionSm.Content = 'O';
            }
        }

        private void dgTransport_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            transportSelected = (Transport)dgTransport.SelectedItem;
            dgPersonne.ItemsSource = transportSelected?.Personnes.OrderBy(x => x.Identifiant);
        }

        private void BtnAjoutTrans_Ajout(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Num.Text) == false || string.IsNullOrEmpty(Passager.Text) || string.IsNullOrEmpty(Depart.Text) || string.IsNullOrEmpty(Arrivee.Text))
            {
                _context.Transports.Add(new Transport { Numero = Num.Text, NombrePassagerMax = Passager.Text, Depart = Depart.Text, Arrivee = Arrivee.Text, TypeTransport = (string)Type.SelectedItem });
                _context.SaveChanges();
            }
        }

        private void BtnSupTrans(object sender, RoutedEventArgs e)
        {
            if (dgTransport.SelectedItem != null)
            {
                _context.Remove((Transport)dgTransport.SelectedItem);
                _context.SaveChanges();
            }

        }
    }
}
