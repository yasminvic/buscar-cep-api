using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ResponseApiDTO
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }

        public ResponseApiDTO MapToDTO(ResponseApi responseApi)
        {
            return new ResponseApiDTO()
            {
                cep = responseApi.Cep,
                logradouro = responseApi.Logradouro,
                complemento = responseApi.Complemento,
                bairro = responseApi.Bairro,
                localidade = responseApi.Localidade,
                uf = responseApi.Uf,
                ibge = responseApi.Ibge,
                gia = responseApi.Gia,
                ddd = responseApi.Ddd,
                siafi = responseApi.Siafi

            };
        }
        
    }
}
