using System;
using System.Collections.Generic;

namespace Task1.Models
{
    public partial class StaffDetail
    {
        public StaffDetail()
        {
            staff = new HashSet<Staff>();
        }

        public int Id { get; set; }
        public string MaritalStatus { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<Staff> staff { get; set; }
    }
}
