//-----------------------------------------------------------------------
// <copyright file="IRepositorioPacienteSqlServer.cs" company="Steto">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------


namespace Steto.BusinessLayer.Administrador.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Steto.ValueObjectLayer;

    /// <summary>
    ///  Interface padrão para o repositório Paciente
    /// </summary>
    public interface IRepositorioPacienteSqlServer
    {
        /// <summary>
        /// Interface que cria um novo paciente para acesso ao sistema
        /// </summary>
        /// <param name="usuario">Objeto paciente</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool CriarPaciente(Paciente paciente);

        /// <summary>
        /// Interface que recupera um paciente do sistema
        /// </summary>
        /// <param name="idPaciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        ValueObjectLayer.Paciente RecuperarPaciente(int idPaciente);

        /// <summary>
        /// Interface que recupera um objeto paciente
        /// </summary>
        /// <param name="Paciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        ValueObjectLayer.Paciente RecuperarPaciente(Paciente paciente);

        /// <summary>
        /// Interface responsável por vincular um contato ao paciente
        /// </summary>
        /// <param name="contato">Objeto contato</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool VincularContatoAoPaciente(Contato contato);
        
        /// <summary>
        /// Interface responsável por recuperar todos os CBOs (Código Brasileiro de Ocupação)
        /// </summary>
        /// <returns>return uma lista com todos os objetos CBO</returns>
        IList<CBO> RecuperarCBO();

        /// <summary>
        /// Interface responsável por deletar os contatos de um paciente
        /// </summary>
        /// <param name="paciente">Objeto paciente</param>
        /// <returns>True se ocorrer tudo ok</returns>
        bool DeletarVinculoDeContatoAoPaciente(Paciente paciente);

        /// <summary>
        /// Interface que recupera um paciente
        /// </summary>
        /// <param name="paciente">Parametro para recuperar o paciente</param>
        /// <returns>Retorna um objeto Paciente</returns>
        List<Paciente> PesquisarPaciente(Paciente paciente);
    }
}
