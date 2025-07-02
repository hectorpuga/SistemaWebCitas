using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class PacienteDAO
    {

        #region "PATRON SINGLETON"

        private static PacienteDAO daoEmpleado;

        private PacienteDAO() { }

        public static PacienteDAO getInstance()
        {
            if (daoEmpleado == null) {
            daoEmpleado = new PacienteDAO();
            }
            return daoEmpleado;
        }
        #endregion


        public bool RegistrarPaciente(Paciente objPaciente)
        {

            SqlConnection con = null;
            bool response = false;
            
            try {
                con = Conexion.getInstance().ConexionBd();
                SqlCommand cmd = new SqlCommand("spRegistrarPaciente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmNombres",objPaciente.Nombres);
                cmd.Parameters.AddWithValue("@prmApPaterno", objPaciente.ApPaterno);
                cmd.Parameters.AddWithValue("@prmApMaterno",objPaciente.ApPaterno);
                cmd.Parameters.AddWithValue("@prmEdad",objPaciente.Edad);
                cmd.Parameters.AddWithValue("@prmSexo",objPaciente.Sexo);
                cmd.Parameters.AddWithValue("@prmNroDoc",objPaciente.NroDocumento);
                cmd.Parameters.AddWithValue("@prmDireccion",objPaciente.Direccion);
                cmd.Parameters.AddWithValue("@prmTelefono", objPaciente.Telefono);
                cmd.Parameters.AddWithValue("@prmEstado",objPaciente.Estado);
                con.Open();

             int filas = cmd.ExecuteNonQuery();

                if (filas > 0) response = true;


            
            }catch(Exception e) {
                response = false;
                throw e;
            }
            finally { 
            con.Close();
            }
            return response; 
        }
    
    public List<Paciente> ListarPacientes()
        {


          
            List<Paciente> Lista = new List<Paciente>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;



            try
            {


                con = Conexion.getInstance().ConexionBd();
                cmd = new SqlCommand("spListarPacientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Paciente objPaciente = new Paciente();

                    objPaciente.idPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    objPaciente.Nombres = dr["nombres"].ToString();
                    objPaciente.ApPaterno = dr["apPaterno"].ToString();
                    objPaciente.ApMaterno = dr["apMaterno"].ToString();
                    objPaciente.Edad = Convert.ToInt32(dr["edad"].ToString());
                    objPaciente.Sexo = Convert.ToChar(dr["sexo"].ToString());
                    objPaciente.NroDocumento = dr["nroDocumento"].ToString();
                    objPaciente.Direccion = dr["direccion"].ToString();
                    objPaciente.Estado = true;

                    Lista.Add(objPaciente);

                }




            }
            catch (Exception e)
            {

                throw e;
            }
            finally { 
            con.Close();
            }
            
            
      
            return Lista;

        }
    }
}
