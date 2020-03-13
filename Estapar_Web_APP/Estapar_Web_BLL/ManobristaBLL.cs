using Estapar_Web_DAL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_BLL
{
    public class ManobristaBLL
    {
        public static List<Manobrista> Listar(Manobrista manobrista)
        {
            try
            {
                return ManobristaDAL.Listar(manobrista);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public static Manobrista ListarPorCPF(Manobrista manobrista)
        {
            try
            {
                return ManobristaDAL.ListarPorCPF(manobrista);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Inserir(Manobrista manobrista)
        {
            try
            {
                return ManobristaDAL.Inserir(manobrista);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Editar(Manobrista manobrista)
        {
            try
            {
                return ManobristaDAL.Editar(manobrista);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Excluir(Manobrista manobrista)
        {
            try
            {
                return ManobristaDAL.Excluir(manobrista);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
