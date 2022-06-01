using System;
using System.Collections;
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

namespace Animals
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        //private DBModel model;
        private Presenter presenter;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new Presenter(this);
            AddButton.Click += (s, e) => presenter.AddAnimal();
            EditButton.Click += (s, e) => presenter.EditAnimal();
            DeleteButton.Click += (s, e) => presenter.DeleteAnimal();
            DownloadCsvButton.Click += (s, e) => presenter.DownloadCsv();
            DownloadTxtButton.Click += (s, e) => presenter.DownloadTxt();
            AnimalsList.SelectedCellsChanged += (s, e) => presenter.PrefillFields();
        }

        ObservableCollection<Animal> IView.Animals { set => AnimalsList.ItemsSource = value; }
        List<string> IView.AddClass 
        { 
            get
                {
                var list = AddClass.ItemsSource;
                List<string> stringList = new List<string>();
                foreach (var item in list)
                {
                    stringList.Add(item.ToString());
                }
                return stringList;
            }
            set
            { AddClass.ItemsSource = value; } 
        }
        string IView.SelectedAddClass
        {
            get
            {
                if (AddClass.SelectedItem != null)
                {
                    return AddClass.SelectedItem.ToString();
                }
                else return "";
               
            } 
        }
        string IView.AddName { get => AddName.Text; set => AddName.Text=value; }
        string IView.AddFamily { get => AddFamily.Text; set => AddFamily.Text = value; }
        string IView.AddPopulation { get => AddPopulation.Text; set => AddPopulation.Text = value; }
        string IView.AddPlace { get => AddPlace.Text; set => AddPlace.Text = value; }


        List<string> IView.EditClass
        {
            get
            {
                var list = EditClass.ItemsSource;
                List<string> stringList = new List<string>();
                foreach (var item in list)
                {
                    stringList.Add(item.ToString());
                }
                return stringList;
            }
            set
            { EditClass.ItemsSource = value; }
        }
        object IView.SelectedEditClass
        {
            get
            {
                if (EditClass.SelectedItem != null)
                {
                    return EditClass.SelectedItem;
                }
                else return "";

            }
            set
            {
                EditClass.SelectedItem = value;
            }
        }
        string IView.EditName { get => EditName.Text; set => EditName.Text = value; }
        string IView.EditFamily { get => EditFamily.Text; set => EditFamily.Text = value; }
        string IView.EditPopulation { get => EditPopulation.Text; set => EditPopulation.Text = value; }
        string IView.EditPlace { get => EditPlace.Text; set => EditPlace.Text = value; }
        object IView.SelectedAnimal
        {
            get => AnimalsList.SelectedItem;
        }

        string IView.DeleteLable { set => DeleteLable.Text = value; }
    
    }
}
