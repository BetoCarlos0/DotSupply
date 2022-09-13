using System.Text.Json.Serialization;

namespace GerenciamentoMercadoria.Models
{
    public class ViewModelData
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int Quantidade { get; set; }

        [JsonPropertyName("data")]
        public List<int> ListData { get; set; } = new List<int>();

        [JsonPropertyName("label")]
        public string Nome { get; set; }
        public string borderColor { get; set; }

        [JsonIgnore]
        public int Months { get; set; }

        [JsonIgnore]
        public List<int> ListMonth { get; set; } = new List<int>();
    }
}
