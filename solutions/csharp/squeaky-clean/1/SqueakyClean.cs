using System.Text;
public static class Identifier
{
    public static string Clean(string identifier)
    {
        if (identifier =="")
            return "";
        
        StringBuilder sb = new StringBuilder(identifier);
 
        for (int i = 0; i < sb.Length; i++)
        {
            if(char.IsWhiteSpace(sb[i]))
            {
                sb[i] = '_';
                continue;
            }
            if (char.IsControl(sb[i]))
            {
                sb.Remove(i,1);
                sb.Insert(i,"CTRL");
                i+=3;
                continue;
            }
            if (sb[i] == '-')
            {
                sb.Remove(i, 1);  // remove o '-' na posição i
                sb[i] = char.ToUpper(sb[i]); // opcional: transformar o próximo caractere
                i--;
                continue;
            }
            if(!char.IsLetter(sb[i]))
            {
                sb.Remove(i,1);
                i--;
                continue;
            }
            if((char.IsLower(sb[i])) && (sb[i]>= '\u0370' && sb[i] <= '\u03FF'))
            {
                sb.Remove(i,1);
                i--;
                continue;
            }
        }

        return sb.ToString();
        
    }
}
