using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using WpfExam.Models;

namespace WpfExam
{
    public partial class MainWindow : Window
    {
        ItemContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ItemContext();
            db.Items.Load();
            itemsGrid.ItemsSource = db.Items.Local.ToBindingList();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < itemsGrid.SelectedItems.Count; i++)
                {
                    Item phone = itemsGrid.SelectedItems[i] as Item;
                    if (phone != null)
                    {
                        db.Items.Remove(phone);
                    }
                }
            }
            db.SaveChanges();
        }
        
        private void SaveChanges(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Enter)
                {
                    db.SaveChanges();
                }

                if (e.Key == Key.Delete)
                {
                    if (itemsGrid.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < itemsGrid.SelectedItems.Count; i++)
                        {
                            Item phone = itemsGrid.SelectedItems[i] as Item;
                            if (phone != null)
                            {
                                db.Items.Remove(phone);
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
}
