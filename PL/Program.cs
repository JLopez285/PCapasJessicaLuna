using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            //ML.Usuario usuario = new ML.Usuario();
            //usuario.UserName = "JeickLuna";
            //usuario.Nombre = "Jessica";
            //usuario.ApellidoPaterno = "Lopez";
            //usuario.ApellidoMaterno = "Tejeda";
            //usuario.Email = "jeickluna@gmail.com";
            //usuario.Sexo = "F";
            //usuario.Telefono = "5557672780";
            //usuario.Celular = "5547969009";
            //usuario.FechaNacimiento = "12/01/1994";
            //usuario.CURP = "LOTJ941201MDFSPJ05";
            //usuario.Estatus = true;

            //ML.Result result = new ML.Result();

            //result = BL.Usuario.Add(usuario);

            //if(result.Correct)
            //{
            //    Console.Write("Se registro el usuario correctamente "+usuario.Nombre);
            //}else
            //{
            //    Console.Write("No se pudo registrar el usuario " +result.ErrorMessage +result.Ex);
            //}

            //Usuario.add();
           // Usuario.GetAll();
            Usuario.GetById();

            Console.ReadKey();
        }
    }
}
