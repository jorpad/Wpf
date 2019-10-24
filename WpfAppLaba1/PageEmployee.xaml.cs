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

namespace WpfAppLaba1
{
    /// <summary>
    /// Логика взаимодействия для PageEmployee.xaml
    /// </summary>
    public partial class PageEmployee : Page
    {
        //ObservableCollection<Employee> ListEmployee = new ObservableCollection<Employee>();
        //public static TitlePresonalEntities DataEntitiesEmployee { get; set; }
        public PageEmployee()
        {
            //DataEntitiesEmployee = new TitlePresonalEntities();
            InitializeComponent();          
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        //    ObjectQuery<Employee> employees = DataEntitiesEmployee.Employees;
        //    var queryEmployee = from employee
        //                        in employees
        //                        orderby employee.Surname
        //                        select employee;
        //    foreach (Employee emp in queryEmployee)
        //    {
        //        ListEmployee.Add(emp);
        //    }
        //    DataGridEmployee.ItemsSource = ListEmployee;
        }
        private bool isDirty = true;
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
            e.CanExecute = !isDirty;
        }
        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }
        private void DeleteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
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
            e.CanExecute = !isDirty;
        }
    }
}