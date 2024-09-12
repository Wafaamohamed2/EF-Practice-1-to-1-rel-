using NewEF;


internal class Program
{
    private static void Main(string[] args)
    {
        var _context = new ApplicationDbContext();

        
        _context.SaveChanges();
    }
}