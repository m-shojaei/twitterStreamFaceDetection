using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwiiterFaceDetectionApp.Models
{
    public class TwittImageViewModel
    {
        public string Url { get; set; }
        public short MaleCount { get; set; }
        public short FemaleCount { get; set; }
    }
}
