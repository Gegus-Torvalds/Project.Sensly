using System.ComponentModel.DataAnnotations;

namespace Sensly.Models
{
    public class ClickData
    {
        [Required]
        public int NumberOfClicks {  get; set; }
    }
}
