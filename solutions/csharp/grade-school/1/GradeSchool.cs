using System;
using System.Collections.Generic;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _school = new();

    // Adiciona um aluno à grade
    // Retorna true se foi adicionado, false se já existe em qualquer grade
    public bool Add(string student, int grade)
    {
        // Verifica se o aluno já existe em qualquer grade
        foreach (var alunos in _school.Values)
        {
            if (alunos.Contains(student))
                return false; // já existe na escola
        }

        // Se a grade ainda não existe, cria a lista
        if (!_school.ContainsKey(grade))
        {
            _school[grade] = new List<string>();
        }

        _school[grade].Add(student);
        return true; // aluno adicionado com sucesso
    }

    // Retorna alunos de uma grade, ordenados alfabeticamente
    public IEnumerable<string> Grade(int grade)
    {
        if (!_school.ContainsKey(grade))
            return new List<string>();

        var alunos = new List<string>(_school[grade]);
        alunos.Sort();
        return alunos;
    }

    // Retorna todos os alunos da escola, ordenados por grade e por nome
    public IEnumerable<string> Roster()
    {
        var result = new List<string>();

        // Ordena as grades
        var grades = new List<int>(_school.Keys);
        grades.Sort();

        foreach (var grade in grades)
        {
            var alunos = new List<string>(_school[grade]);
            alunos.Sort();

            foreach (var aluno in alunos)
            {
                result.Add(aluno);
            }
        }

        return result;
    }
}
