using System.Collections.Generic;

namespace Service.DTOs
{
    public class MakeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> ModelNames { get; set; }
    }
}
