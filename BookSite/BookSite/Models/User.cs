//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Book = new HashSet<Book>();
            this.Buy = new HashSet<Buy>();
            this.Message = new HashSet<Message>();
        }
    
        public int UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> Admin { get; set; }
    
        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<Buy> Buy { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
