using System;

namespace Domain
{
    public class Token
    {
        public int TokenID { get; set; }
        public int UserID { get; set; }

        public string TokenStr { get; set; }
        public Guid TokenGuid { get; set; }
        public bool TokenIsValid { get; set; }
        public DateTime TokenCreate { get; set; }
        public DateTime TokenDateValid { get; set; }

    }

}
