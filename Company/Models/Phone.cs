#nullable disable

using System.Text.Json.Serialization;

namespace Company.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int CoworkerId { get; set; }
        [JsonIgnore]
        public virtual Coworker Coworker { get; set; }
    }
}
