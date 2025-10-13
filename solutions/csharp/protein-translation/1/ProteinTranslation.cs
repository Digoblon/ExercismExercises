public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        string codon;
        List<string> listaProteinas = new List<string>();
        for (int i = 0;i < strand.Length;i+=3)
        {
            if(i+3<=strand.Length)
            {
                codon = strand.Substring(i,3);
            }
            else
                break;
            if (codon == "AUG")
            {
                listaProteinas.Add("Methionine");
            }
            if((codon == "UUU") || (codon=="UUC"))
            {
                listaProteinas.Add("Phenylalanine");
            }
            if((codon =="UUA") || (codon=="UUG"))
            {
                listaProteinas.Add("Leucine");
            }
            if((codon == "UCU")|| (codon== "UCC") || (codon== "UCA") || (codon == "UCG"))
            {
                listaProteinas.Add("Serine");
            }
            if((codon == "UAU") || (codon == "UAC"))
            {
                listaProteinas.Add("Tyrosine");
            }
            if((codon == "UGU") || (codon == "UGC"))
            {
                listaProteinas.Add("Cysteine");
            }
            if((codon == "UGG"))
            {
                listaProteinas.Add("Tryptophan");
            }
            if((codon == "UAA") || (codon == "UAG") || (codon == ""))
            {
                break;
            }
        }
        string[] proteinasArray = listaProteinas.ToArray();
        return proteinasArray;
    }
}