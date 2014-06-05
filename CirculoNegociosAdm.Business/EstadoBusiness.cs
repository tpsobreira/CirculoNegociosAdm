using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DAL;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class EstadoBusiness
    {
        EstadoDAL lObjEstado = new EstadoDAL();

        public List<EstadoEntity> ConsultaTodosEstados()
        {
            return lObjEstado.ConsultaTodosEstados();
        }

        public string InsereEstado(EstadoEntity Estado)
        {
            bool ret = lObjEstado.InsereEstado(Estado);

            if (ret)
                return "Estado incluido com sucesso!";
            else
                return "Ocorreu um erro ao incluir o estado!";
        }

        public string DeletaEstado(string sigla)
        {
            bool ret = lObjEstado.DeletaEstado(sigla);

            if (ret)
                return "Estado excluido com sucesso!";
            else
                return "Ocorreu um erro ao excluir o estado!";
        }
    }
}
