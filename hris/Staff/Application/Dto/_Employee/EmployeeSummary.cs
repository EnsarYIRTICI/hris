namespace hris.Staff.Application.Dto._Employee
{
    public class EmployeeSummary
    {
        public string FirstName { get; set; } // Çalışanın adı
        public string LastName { get; set; } // Çalışanın soyadı
        public string Email { get; set; } // Çalışanın tek e-posta adresi
        public DateTime? LastPasswordChange { get; set; } // Son şifre değişim tarihi
    }
}
