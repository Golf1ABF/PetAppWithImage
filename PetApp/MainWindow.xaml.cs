using System.ComponentModel;
using System.IO;
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

namespace PetApp
{
    public partial class MainWindow : Window
    {
        List<Pet> pets;

        public MainWindow()
        {
            InitializeComponent();
            pets = new List<Pet>();
            var sr = new StreamReader("../../../src/animals.txt", System.Text.Encoding.UTF8);
            while (!sr.EndOfStream) 
            {
                pets.Add(new Pet(sr.ReadLine()));
            }
            foreach (var item in pets)
            {
                lbx.Items.Add($"{item.Name}, Kor: {item.Age}, Szín: {item.Color}");    
            }
            lbx.Items.SortDescriptions.Add(
            new SortDescription("", ListSortDirection.Ascending));
            lbx.SelectedItem = lbx.Items.GetItemAt(0);
        }

        private void Fav_Click(object sender, RoutedEventArgs e)
        {
            if (!lbxFav.Items.Contains(lbx.SelectedItem))
            {
                lbxFav.Items.Add(lbx.SelectedItem);
            }
            else MessageBox.Show("Már a kedvencek között van ez az állat!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            
            if (lbxFav.SelectedItem != null)
            {
                lbxFav.Items.Remove(lbxFav.SelectedItem);
            }
            else MessageBox.Show("Nincs mit törölni!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            if (lbx.SelectedItem != null)
            {
                var selectedPetInfo = lbx.SelectedItem.ToString().Split(',')[0].Trim();
                var selectedPet = pets.Find(pet => pet.Name == selectedPetInfo);

                if (selectedPet != null)
                {
                    string currentDirectory = Directory.GetCurrentDirectory();
                    imgPet.Source = new BitmapImage(new Uri(System.IO.Path.Combine(currentDirectory, $@"..\..\..\IMAGES\{selectedPet.Picture}")));
                }
            }
        }
    }
}