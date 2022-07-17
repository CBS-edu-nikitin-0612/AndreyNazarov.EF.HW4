using Microsoft.EntityFrameworkCore;
using TaskAdd.Models;

using (HW4_TaskAddContext context = new HW4_TaskAddContext())
{
    Console.WriteLine("Products:");
    foreach (Product product in context.Products.Include(p => p.OrderDetails))
    {
        Console.WriteLine(product);
    }
}
