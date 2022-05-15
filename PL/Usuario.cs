    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void add()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el nombre de usuario: ");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese su nomre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese su e-mail: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese su sexo, use F para femenino y M para masculino: ");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingrese su numero telefonico de 10 digitos sin espacio ni guiones: ");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese su numero de celular de 10 digitos sin espacios ni guiones");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese su fecha de nacimiento con el siguiente formato (DD/MM/AAAA): ");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese su curp: ");
            usuario.CURP = Console.ReadLine();
            Console.WriteLine("Ingrese su estatus TRUE para activo o FALSE para inactivo");
            //usuario.Estatus = bool.Parse(Console.ReadLine());
            usuario.Estatus = Convert.ToBoolean(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Usuario.Add(usuario);

            if(result.Correct == true)
            {
                Console.WriteLine("Se agrego correctamentre el usuario");
            }
            else
            {
                Console.WriteLine("No se agrego el usuario");
            }
        }

        public static void GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            //Console.WriteLine("Ingrese el nombre de usuario: ");
            //usuario.UserName = Console.ReadLine();
            //Console.WriteLine("Ingrese su nomre: ");
            //usuario.Nombre = Console.ReadLine();
            //Console.WriteLine("Ingrese su apellido paterno: ");
            //usuario.ApellidoPaterno = Console.ReadLine();
            //Console.WriteLine("Ingrese su apellido materno: ");
            //usuario.ApellidoMaterno = Console.ReadLine();
            //Console.WriteLine("Ingrese su e-mail: ");
            //usuario.Email = Console.ReadLine();
            //Console.WriteLine("Ingrese su sexo, use F para femenino y M para masculino: ");
            //usuario.Sexo = Console.ReadLine();
            //Console.WriteLine("Ingrese su numero telefonico de 10 digitos sin espacio ni guiones: ");
            //usuario.Telefono = Console.ReadLine();
            //Console.WriteLine("Ingrese su numero de celular de 10 digitos sin espacios ni guiones");
            //usuario.Celular = Console.ReadLine();
            //Console.WriteLine("Ingrese su fecha de nacimiento con el siguiente formato (DD/MM/AAAA): ");
            //usuario.FechaNacimiento = Console.ReadLine();
            //Console.WriteLine("Ingrese su curp: ");
            //usuario.CURP = Console.ReadLine();
            //Console.WriteLine("Ingrese su estatus TRUE para activo o FALSE para inactivo");
            //usuario.Estatus = bool.Parse(Console.ReadLine());
            //usuario.Estatus = Convert.ToBoolean(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects; //UNBOXIN
                foreach(ML.Usuario usuarioLista in usuario.Usuarios)
                {
                    Console.WriteLine("ID Usuario: " + usuarioLista.IdUsuario);
                    Console.WriteLine("UserName: " + usuarioLista.UserName);
                    Console.WriteLine("Nombre: " + usuarioLista.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuarioLista.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuarioLista.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuarioLista.Email);
                    Console.WriteLine("Sexo: " + usuarioLista.Sexo);
                    Console.WriteLine("Telefono: " + usuarioLista.Telefono);
                    Console.WriteLine("Celular: " + usuarioLista.Celular);
                    Console.WriteLine("FechaNacimiento: " + usuarioLista.FechaNacimiento);
                    Console.WriteLine("Curp: " + usuarioLista.CURP);
                    Console.WriteLine("Estatus: " + usuarioLista.Estatus);



                }
                //Console.WriteLine("Se agrego correctamentre el usuario");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }
        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el nombre de usuario: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            //Console.WriteLine("Ingrese su nomre: ");
            //usuario.Nombre = Console.ReadLine();
            //Console.WriteLine("Ingrese su apellido paterno: ");
            //usuario.ApellidoPaterno = Console.ReadLine();
            //Console.WriteLine("Ingrese su apellido materno: ");
            //usuario.ApellidoMaterno = Console.ReadLine();
            //Console.WriteLine("Ingrese su e-mail: ");
            //usuario.Email = Console.ReadLine();
            //Console.WriteLine("Ingrese su sexo, use F para femenino y M para masculino: ");
            //usuario.Sexo = Console.ReadLine();
            //Console.WriteLine("Ingrese su numero telefonico de 10 digitos sin espacio ni guiones: ");
            //usuario.Telefono = Console.ReadLine();
            //Console.WriteLine("Ingrese su numero de celular de 10 digitos sin espacios ni guiones");
            //usuario.Celular = Console.ReadLine();
            //Console.WriteLine("Ingrese su fecha de nacimiento con el siguiente formato (DD/MM/AAAA): ");
            //usuario.FechaNacimiento = Console.ReadLine();
            //Console.WriteLine("Ingrese su curp: ");
            //usuario.CURP = Console.ReadLine();
            //Console.WriteLine("Ingrese su estatus TRUE para activo o FALSE para inactivo");
            //usuario.Estatus = bool.Parse(Console.ReadLine());
            //usuario.Estatus = Convert.ToBoolean(Console.ReadLine());

            ML.Result result = new ML.Result();
            result = BL.Usuario.GetById(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object; //UNBOXIN
              
                    Console.WriteLine("ID Usuario: " + usuario.IdUsuario);
                    Console.WriteLine("UserName: " + usuario.UserName);
                    Console.WriteLine("Nombre: " + usuario.Nombre);
                    Console.WriteLine("Apellido Paterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Email: " + usuario.Email);
                    Console.WriteLine("Sexo: " + usuario.Sexo);
                    Console.WriteLine("Telefono: " + usuario.Telefono);
                    Console.WriteLine("Celular: " + usuario.Celular);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Curp: " + usuario.CURP);
                    Console.WriteLine("Estatus: " + usuario.Estatus);



                
                //Console.WriteLine("Se agrego correctamentre el usuario");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }
    }
}
