using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Steto.Util.Mensagens
{
    public enum Mensagem
    {
        CADASTRO,
        CADASTRO_NAO_REALIZADO,
        INATIVADO,
        INATIVADO_NAO_REALIZADO,
        BLOQUEADO,
        ALTERADO,
        ALTERADO_NAO_REALIZADO,
        EXCLUIDO,
        EXCLUIDO_NAO_REALIZADO,
        PERMISSAO,
        PERMISSAO_NAO_REALIZADA,
        PESQUISA_NAO_RETORNADA,
        VALOR_NAO_NUMERICO,
        LOGIN_INVALIDO,
        TAMANHO_SENHA_INVALIDA,
        SENHA_NAO_CONFERE,
        LOGIN_EXISTE,
        EMAIL_INVALIDO,
        EMAIL_NULO,
        CAMPO_OBRIGATORIO,
        PERFIL_EXISTENTE,
        PERFIL_NAO_EXISTENTE,
        TENTATIVA_LOGIN_EXCEDIDA,
        USUARIO_SEM_PERFIL,
        TELEFONE_NULO,
        SELECAO_INEXISTENTE
    }

    public static class MensagensValor
    {

        public static string GetStringValue(string valor)
        {
            switch (valor)
            {
                case "CADASTRO":
                    return "Cadastro realizado com sucesso!";
                case "CADASTRO_NAO_REALIZADO":
                    return "Cadastro não pode ser realizado!";
                case "INATIVADO":
                    return "Inativação efetivada com sucesso!";
                case "INATIVADO_NAO_REALIZADO":
                    return "Inativação não pode ser realizada!";
                case "ALTERADO":
                    return "Alteração efetivada com sucesso!";
                case "ALTERADO_NAO_REALIZADO":
                    return "Alteração não pode ser realizada!";
                case "EXCLUIDO":
                    return "Exclusão efetivada com sucesso!";
                case "EXCLUIDO_NAO_REALIZADO":
                    return "Exclusão não pode ser realizada!";
                case "PERMISSAO":
                    return "Permissão efetivada com sucesso!";
                case "PERMISSAO_NAO_REALIZADA":
                    return "Permissão não pode ser realizada!";
                case "PESQUISA_NAO_RETORNADA":
                    return "Nenhum registro retornado.";
                case "VALOR_NAO_NUMERICO":
                    return "Valor apenas numerico!";
                case "LOGIN_INVALIDO":
                    return "Login ou Senha inválida!";
                case "LOGIN_EXISTE":
                    return "Este login ja existe no sistema! /n/r Por favor escolha outro login!";
                case "TAMANHO_SENHA_INVALIDA":
                    return "Senha inválida! \n\r Só pode ser cadastrada com o mínimo de 6 caracteres!";
                case "SENHA_NAO_CONFERE":
                    return "Senha não confere!";
                case "EMAIL_INVALIDO":
                    return "Email inválido!";
                case "EMAIL_NULO":
                    return "O campo email está vazio, não irá poder enviar email para este usuário!";
                case "CAMPO_OBRIGATORIO":
                    return "Existe algum campo obrigatório sem preenchimento!";
                case "PERFIL_EXISTENTE":
                    return "O perfil que está tentando criar já existe!";
                case "PERFIL_NAO_EXISTENTE":
                    return "Não existe perfil!";
                case "TENTATIVA_LOGIN_EXCEDIDA":
                    return "Tentativa de login excedida, para a sua segurança o usuário foi boqueado. Favor contactar o Administrador!";
                case "BLOQUEADO":
                    return "Usuário encontra-se bloqueado. Favor contactar o Administrador!";
                case "USUARIO_SEM_PERFIL":
                    return "Usuário encontra-se sem perfil definido. Favor contactar o Administrador!";
                case "TELEFONE_NULO":
                    return "O campo telefone está vazio, favor preencher!";
                case "SELECAO_INEXISTENTE":
                    return "Seleção inexistente!";
                default:
                    return string.Empty;
            }

        }
    }
}
