﻿using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class EmpleadoDAO
    {

        #region "PATRON SINGLETON"

        private static EmpleadoDAO daoEmpleado = null;

        private EmpleadoDAO (){}


        public static EmpleadoDAO getInstance()
        {

            if( daoEmpleado == null)
            {

                daoEmpleado = new EmpleadoDAO();
            }
            return daoEmpleado;
        }


        #endregion


        public Empleado AccesoSistema(String user,String pass) {


            SqlConnection conexion = null;

            SqlCommand cmd = null;
            Empleado objEmpleado = null;
            try
            {

                conexion=Conexion.getInstance().ConexionBd();

                cmd = new SqlCommand("spAccesoSistema", conexion);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmUser",user);
                cmd.Parameters.AddWithValue("@prmPass",pass);
                conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read()) {
                    objEmpleado = new Empleado();

                    objEmpleado.ID = Convert.ToInt32(dr["idEmpleado"].ToString());
                    objEmpleado.Usuario = dr["usuario"].ToString();
                    objEmpleado.Clave = dr["clave"].ToString();
                }
            }
            catch (Exception ex) {
                objEmpleado = null;
                throw ex;
            }
            finally
            {

                conexion.Close();
            }

            return objEmpleado;
        }
    }
}
