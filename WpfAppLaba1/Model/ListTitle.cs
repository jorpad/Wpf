using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppLaba1.Model
{
    public class ListTitle : System.Collections.ObjectModel.ObservableCollection<Title>
    {
        TitlePersonalEntities dataEntities = new TitlePersonalEntities();
        public ListTitle()
        {
            var titles = dataEntities.Title;
            var queryTitle = from title in titles
                             select title;
            foreach (Title titl in queryTitle)
            {
                this.Add(titl);
            }
        }

    }
}
