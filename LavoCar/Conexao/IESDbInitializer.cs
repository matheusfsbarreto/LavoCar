using LavoCar.Controllers;
using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Conexao
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureCreated();

            //FUNCIONARIO
            if (context.Funcionarios.Any())
            {
                return;
            }
            var funcionario = new Funcionario[]
            {
                new Funcionario {NomeFuncionario="Fulano de Tal", EndFuncionario="Rua N numero 33", FoneFuncionario="79998122323"},
                new Funcionario {NomeFuncionario="Cicrano de Tal", EndFuncionario="Rua N numero 55", FoneFuncionario="79998122323"}
            };
            foreach (Funcionario d in funcionario)
            {
                context.Funcionarios.Add(d);
            }
            context.SaveChanges();

            //CLIENTE
            if (context.Clientes.Any())
            {
                return;
            }
            var cliente = new Cliente[]
            {
                new Cliente {NomeCliente="Gilberto Nunes", EndCliente="Rua B nº22", FoneCliente="79998122323"},
                new Cliente {NomeCliente="Samuca Endinho", EndCliente="Rua Salgueiro nº44", FoneCliente="79922122323"}
            };
            foreach (Cliente d in cliente)
            {
                context.Clientes.Add(d);
            }
            context.SaveChanges();

            //MARCAMODELO
            if (context.MarcaModelos.Any())
            {
                return;
            }
            var marcaModelo = new MarcaModelo[]
            {
                new MarcaModelo {DescMarcaModelo="Kia Cerato"},
                new MarcaModelo {DescMarcaModelo="BYD Dophin"},
                new MarcaModelo {DescMarcaModelo="VW Polo"},
                new MarcaModelo {DescMarcaModelo="VW Gol"},
                new MarcaModelo {DescMarcaModelo="Nissan Frontier"},
                new MarcaModelo {DescMarcaModelo="Nissan Versa"},
                new MarcaModelo {DescMarcaModelo="Toyota Corola"},
                new MarcaModelo {DescMarcaModelo="Toyota Hilux"},
                new MarcaModelo {DescMarcaModelo="Honda Civic"},
                new MarcaModelo {DescMarcaModelo="Honda HRV"}
            };
            foreach (MarcaModelo d in marcaModelo)
            {
                context.MarcaModelos.Add(d);
            }
            context.SaveChanges();

            //CARRO
            if (context.Carros.Any())
            {
                return;
            }
            var carro = new Carro[]
            {
                new Carro {Placa="AUC1234", Ano=2001, MarcaModeloID=1, ClienteID=1},
                new Carro {Placa="TOC1223", Ano=2011, MarcaModeloID=2, ClienteID=2}
            };
            foreach (Carro d in carro)
            {
                context.Carros.Add(d);
            }
            context.SaveChanges();

            //TIPO DE LAVAGEM
            if (context.TipoLavagens.Any()) {
                return;
            }
            var tipolavagem = new TipoLavagem[]
            {

                new TipoLavagem {DescTipoLav= "Lavagem Simples", PrecoTipoLav=20},
                new TipoLavagem {DescTipoLav= "Lavagem Simples com Cera", PrecoTipoLav=50}
            };
            foreach (TipoLavagem d in tipolavagem) {
                context.TipoLavagens.Add(d);
            }
            context.SaveChanges();

            //TIPO DE REPARO
            if (context.TipoReparos.Any())
            {
                return;
            }
            var tipoReparo = new TipoReparo[]
            {

                new TipoReparo {DescTipoReparo= "Funilaria Simples", PrecoTipoReparo=200},
                new TipoReparo {DescTipoReparo= "Pintura Simples", PrecoTipoReparo=200}
            };
            foreach (TipoReparo d in tipoReparo)
            {
                context.TipoReparos.Add(d);
            }
            context.SaveChanges();

        }

    }
}
