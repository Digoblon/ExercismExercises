public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int _mask;

    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        // Pega o valor numérico correspondente ao enum
        int valor = 1 << (int)allergen;
        return (_mask & valor) != 0;
    }

    public Allergen[] List()
    {
        var lista = new List<Allergen>();

        foreach (Allergen alergia in Enum.GetValues(typeof(Allergen)))
        {
            if (IsAllergicTo(alergia))
                lista.Add(alergia);
        }

        return lista.ToArray();
    }
}