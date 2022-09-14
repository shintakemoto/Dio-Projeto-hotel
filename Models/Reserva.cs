namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public decimal valorDesconto { get; set; }

        public bool desconto { get; set; }

        public Reserva(decimal ValorDesconto) 
        {
            ValorDesconto = valorDesconto;
         }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try 
            {
                Hospedes = hospedes;
            } 
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantPax= 0;        
            if (Hospedes.Count<=Suite.Capacidade)
            {
                 quantPax = Hospedes.Count;
            }
            else
            {
                quantPax = Hospedes.Count;
            }
            return quantPax;
           
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = Suite.ValorDiaria;

            if (HaDesconto() == false)
            {
                valor = Suite.ValorDiaria * DiasReservados;
            }
            else
            {
                valor = (Suite.ValorDiaria * DiasReservados) * 0.90M;
            }
            return valor;
        }    
        public bool HaDesconto()
        {
            if (DiasReservados < 10)
            {
                desconto = false;
            }
            else
            {
                desconto = true;
            }
            return desconto;
        }
        public decimal VerificaDesconto()
        {     
            if (desconto)
            {
             valorDesconto = (Suite.ValorDiaria * DiasReservados) - ((Suite.ValorDiaria * DiasReservados) * 0.90M);
            }
            return valorDesconto;
           
        }
    }
}