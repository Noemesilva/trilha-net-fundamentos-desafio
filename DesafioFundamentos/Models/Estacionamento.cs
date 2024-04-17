namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private decimal precoPorMinuto = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.precoPorMinuto = precoPorHora / 60;
        }

        public void AdicionarVeiculo()
        {
            
            string placaVeiculo;
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            placaVeiculo = Console.ReadLine();
            veiculos.Add(placaVeiculo);
        }

        public void RemoverVeiculo()
        {
            string placa = "";
            Console.WriteLine("Digite a placa do veículo para remover:");
            placa = Console.ReadLine();

            int horas = 0;
            int minutos = 0;
            decimal valorTotal = 0;

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                horas = int.Parse(Console.ReadLine());

                do
                {
                    Console.WriteLine("Por favor, insira a quantiade de minutos (0 a 59) que o veículo permaneceu estacionado: ");
                    minutos = int.Parse(Console.ReadLine());

                } while (minutos < 0 || minutos > 59);

                valorTotal = precoInicial + precoPorHora * horas + precoPorMinuto * minutos;

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("0.00")}");
                veiculos.Remove(placa);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            Console.WriteLine("Os veículos estacionados são:");
            if (veiculos.Any())
            {
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
