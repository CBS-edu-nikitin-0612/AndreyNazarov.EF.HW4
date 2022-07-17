using System;
using System.Collections.Generic;

namespace Task1.Models
{
    public partial class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int PostionId { get; set; }
        public int StaffDetailsId { get; set; }

        public virtual Position Postion { get; set; } = null!;
        public virtual StaffDetail StaffDetails { get; set; } = null!;
    }

    public partial class Staff
    {
        public override string ToString()
        {
            return $"Id:{Id}\nName:{Name}\nPhoneNumber:{PhoneNumber}\nPositionId:{PostionId}\nStaffDetailsId:{StaffDetailsId}\n";
        }
    }
}
