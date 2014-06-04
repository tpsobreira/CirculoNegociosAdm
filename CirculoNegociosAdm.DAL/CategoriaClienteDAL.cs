using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;
using System.Data;

namespace CirculoNegociosAdm.DAL
{
    public class CategoriaClienteDAL
    {
        public List<CategoriaClienteEntity> ConsultaTodasCategoriasCliente()
        {
            List<CategoriaClienteEntity> lstCategoriasClientes = new List<CategoriaClienteEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbCategoriaClientes
                           select p).ToList();

                lstCategoriasClientes = CastListCategoriasClienteEntity(ret);
            }

            return lstCategoriasClientes;
        }

        public bool InsereCategoriaCliente(CategoriaClienteEntity CategoriaCliente)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbCategoriaClientes.AddObject(CastCategoriaCliente(CategoriaCliente));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeletaCategoriaCliente(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbCategoriaCliente delete = (from p in context.tbCategoriaClientes where p.id == id select p).First();
                    context.tbCategoriaClientes.DeleteObject(delete);
                    
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<CategoriaClienteEntity> CastListCategoriasClienteEntity(List<tbCategoriaCliente> tbCategoriaCliente)
        {
            List<CategoriaClienteEntity> lst = new List<CategoriaClienteEntity>();

            foreach (var categoriaCliente in tbCategoriaCliente)
            {
                CategoriaClienteEntity categoria = new CategoriaClienteEntity();

                categoria.DataUltimaAlteracao = categoriaCliente.DataUltimaAlteracao;
                categoria.id = categoriaCliente.id;
                categoria.Nome = categoriaCliente.Nome;
                categoria.responsavelUltimaAlteracao = categoriaCliente.responsavelUltimaAlteracao;

                lst.Add(categoria);

            }

            return lst;
        }

        private tbCategoriaCliente CastCategoriaCliente(CategoriaClienteEntity categoriaCliente)
        {
            tbCategoriaCliente tb = new tbCategoriaCliente();
            
            tb.DataUltimaAlteracao = categoriaCliente.DataUltimaAlteracao;
            tb.id = categoriaCliente.id;
            tb.Nome = categoriaCliente.Nome;
            tb.responsavelUltimaAlteracao = categoriaCliente.responsavelUltimaAlteracao;

            return tb;
        }
    }
}
