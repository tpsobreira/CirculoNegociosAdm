using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using CirculoNegociosAdm.Entity;

namespace CirculoNegociosAdm.Business
{
    public class LogradouroBusiness
    {
        public LogradouroEntity ConsultaCep(string cep)
        { 
            string url = "http://www.midiaville.com.br/webservices/?cep=" + cep;
            XmlTextReader reader = new XmlTextReader(url);
            XmlDocument xmlDoc = new XmlDocument();

            LogradouroEntity logradouro = new LogradouroEntity();

            while (reader.Read())
            {
                //  Here we check the type of the node, in this case we are looking for element
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "bairro":
                            logradouro.bairro = reader.ReadString();
                            break;
                        case "localidade":
                            logradouro.cidade = reader.ReadString();
                            break;
                        case "logradouro":
                            logradouro.endereco = reader.ReadString();
                            break;
                        case "uf":
                            logradouro.uf = reader.ReadString();
                            break;
                        default:
                            break;
                    }
                }
            }

            reader.Close();
            

            XmlNodeList xnList = xmlDoc.GetElementsByTagName("root");

            foreach (XmlNode node in xnList)
            {
                logradouro.bairro = node["bairro"].ToString();
                logradouro.cidade = node["localidade"].ToString();
                logradouro.endereco = node["logradouro"].ToString();
                logradouro.uf = node["uf"].ToString();
            }

            return logradouro;

        }
    }
}
