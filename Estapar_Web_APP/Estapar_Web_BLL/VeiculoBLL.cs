using Estapar_Web_DAL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_BLL
{
    public class VeiculoBLL
    {
        public static List<Veiculo> Listar(Veiculo veiculo)
        {
            try
            {
                return VeiculoDAL.Listar(veiculo);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public static Veiculo ListarPorPlaca(Veiculo veiculo)
        {
            try
            {
                return VeiculoDAL.ListarPorPlaca(veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Inserir(Veiculo veiculo)
        {
            try
            {
                return VeiculoDAL.Inserir(veiculo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Editar(Veiculo veiculo)
        {
            try
            {
                return VeiculoDAL.Editar(veiculo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Excluir(Veiculo veiculo)
        {
            try
            {
                return VeiculoDAL.Excluir(veiculo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
