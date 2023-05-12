using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotometroPortal.Models
{
    public class LeituraCamera
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("idLocal")]
        public int IdLocal { get; set; }
        [JsonProperty("idCamera")]
        public int IdCamera { get; set; }
        [JsonProperty("lotacaoMaxima")]
        public int LotacaoMaxima { get; set; }
        [JsonProperty("numeroPessoas")]
        public int NumeroPessoas { get; set; }
        [JsonProperty("percentualDeLotacao")]
        public string PercentualDeLotacao { get; set; }
        [JsonProperty("dataInformacao")]
        public string DataInformacao { get; set; }
    }
}
