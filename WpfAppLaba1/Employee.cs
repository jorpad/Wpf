//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppLaba1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public System.DateTime BirstDate { get; set; }
        public string TitleID { get; set; }
    
        public virtual Title Title { get; set; }
    }
}
