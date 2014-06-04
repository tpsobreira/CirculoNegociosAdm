using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CirculoNegociosAdm.Entity;
using CirculoNegociosAdm.DB;
using System.Data;
using System.Reflection;


namespace CirculoNegociosAdm.DAL
{
    public class ClientesDAL
    {
        public List<ClienteEntity> ConsultaTodosClientes()
        {
            List<ClienteEntity> lstClientes = new List<ClienteEntity>();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbClientes
                                select p).ToList();

                lstClientes = CastListClienteEntity(ret);
            }

            return lstClientes;
        }

        public bool InsereCliente(ClienteEntity Cliente)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    context.tbClientes.AddObject(CastCliente(Cliente));
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool DeletaCliente(int id)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbCliente delete = (from p in context.tbClientes where p.id == id select p).First();
                    context.tbClientes.DeleteObject(delete);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private tbCliente CastCliente(ClienteEntity cliente)
        {
            tbCliente tCliente = new tbCliente();

            tCliente.anexoImagem1Path = cliente.anexoImagem1Path;
            tCliente.anexoImagem2Path = cliente.anexoImagem2Path;
            tCliente.anexoImagem3Path = cliente.anexoImagem3Path;
            tCliente.anexoLogoPath = cliente.anexoLogoPath;
            tCliente.ativo = cliente.ativo;
            tCliente.cep = cliente.cep;
            tCliente.cidade = cliente.cidade;
            tCliente.complemento = cliente.complemento;
            tCliente.contatoResponsavel = cliente.contatoResponsavel;
            tCliente.cpfCnpj = cliente.cpfCnpj;
            tCliente.email = cliente.email;
            tCliente.endereco = cliente.endereco;
            tCliente.estado = cliente.estado;
            tCliente.Funcionamento = cliente.Funcionamento;
            tCliente.idCategoriaCliente = cliente.idCategoriaCliente;
            tCliente.inscricaoEstadual = cliente.inscricaoEstadual;
            tCliente.nome = cliente.nome;
            tCliente.nomeFantasia = cliente.nomeFantasia;
            tCliente.observacoes = cliente.observacoes;
            tCliente.razaoSocial = cliente.razaoSocial;
            tCliente.servicos = cliente.servicos;
            tCliente.site = cliente.site;
            tCliente.telefone1 = cliente.telefone1;
            tCliente.telefone2 = cliente.telefone2;

            return tCliente;
        }

        private List<ClienteEntity> CastListClienteEntity(List<tbCliente> lstClientes)
        {
            List<ClienteEntity> lstClientesEntity = new List<ClienteEntity>();

            foreach (var cliente in lstClientes)
            {
                ClienteEntity tCliente = new ClienteEntity();

                tCliente.id = cliente.id;
                tCliente.anexoImagem1Path = cliente.anexoImagem1Path;
                tCliente.anexoImagem2Path = cliente.anexoImagem2Path;
                tCliente.anexoImagem3Path = cliente.anexoImagem3Path;
                tCliente.anexoLogoPath = cliente.anexoLogoPath;
                tCliente.ativo = cliente.ativo;
                tCliente.cep = cliente.cep;
                tCliente.cidade = cliente.cidade;
                tCliente.complemento = cliente.complemento;
                tCliente.contatoResponsavel = cliente.contatoResponsavel;
                tCliente.cpfCnpj = cliente.cpfCnpj;
                tCliente.email = cliente.email;
                tCliente.endereco = cliente.endereco;
                tCliente.estado = cliente.estado;
                tCliente.Funcionamento = cliente.Funcionamento;
                tCliente.idCategoriaCliente = cliente.idCategoriaCliente;
                tCliente.inscricaoEstadual = cliente.inscricaoEstadual;
                tCliente.nome = cliente.nome;
                tCliente.nomeFantasia = cliente.nomeFantasia;
                tCliente.observacoes = cliente.observacoes;
                tCliente.razaoSocial = cliente.razaoSocial;
                tCliente.servicos = cliente.servicos;
                tCliente.site = cliente.site;
                tCliente.telefone1 = cliente.telefone1;
                tCliente.telefone2 = cliente.telefone2;

                lstClientesEntity.Add(tCliente);
            }

            return lstClientesEntity;
        }
    }
}
