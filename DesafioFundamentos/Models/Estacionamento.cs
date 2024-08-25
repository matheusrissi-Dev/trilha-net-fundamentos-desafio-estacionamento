using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            // Completed: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            bool placaValida = true;

            while (placaValida)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine();

                //++++++ Completed - Validar se a placa escrita é valida antes de adicionar realmente a lista usando REGEX++++++
                placaValida = Regex.IsMatch(placa, "[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}|[A-Z]{3}\\-[0-9]{4}|[A-Z]{3}[0-9]{4}");

                if (!placaValida)
                {
                    System.Console.WriteLine("Placa invalida. Por favor digite novamente.");
                }
                else
                {
                    Console.WriteLine("Carro registrado com sucesso");
                    veiculos.Add(placa);
                    placaValida = false;
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine($"Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            // Pedir para o usuário digitar a placa e armazenar na variável placa

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                // Completed: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // Completed: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int hoasPermanencia = Convert.ToInt32(Console.ReadLine());
                decimal valorPagar = precoInicial + precoPorHora * hoasPermanencia;

                // Completed: Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorPagar}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Completed: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
