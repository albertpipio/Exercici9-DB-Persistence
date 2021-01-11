using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EmpleatsMySQLVSCode.Models
{
    public class EmpleatPositionViewModel
    {
        public List<Empleat> Empleats { get; set; }
        public SelectList Position { get; set; }
        public string EmpleatPosition { get; set; }
        public string SearchString { get; set; }
    }
}