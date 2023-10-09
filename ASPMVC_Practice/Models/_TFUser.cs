using Org.BouncyCastle.Ocsp;
using System.ComponentModel.DataAnnotations;

namespace ASPMVC_Practice.Models
{
    public class _TFUser
    {

        public int ChurchSeq { get; set; }
        [Key]
        public int UserSeq           {get;set;}
        public string ResidID           {get;set;}
        public string UserName          {get;set;}
        public string Empid             {get;set;}
        public string IsAdministrator   {get;set;}
        public string IsSaved           {get;set;}
        public int LastUserSeq       {get;set;}
        public DateTime LastDateTime      {get;set;}
    }
}
