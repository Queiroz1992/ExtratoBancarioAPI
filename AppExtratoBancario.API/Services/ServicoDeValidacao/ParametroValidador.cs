namespace AppExtratoBancario.API.Services.ServicoDeValidacao
{
    public class ParametroValidador : IParametroValidador
    {
        public void ValidarDias(string dias)
        {
            if (!int.TryParse(dias, out int diasInt) || diasInt < 1 || diasInt > 20)
            {
                throw new ArgumentException("O parâmetro 'dias' deve ser um número inteiro entre 1 e 20.");
            }
        }
    }
}
