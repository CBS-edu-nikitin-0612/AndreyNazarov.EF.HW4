using Microsoft.Data.SqlClient;
using Task1.Models;
using Microsoft.EntityFrameworkCore;

using( MyJoinsDBContext context = new MyJoinsDBContext())
{
    SqlParameter parameter = new SqlParameter("@id", 1);
    
    foreach (Staff staff in context.Staff.FromSqlRaw(@"EXEC GetStaff @id", parameter))
    {
        Console.WriteLine(staff);
    }
}

//CREATE PROCEDURE[dbo].[GetStaff]
//@id int = 0
//AS
//	SELECT * FROM [dbo].Staff
//    WHERE Id  = @id