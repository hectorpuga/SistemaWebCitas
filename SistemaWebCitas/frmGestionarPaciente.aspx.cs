﻿using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaWebCitas
{
    public partial class frmGestionarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                
            }

        }


        private Paciente GetEntity()
        {

            Paciente objPaciente=new Paciente();

            objPaciente.idPaciente = 0;
            objPaciente.Nombres=txtNombres.Text;
            objPaciente.ApPaterno=txtApPaterno.Text;
            objPaciente.ApMaterno=txtApMaterno.Text;
            objPaciente.Edad=Convert.ToInt32(txtEdad.Text);
            objPaciente.Direccion=txtDireccion.Text;
            objPaciente.Sexo = Convert.ToChar((ddlSexo.SelectedValue=="Femenino")?"F":"M");
            objPaciente.NroDocumento = txtNroDocumento.Text;
            objPaciente.Estado = true;
            objPaciente.Telefono = txtTelefono.Text;

            return objPaciente;

        }

        private Paciente GetPaciente()
        {

            return null;
        }


        [WebMethod]
        public static List<Paciente> ListarPacientes()
        {
            List<Paciente> Lista = null;
            try
            {

                Lista = PacienteNL.getInstance().ListarPacientes();



            }
            catch (Exception e)
            {
                Lista = null;

                throw e;
            }

            return Lista;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Paciente objPaciente = GetEntity();
            bool response = PacienteNL.getInstance().RegistrarPaciente(objPaciente);

            if (response)
            {
                litMensaje.Text = "<script>Swal.fire('Éxito', 'Paciente registrado correctamente', 'success');</script>";
            }
        }

    }
}