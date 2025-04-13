namespace Demo.PL.ViewModels
{
    public class DepartmentEditViewModel
    {
        //public int Id { get; set; } 
        public string Name { get; set; } = null;
        public string Code { get; set; } = null;
        public DateOnly DateOfCreation { get; set; } // the date of creation 
        public string? Description { get; set; }
    }
}
