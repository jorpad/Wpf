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

namespace WpfAppLaba1.Model
{
    public class ListTitle : ObservableCollection<Title>
    {
        TitlePersonalEntities dataEntities = new TitlePersonalEntities();
        
        public ListTitle()
        {
            //var titles = new ObservableCollection<Title>();

            var queryTitle = 
                from Title in dataEntities.Titles
                select Title;

            foreach (Title titl in queryTitle)
            {
                this.Add(titl);
                //titles.Add(titl);
            }
        }

    }
}
