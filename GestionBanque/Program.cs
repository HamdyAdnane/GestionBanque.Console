using GestionBanqueDbContext;
using GestionBanqueDbContext.Data;
using GestionBanqueDbContext.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection.Metadata;

class Program
{
    public static void Main(string[] args)
    {
        Compte compte = new Compte();
        compte.UserCommand();
    }
}