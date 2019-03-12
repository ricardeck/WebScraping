namespace Carfacts
{
    class Carro
    {

        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string anoFabricao { get; set; }
        public string anoModelo { get; set; }
        public string cor { get; set; }
        public string combustivel { get; set; }

        public Carro(string placa, string marca, string modelo, string anoFabricao, string anoModelo, string cor, string combustivel)
        {
            this.placa = placa;
            this.marca = marca;
            this.modelo = modelo;
            this.anoFabricao = anoFabricao;
            this.anoModelo = anoModelo;
            this.cor = cor;
            this.combustivel = combustivel;
        }
    }
}
