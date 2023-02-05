using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warhammer_Collection.Models
{
    public class Mini
    {
        public int Id { get; set; }

        [Display(Name = "Game")]
        public string game { get; set; } = string.Empty;

        [Display(Name = "Faction")]
        public string faction { get; set; } = string.Empty;

        [Display(Name = "Model Name")]
        public string modelName { get; set; } = string.Empty;
        [Display(Name = "Amount")]
        public int amount { get; set; }



    }
}
