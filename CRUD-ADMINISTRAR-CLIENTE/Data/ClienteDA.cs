using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class ClienteDA
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        public List<ClienteE> ListadoCliente()
        {
            List<ClienteE> listado = new List<ClienteE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("SP_Select_Cliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClienteE clienteE = new ClienteE();
                    clienteE.id_Cliente = Convert.ToInt32(dr["id_Cliente"].ToString());
                    clienteE.nombre = dr["nombre"].ToString();
                    clienteE.ap_Paterno = dr["ap_Paterno"].ToString();
                    clienteE.ap_Materno = dr["ap_Materno"].ToString();
                    clienteE.celular = Convert.ToInt32(dr["celular"].ToString());
                    clienteE.correo = dr["correo"].ToString();
                    clienteE.direccion = dr["direccion"].ToString();
                    clienteE.documento_Ident = dr["documento_Ident"].ToString();
                    listado.Add(clienteE);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return listado;
        }
        
        public int RegistrarCliente(ClienteE clienteE)
        {
            int i;
            try
            {
                cn.Open();
                SqlCommand com = new SqlCommand("SP_Create_Cliente", cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@nombre", clienteE.nombre);
                com.Parameters.AddWithValue("@ap_Paterno", clienteE.ap_Paterno);
                com.Parameters.AddWithValue("@ap_Materno", clienteE.ap_Materno);
                com.Parameters.AddWithValue("@celular", clienteE.celular);
                com.Parameters.AddWithValue("@correo", clienteE.correo);
                com.Parameters.AddWithValue("@direccion", clienteE.direccion);
                com.Parameters.AddWithValue("@documento_Ident", clienteE.documento_Ident);
                i = com.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return i;
        }

        public int ActualizarCliente(ClienteE clienteE)
        {
            int i;
            try
            {
                cn.Open();
                SqlCommand com = new SqlCommand("SP_Update_Cliente", cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id_Cliente", clienteE.id_Cliente);
                com.Parameters.AddWithValue("@nombre", clienteE.nombre);
                com.Parameters.AddWithValue("@ap_Paterno", clienteE.ap_Paterno);
                com.Parameters.AddWithValue("@ap_Materno", clienteE.ap_Materno);
                com.Parameters.AddWithValue("@celular", clienteE.celular);
                com.Parameters.AddWithValue("@correo", clienteE.correo);
                com.Parameters.AddWithValue("@direccion", clienteE.direccion);
                com.Parameters.AddWithValue("@documento_Ident", clienteE.documento_Ident);
                i = com.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return i;
            
        }

        public int EliminarCliente(int ID)
        {
            int i;
            try
            {
                cn.Open();
                SqlCommand com = new SqlCommand("SP_Delete_Cliente", cn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id_Cliente", ID);
                i = com.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return i;

        }
}
}
