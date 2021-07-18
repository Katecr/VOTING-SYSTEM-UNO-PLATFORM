using System;
using System.Collections.Generic;
using System.Text;

namespace PUNTO_VOTACION.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
