using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Services.Client;
using WpfAppLaba1.Model;

namespace WpfAppLaba1
{
    /// <summary>
    /// Логика взаимодействия для PageEmployee.xaml
    /// </summary>
    public partial class PageEmployee : Page
    {
        TitlePersonalEntities dataEntities = new TitlePersonalEntities();
        ObservableCollection<Employee> ListEmployee = new ObservableCollection<Employee>();
        public PageEmployee()
        {
            TitlePersonalEntities dataEntities = new TitlePersonalEntities();
            InitializeComponent();
            Save.IsEnabled = false;
            //Edit.IsEnabled = true;
            Undo.IsEnabled = false;
            Search.IsEnabled = true;
            Add.IsEnabled = true;
            Delete.IsEnabled = true;
            SaveBar.IsEnabled = false;
            //EditBar.IsEnabled = true;
            UndoBar.IsEnabled = false;
            SearchBar.IsEnabled = true;
            AddBar.IsEnabled = true;
            DeleteBar.IsEnabled = true;
        }
        public void ReZapros()
        {
            var employees = dataEntities.Employees;
            var query =
                from employee in employees

                select employee;
            DataGridEmployee.ItemsSource = query.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReZapros();
        }
        private bool isDirty = true;
        public static object DataEntitiesEmployee { get; internal set; }
        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Отмена");
            isDirty = true;
        }
        private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridEmployee.IsReadOnly = false;
            DataGridEmployee.BeginEdit();
            isDirty = true;
            Edit.IsEnabled = false;
            EditBar.IsEnabled = false;
            Save.IsEnabled = true;
            SaveBar.IsEnabled = true;
        }
        private void SearchCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = true;
            Search.IsEnabled = true;
            SearchBar.IsEnabled = true;
            if (BorderFind.Visibility == System.Windows.Visibility.Visible)
            {
                BorderFind.Visibility = System.Windows.Visibility.Hidden;
                Search.IsEnabled = true;
                SearchBar.IsEnabled = true;
            }
            else
            if (BorderFind.Visibility == System.Windows.Visibility.Hidden)
            {
                BorderFind.Visibility = System.Windows.Visibility.Visible;
                Search.IsEnabled = true;
                SearchBar.IsEnabled = true;
            }
        }
        private void AddCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Employee employee = new Employee();
            try
            {
                employee.ID = dataEntities.Employees.Count() + 1;
                employee.Surname = "не задано";
                employee.Name = "не задано";
                employee.Patronymic = "не задано";
                employee.Telephone = 0;
                employee.BirstDate = DateTime.Parse("2001-12-12");
                employee.Email = "не задано";
                employee.TitleID = 0;
                dataEntities.Employees.Add(employee);
                dataEntities.SaveChanges();
                DataGridEmployee.BeginEdit();
                ReZapros();
            }
            catch
            {
                employee.ID = dataEntities.Employees.Count() + 2;
                employee.Surname = "не задано";
                employee.Name = "не задано";
                employee.Patronymic = "не задано";
                employee.Telephone = 0;
                employee.BirstDate = DateTime.Parse("2001-12-12");
                employee.Email = "не задано";
                employee.TitleID = 0;
                dataEntities.Employees.Add(employee);
                dataEntities.SaveChanges();
                DataGridEmployee.BeginEdit();
                ReZapros();
            }
        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Employee emp = DataGridEmployee.SelectedItem as Employee;
            if (emp != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить сотрудника? ", "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    dataEntities.Employees.Remove(emp);
                    DataGridEmployee.SelectedIndex = DataGridEmployee.SelectedIndex == 0 ? 1 : DataGridEmployee.SelectedIndex - 1;
                    ListEmployee.Remove(emp);
                    dataEntities.SaveChanges();
                    ReZapros();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }
        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            dataEntities.SaveChanges();
            isDirty = true;
            DataGridEmployee.IsReadOnly = true;
            Save.IsEnabled = false;
            SaveBar.IsEnabled = false;
            Edit.IsEnabled = true;
            EditBar.IsEnabled = true;
            ReZapros();
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
            //Save.IsEnabled = false;
            //Edit.IsEnabled = true;
            //Undo.IsEnabled = false;
            //Search.IsEnabled = true;
            //Add.IsEnabled = true;
            //Delete.IsEnabled = true;
            //SaveBar.IsEnabled = false;
            //EditBar.IsEnabled = true;
            //UndoBar.IsEnabled = false;
            //SearchBar.IsEnabled = true;
            //AddBar.IsEnabled = true;
            //DeleteBar.IsEnabled = true;
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            //Save.IsEnabled = true;
            //Edit.IsEnabled = false;
            //Undo.IsEnabled = true;
            //Search.IsEnabled = false;
            //Add.IsEnabled = false;
            //Delete.IsEnabled = false;
            //SaveBar.IsEnabled = true;
            //EditBar.IsEnabled = false;
            //UndoBar.IsEnabled = true;
            //SearchBar.IsEnabled = false;
            //AddBar.IsEnabled = false;
            //DeleteBar.IsEnabled = false;
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            //Save.IsEnabled = true;
            //Edit.IsEnabled = false;
            //Undo.IsEnabled = true;
            //Search.IsEnabled = false;
            //Add.IsEnabled = false;
            //Delete.IsEnabled = false;
            //SaveBar.IsEnabled = true;
            //EditBar.IsEnabled = false;
            //UndoBar.IsEnabled = true;
            //SearchBar.IsEnabled = false;
            //AddBar.IsEnabled = false;
            //DeleteBar.IsEnabled = false;
        }
        private void txtbxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReZapros();
        }
        private void FindTitle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListEmployee.Clear();
                Title title = cbxTitle.SelectedItem as Title;
                var employees = dataEntities.Employees;
                var queryEmployee = from employee in employees
                                    where employee.TitleID == title.ID
                                    select employee;
                foreach (Employee emp in queryEmployee)
                {
                    ListEmployee.Add(emp);
                }
                DataGridEmployee.ItemsSource = ListEmployee;
                Search.IsEnabled = true;
                SearchBar.IsEnabled = true;
            }
            catch
            {

            }
        }
        private void FindSurname_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string surname = this.txtbxSurname.Text;
                TitlePersonalEntities dataEntities = new TitlePersonalEntities();
                Employee emp = new Employee();
                ListEmployee.Clear();
                emp.Surname = txtbxSurname.Text;
                var queryEmployee = from employee in dataEntities.Employees
                                    where employee.Surname == surname
                                    select employee;

                foreach (var item in queryEmployee.ToList())
                {
                    if (item.Surname.Contains(txtbxSurname.Text) == true)
                        ListEmployee.Add(item);
                }
                DataGridEmployee.ItemsSource = ListEmployee;
                Search.IsEnabled = true;
                SearchBar.IsEnabled = true;
        }
            catch
            { 

            }
        }
    }
}