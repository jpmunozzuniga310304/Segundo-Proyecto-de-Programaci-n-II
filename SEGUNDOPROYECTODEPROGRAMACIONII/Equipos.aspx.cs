﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Segundo Proyecto de Programación II
// Estudiantes: José Pablo Muñoz Zúñiga 
//              Karina Marina Marina Unfried Montoya
//              Dillan Josue Obando Samudio
// Carrera: Ingeniería Informática
// Materia: Programación II

namespace SEGUNDOPROYECTODEPROGRAMACIONII
{
    // En esta parte es la programación de la parte equipos de la pagina web para que funcione correctamente
    public partial class Equipos : System.Web.UI.Page
    {
        // En esta parte es donde se carga la parte equipos de la pagina web correctamente
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        // En esta parte es para transferir los datos de los equipos del sql server management studio al visual studio en C#
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt; 
                            datagrid.DataBind();  
                        }
                    }
                }
            }
        }

        // En esta parte son las alertas cuya funcion es cuando el usuario digita un numero es para saber si lo ingreso correctamente o no en la parte equipos
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        // En esta parte es para que el boton agregar funcione correctamente en la parte de equipos de la pagina web
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Clases.Equipos.Agregar(tTipoEquipo.Text, tModelo.Text, int.Parse(tUsuarioID.Text)) > 0)
            {
                LlenarGrid();
                alertas("Equipo ingresado con exito");
            }
            else
            {
                alertas("Error al ingresar el equipo");
            }
        }

        // En esta parte es para que el boton borrar funcione correctamente en la parte de equipos de la pagina web
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Clases.Equipos.Borrar(int.Parse(tEquipoID.Text)) > 0)
            {
                LlenarGrid();
                alertas("Equipos borrados con exito");
            }
            else
            {
                alertas("Error al borrar los equipos");
            }
        }

        // En esta parte es para que el boton actualizar funcione correctamente en la parte de equipos de la pagina web
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Clases.Equipos.Actualizar(int.Parse(tEquipoID.Text), tTipoEquipo.Text, tModelo.Text, int.Parse(tUsuarioID.Text)) > 0)
            {
                LlenarGrid();
                alertas("Equipo actualizado con exito");
            }
            else
            {
                alertas("Error al actualizar el equipo");
            }
        }

        // En esta parte es para que el boton de consultar funcione correctamente en la parte de equipos de la pagina web
        protected void Button2_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tEquipoID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE EquipoID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  
                    }
                }
            }
        }

        // En esta parte es para que el boton de mostrar todo funcione correctamente en la parte de equipos de la pagina web
        protected void Button5_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}