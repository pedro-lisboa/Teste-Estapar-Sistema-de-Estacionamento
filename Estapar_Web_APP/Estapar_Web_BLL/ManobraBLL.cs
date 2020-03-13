using Estapar_Web_DAL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_BLL
{
    public class ManobraBLL
    {
        public static List<Manobra> Listar(Manobra manobra)
        {
            try
            {
                return ManobraDAL.Listar(manobra);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public static Manobra ListarPorId(Manobra manobra)
        {
            try
            {
                return ManobraDAL.ListarPorId(manobra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string Inserir(Manobra manobra)
        {
            try
            {
                return ManobraDAL.Inserir(manobra);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Editar(Manobra manobra)
        {
            try
            {
                return ManobraDAL.Editar(manobra);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Excluir(Manobra manobra)
        {
            try
            {
                return ManobraDAL.Excluir(manobra);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        

        public static List<Manobrista> ListarAllManobristas()
        {
            try
            {
                return ManobraDAL.ListarAllManobristas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Veiculo> ListarAllVeiculos()
        {
            try
            {
                return ManobraDAL.ListarAllVeiculos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Terminar(Manobra manobra)
        {
            try
            {
                return ManobraDAL.Terminar(manobra);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
