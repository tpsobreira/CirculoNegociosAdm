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

        public ClienteEntity ConsultaClienteById(int idCliente)
        {
            ClienteEntity cliente = new ClienteEntity();

            using (var context = new CirculoNegocioEntities())
            {
                var ret = (from p in context.tbClientes
                           where p.id == idCliente
                           select p).First();

                cliente = CastClienteEntity(ret);
            }

            return cliente;
        }

        public int InsereCliente(ClienteEntity Cliente)
        {
            int idCliente = 0;

            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbCliente tb = CastCliente(Cliente);
                    context.tbClientes.AddObject(tb);
                    context.SaveChanges();
                    idCliente = tb.id;
                }

                return idCliente;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public bool AtualizaCliente(int idCliente, ClienteEntity cliente)
        {


            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbCliente tCliente = (from p in context.tbClientes
                                          where p.id == idCliente
                                          select p).First();

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
                    tCliente.idSubCategoriaCliente = cliente.idSubCategoriaCliente;
                    tCliente.inscricaoEstadual = cliente.inscricaoEstadual;
                    tCliente.nome = cliente.nome;
                    tCliente.nomeFantasia = cliente.nomeFantasia;
                    tCliente.observacoes = cliente.observacoes;
                    tCliente.razaoSocial = cliente.razaoSocial;
                    tCliente.servicos = cliente.servicos;
                    tCliente.site = cliente.site;
                    tCliente.telefone1 = cliente.telefone1;
                    tCliente.telefone2 = cliente.telefone2;

                    tCliente.bairro = cliente.bairro;
                    tCliente.horaFdsAte = cliente.horaFdsAte;
                    tCliente.horaFdsDe = cliente.horaFdsDe;
                    tCliente.horaSemanaAte = cliente.horaSemanaAte;
                    tCliente.horaSemanaDe = cliente.horaSemanaDe;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AtualizaImagensCliente(int idCliente, string logo, string img1, string img2, string img3)
        {
            try
            {
                using (var context = new CirculoNegocioEntities())
                {
                    tbCliente cliente = (from p in context.tbClientes where p.id == idCliente select p).First();
                    cliente.anexoLogoPath = logo;
                    cliente.anexoImagem1Path = img1;
                    cliente.anexoImagem2Path = img2;
                    cliente.anexoImagem3Path = img3;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
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
            tCliente.idSubCategoriaCliente = cliente.idSubCategoriaCliente;
            tCliente.inscricaoEstadual = cliente.inscricaoEstadual;
            tCliente.nome = cliente.nome;
            tCliente.nomeFantasia = cliente.nomeFantasia;
            tCliente.observacoes = cliente.observacoes;
            tCliente.razaoSocial = cliente.razaoSocial;
            tCliente.servicos = cliente.servicos;
            tCliente.site = cliente.site;
            tCliente.telefone1 = cliente.telefone1;
            tCliente.telefone2 = cliente.telefone2;

            tCliente.bairro = cliente.bairro;
            tCliente.horaFdsAte = cliente.horaFdsAte;
            tCliente.horaFdsDe = cliente.horaFdsDe;
            tCliente.horaSemanaAte = cliente.horaSemanaAte;
            tCliente.horaSemanaDe = cliente.horaSemanaDe;

            return tCliente;
        }

        private ClienteEntity CastClienteEntity(tbCliente cliente)
        {
            ClienteEntity objCliente = new ClienteEntity();

            objCliente.anexoImagem1Path = cliente.anexoImagem1Path;
            objCliente.anexoImagem2Path = cliente.anexoImagem2Path;
            objCliente.anexoImagem3Path = cliente.anexoImagem3Path;
            objCliente.anexoLogoPath = cliente.anexoLogoPath;
            objCliente.ativo = cliente.ativo;
            objCliente.cep = cliente.cep;
            objCliente.cidade = cliente.cidade;
            objCliente.complemento = cliente.complemento;
            objCliente.contatoResponsavel = cliente.contatoResponsavel;
            objCliente.cpfCnpj = cliente.cpfCnpj;
            objCliente.email = cliente.email;
            objCliente.endereco = cliente.endereco;
            objCliente.estado = cliente.estado;
            objCliente.Funcionamento = cliente.Funcionamento;
            objCliente.idCategoriaCliente = cliente.idCategoriaCliente;
            objCliente.idSubCategoriaCliente = cliente.idSubCategoriaCliente;
            objCliente.inscricaoEstadual = cliente.inscricaoEstadual;
            objCliente.nome = cliente.nome;
            objCliente.nomeFantasia = cliente.nomeFantasia;
            objCliente.observacoes = cliente.observacoes;
            objCliente.razaoSocial = cliente.razaoSocial;
            objCliente.servicos = cliente.servicos;
            objCliente.site = cliente.site;
            objCliente.telefone1 = cliente.telefone1;
            objCliente.telefone2 = cliente.telefone2;

            objCliente.bairro = cliente.bairro;
            objCliente.horaFdsAte = cliente.horaFdsAte;
            objCliente.horaFdsDe = cliente.horaFdsDe;
            objCliente.horaSemanaAte = cliente.horaSemanaAte;
            objCliente.horaSemanaDe = cliente.horaSemanaDe;


            return objCliente;
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
                tCliente.idSubCategoriaCliente = cliente.idSubCategoriaCliente;
                tCliente.inscricaoEstadual = cliente.inscricaoEstadual;
                tCliente.nome = cliente.nome;
                tCliente.nomeFantasia = cliente.nomeFantasia;
                tCliente.observacoes = cliente.observacoes;
                tCliente.razaoSocial = cliente.razaoSocial;
                tCliente.servicos = cliente.servicos;
                tCliente.site = cliente.site;
                tCliente.telefone1 = cliente.telefone1;
                tCliente.telefone2 = cliente.telefone2;

                tCliente.bairro = cliente.bairro;
                tCliente.horaFdsAte = cliente.horaFdsAte;
                tCliente.horaFdsDe = cliente.horaFdsDe;
                tCliente.horaSemanaAte = cliente.horaSemanaAte;
                tCliente.horaSemanaDe = cliente.horaSemanaDe;


                lstClientesEntity.Add(tCliente);
            }

            return lstClientesEntity;
        }
    }
}
