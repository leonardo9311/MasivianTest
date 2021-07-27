
using System.Text.Json.Serialization;
namespace MasivianPrueba.Core.Entitiy
{
    public  class Bet :BaseEntity
    {
        public int number { get; set; }
        public int amount { get; set; }
        public string idUser { get; set; }
        [JsonIgnore]
        public int idRoullette { get; set; }
        [JsonIgnore]
        public Roulette Roulette { get; set; }
    }
}
