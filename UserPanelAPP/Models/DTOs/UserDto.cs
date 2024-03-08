namespace UserPanelAPP.Models.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Tcno { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly? BirthDate { get; set; }
        public bool? Status { get; set; }
    }
}
