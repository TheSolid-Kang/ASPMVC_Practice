using System.ComponentModel.DataAnnotations;

namespace ASPMVC_Practice.Models
{
    public class BibleModel
    {
        [Key]
        public int BibleSeq { get; set; }
        public string? Testament { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public string? Descript { get; set; }
    }
}
