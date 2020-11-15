using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTOs
{
    public class MakeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> ModelNames { get; set; }
    }
}
