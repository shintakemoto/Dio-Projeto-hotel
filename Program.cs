using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa();
Pessoa p2 = new Pessoa();

// Cria a suíte
Suite suite = new Suite(tipoSuite: "", capacidade: 2, valorDiaria: 0);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 13);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

int fase = 1;
int numPax = 0;

while (fase == 1)
{
    Console.WriteLine("Bem vindo(s) ao Hotel Dotnet. Gostaria de um quarto para quantas pessoas?");
    string opcao = Console.ReadLine();
    switch (opcao)
    {
    case "1":
    case "2":
        numPax = Convert.ToInt32(opcao);
        fase++;
        break;
    default:
        Console.WriteLine("Só temos quartos para uma ou duas pessoas");
        break;
    }
}

while (fase == 2)
{
    Console.WriteLine("Escreva o nome de quem irá se hospedar");
    string nome1 = Console.ReadLine();
    hospedes.Add(p1);
    p1.Nome = nome1;
    if (numPax == 2)
    {
        Console.WriteLine("Escreva o nome do segundo hóspede");
        string nome2 = Console.ReadLine();
        hospedes.Add(p2);
        p2.Nome = nome2;
    }
    fase++;
}

while (fase == 3)
{
    Console.WriteLine("Digite 1 para quarto Standard (R$100,00) ou");
    Console.WriteLine("Digite 2 para quarto Premium (R$140,00)");
    string opcao = Console.ReadLine();
    switch (opcao)
    {
    case "1":
        suite.TipoSuite = "Standard";
        suite.ValorDiaria = 100;
        fase++;
        break;
    case "2":
        suite.TipoSuite = "Premium";
        suite.ValorDiaria = 140;
        fase++;
        break;
    default:
        break;
    }
}

while (fase == 4)
{
    Console.WriteLine("Serão quantas noites de hospedagem?");
    string opcao = Console.ReadLine();
    reserva.DiasReservados = Convert.ToInt32(opcao);
    fase++;
}

// Exibe a quantidade de hóspedes e o valor da diária

Console.WriteLine("----------RESUMO DA RESERVA:----------");
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
if (numPax == 1)
{
    Console.WriteLine($"{p1.Nome}");
}
else
{
    Console.WriteLine($"{p1.Nome} e {p2.Nome}");
}

Console.WriteLine("Categoria: " + suite.TipoSuite);
Console.WriteLine("Quantidade de diárias: " + reserva.DiasReservados);

if (reserva.HaDesconto())
{
    Console.WriteLine($"Desconto: R$ {Math.Round(reserva.VerificaDesconto(), 2)}");
}
Console.WriteLine($"Valor total da hospedagem: R${reserva.CalcularValorDiaria().ToString("N2")}");


