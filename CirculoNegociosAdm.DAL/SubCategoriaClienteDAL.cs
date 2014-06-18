using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.DB;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.DAL
{
    public class SubCategoriaClienteDAL
    {
        public List<SubCategoriaClienteEntity> ConsultaTodasSubCategoriasCliente()
        {
            List<SubCategoriaClienteEntity> lstSubCategoriasClientes = new List<SubCategoriaClienteEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbSubCategoriaClientes
                           select p).ToList();

                lstSubCategoriasClientes = CastListSubCategoriasClienteEntity(ret);
            }

            return lstSubCategoriasClientes;
        }

        public List<SubCategoriaClienteEntity> ConsultaSubCategoriasClientebyCategoriaPai(int idCategoriaPai)
        {
            List<SubCategoriaClienteEntity> lstSubCategoriasClientes = new List<SubCategoriaClienteEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbSubCategoriaClientes
                           where p.idCategoria == idCategoriaPai
                           select p).ToList();

                lstSubCategoriasClientes = CastListSubCategoriasClienteEntity(ret);
            }

            return lstSubCategoriasClientes;
        }

        public bool InsereSubCategoriaCliente(SubCategoriaClienteEntity SubCategoriaCliente)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbSubCategoriaClientes.AddObject(CastSubCategoriaCliente(SubCategoriaCliente));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeletaSubCategoriaCliente(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbSubCategoriaCliente delete = (from p in context.tbSubCategoriaClientes where p.id == id select p).First();
                    context.tbSubCategoriaClientes.DeleteObject(delete);

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<SubCategoriaClienteEntity> CastListSubCategoriasClienteEntity(List<tbSubCategoriaCliente> tbSubCategoriaCliente)
        {
            List<SubCategoriaClienteEntity> lst = new List<SubCategoriaClienteEntity>();

            foreach (var categoriaCliente in tbSubCategoriaCliente)
            {
                SubCategoriaClienteEntity categoria = new SubCategoriaClienteEntity();

                categoria.DataUltimaAlteracao = categoriaCliente.DataUltimaAlteracao;
                categoria.id = categoriaCliente.id;
                categoria.idCategoria = categoriaCliente.idCategoria;
                categoria.Nome = categoriaCliente.Nome;
                categoria.responsavelUltimaAlteracao = categoriaCliente.responsavelUltimaAlteracao;

                lst.Add(categoria);

            }

            return lst;
        }

        private tbSubCategoriaCliente CastSubCategoriaCliente(SubCategoriaClienteEntity categoriaCliente)
        {
            tbSubCategoriaCliente tb = new tbSubCategoriaCliente();

            tb.DataUltimaAlteracao = categoriaCliente.DataUltimaAlteracao;
            tb.id = categoriaCliente.id;
            tb.idCategoria = categoriaCliente.idCategoria;
            tb.Nome = categoriaCliente.Nome;
            tb.responsavelUltimaAlteracao = categoriaCliente.responsavelUltimaAlteracao;

            return tb;
        }
    }
}
