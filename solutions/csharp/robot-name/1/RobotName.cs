using System;

public class Robot
{
    private static readonly Random rnd = new System.Random();
    private static readonly HashSet<string> NomesUsados = new HashSet<string>();
    private string _nome = "";

    public string Name
    {
        get
        {
            if (_nome == "")
            {
                _nome = GerarNomeUnico();
            }
            return _nome;
        }
    }

    public void Reset()
    {
        // Remove o nome atual do conjunto (opcional)
        if (_nome != "")
        {
            NomesUsados.Remove(_nome);
            _nome = "";
        }
    }
    
    private string GerarNomeUnico()
    {
        string nome;
        do
        {
          nome = GerarNomeAleatorio();
        } while (!NomesUsados.Add(nome)); // .Add retorna false se já existir

        return nome;
    }

    private string GerarNomeAleatorio()
    {
        // Letras A-Z
        char letra1 = (char)('A' + rnd.Next(0, 26));
        char letra2 = (char)('A' + rnd.Next(0, 26));

        // Números 000–999
        int numero = rnd.Next(0, 1000);
        string codigo = numero.ToString("D3");

        return $"{letra1}{letra2}{codigo}";
    }

}
