using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace WpfAppLaba1
{
    /// <summary>
    /// Логика взаимодействия для PageEmployee.xaml
    /// </summary>
    public partial class PageEmployee : Page
    {
        TitlePersonalEntities dataEntities = new TitlePersonalEntities();
        //TitlePersonalEntities dataTitles = new TitlePersonalEntities();
        public PageEmployee()
        {
            TitlePersonalEntities dataEntities = new TitlePersonalEntities();

            InitializeComponent();
            Save.IsEnabled = false;
            Edit.IsEnabled = true;
            Undo.IsEnabled = false;
            Search.IsEnabled = true;
            Add.IsEnabled = true;
            Delete.IsEnabled = true;
            SaveBar.IsEnabled = false;
            EditBar.IsEnabled = true;
            UndoBar.IsEnabled = false;
            SearchBar.IsEnabled = true;
            AddBar.IsEnabled = true;
            DeleteBar.IsEnabled = true;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var employees = dataEntities.Employee;
            //var titles = dataTitles.Title;
            var query =
                from employee in employees
                select employee;
                //new { employee.ID, employee.Surname, employee.Name, employee.Patronymic,
                //    employee.Telephone, employee.Email, employee.BirstDate, employee.TitleID };
            DataGrid.ItemsSource = query.ToList();
        }
        //public class ListTitle : ObservableCollection<Title>
        //{
        //    public ListTitle()
        //    {
        //        ObjectQuery<Title> titles = PageEmployee.dataEntities.Titles;
        //        var queryTitle = from title in titles select title;
        //        foreach (Title titl in queryTitle)
        //        {
        //            this.Add(titl);
        //        }
        //    }
        //}
        private bool isDirty = true;
        //Строка
        public static object DataEntitiesEmployee { get; internal set; }

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Отмена");
            isDirty = true;
        }
        private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Редактирование");
            isDirty = true;
        }
        private void SearchCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Поиск");
            isDirty = true;
        }
        private void AddCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Добавление");
            isDirty = true;
        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Удаление");
            isDirty = true;
        }
        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Сохранение");
            isDirty = true;
        }
        private void EditCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void DeleteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void AddCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void SearchCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void UndoCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = false;
            Edit.IsEnabled = true;
            Undo.IsEnabled = false;
            Search.IsEnabled = true;
            Add.IsEnabled = true;
            Delete.IsEnabled = true;
            SaveBar.IsEnabled = false;
            EditBar.IsEnabled = true;
            UndoBar.IsEnabled = false;
            SearchBar.IsEnabled = true;
            AddBar.IsEnabled = true;
            DeleteBar.IsEnabled = true;
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = true;
            Edit.IsEnabled = false;
            Undo.IsEnabled = true;
            Search.IsEnabled = false;
            Add.IsEnabled = false;
            Delete.IsEnabled = false;
            SaveBar.IsEnabled = true;
            EditBar.IsEnabled = false;
            UndoBar.IsEnabled = true;
            SearchBar.IsEnabled = false;
            AddBar.IsEnabled = false;
            DeleteBar.IsEnabled = false;
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            Save.IsEnabled = true;
            Edit.IsEnabled = false;
            Undo.IsEnabled = true;
            Search.IsEnabled = false;
            Add.IsEnabled = false;
            Delete.IsEnabled = false;

            SaveBar.IsEnabled = true;
            EditBar.IsEnabled = false;
            UndoBar.IsEnabled = true;
            SearchBar.IsEnabled = false;
            AddBar.IsEnabled = false;
            DeleteBar.IsEnabled = false;
        }
    }
}