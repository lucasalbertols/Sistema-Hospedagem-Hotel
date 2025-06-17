namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
             Hospedes = new List<Pessoa>();
        }

       public Reserva(Suite suite, int diasReservados)
{
            Suite = suite;
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
}

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

                if (Suite == null)
                {
                    throw new InvalidOperationException("A suíte precisa ser cadastrada antes de adicionar hóspedes.");
                }

               
                
                if (hospedes == null)

            {
                throw new ArgumentNullException(nameof(hospedes), "A lista de hóspedes não pode ser nula.");
            }

                  if (Suite.Capacidade == 0)
                {
                    throw new InvalidOperationException("A capacidade da suíte não foi definida corretamente.");
                }
                // Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            
                if (Suite != null && hospedes.Count <= Suite.Capacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    //Retorna uma exception caso a capacidade seja menor que o número de hóspedes recebido
                   
                    throw new ArgumentException("A quantidade de hóspedes excede a capacidade da suíte.");
                }

           
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            //Retorna a quantidade de hóspedes (propriedade Hospedes)
           
              return Hospedes != null ? Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            //Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            
            if (DiasReservados >= 10)
            {
                valor = valor * 0.90m;
            }

            return valor;
        }
    }
}