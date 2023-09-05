using System;

namespace Application.Contract.DTOs.User
{
    public class LoginValidationDto
    {
        public int UserID { get; set; }
        public bool TokenIsValid { get; set; }
        public DateTime TokenCreate { get; set; }
        public DateTime TokenDateValid { get; set; }
        public bool IsLogin { get; set; }
        public bool IsActive { get; set; }

    }

}
