//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace personal_task.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersCircle
    {
        public int UserID { get; set; }
        public int CicleID { get; set; }
        public string C_ { get; set; }
    
        public virtual Circle Circle { get; set; }
        public virtual User User { get; set; }
    }
}
