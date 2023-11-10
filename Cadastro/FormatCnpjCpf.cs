/*
 *
 * public static string FormatCPF(string CPF)
 *        Formata uma string CPF 
 *        Informar uma string sem formatacao com o codigo do CPF 
 *        Exemplo '01122233344'
 *        
 * public static string SemFormatacao(string Codigo)
 *        Retira formatacao de uma string CNPJ ou CPF 
 *        Informar uma string formatada com o codigo do CNPJ ou CPF 
 *        Exemplo '99.999.999/9999-99' ou '111.222.333-44'
 *        
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class FormatCnpjCpf
{        
    /// Formatar uma string CPF    
    /// <param name="CPF">string CPF sem formatacao</param>
    /// <returns>string CPF formatada</returns>
    /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>

    public static string FormatCPF(string CPF)
    {
        return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
    }    
    /// Retira a Formatacao de uma string CNPJ/CPF
    /// <param name="Codigo">string Codigo Formatada</param>
    /// <returns>string sem formatacao</returns>
    /// <example>Recebe '99.999.999/9999-99' Devolve '99999999999999'</example>

    public static string SemFormatacao(string Codigo)
    {
        return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
    }
}
public static class FormatCnpjRg
{
    /// Formatar uma string CPF    
    /// <param name="CPF">string CPF sem formatacao</param>
    /// <returns>string CPF formatada</returns>
    /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>

    public static string FormatRG(string RG)
    {
        return Convert.ToUInt64(RG).ToString(@"00\.000\.000\-0");
    }
    /// Retira a Formatacao de uma string CNPJ/CPF
    /// <param name="Codigo">string Codigo Formatada</param>
    /// <returns>string sem formatacao</returns>
    /// <example>Recebe '99.999.999/9999-99' Devolve '99999999999999'</example>

    public static string SemFormatacao(string Codigo)
    {
        return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
    }
}