using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class PacienteNL
    {

        #region "PATRON SINGLETON"

        private static PacienteNL objEmpleado;

        private PacienteNL() { }

        public static PacienteNL getInstance()
        {
            if (objEmpleado == null)
            {

                objEmpleado = new PacienteNL();
            }
            return objEmpleado;
        }
        #endregion

        public bool RegistrarPaciente(Paciente objPaciente)
        {

            try
            {


                return PacienteDAO.getInstance().RegistrarPaciente(objPaciente);



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Paciente> listarPacientes()
        {

            try
            {

                return PacienteDAO.getInstance().listarPacientes();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
