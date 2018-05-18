using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models.Entities
{
    public class CropsFeedback
    {
        public int CropsFeedbackId { get; set; }

        public string Feedback { get; set; }

        public DateTime? ThisDateTime { get; set; }

        public int CropId { get; set; }

        public int? Rating { get; set; }
    }
}
