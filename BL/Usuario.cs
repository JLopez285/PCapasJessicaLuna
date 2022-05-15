using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BL
{   //todas mis clases deben de ser publicas
    public class Usuario
    {
        //como result no esta en BL debo traerlo de ML el tipo result ML.Result y esto recibe un usuario
        public static ML.Result Add(ML.Usuario usuario)
        {
            //Se crea una instancia de Result
            ML.Result result = new ML.Result();
            //El try nos sirve para idntificar si hay un error al momento de conectarnos
            try
            {
                //Trae la cadena de coleccion de DL.Conexion guarda una conexion de SQL en context y para eso se necesita la cadena de coneccion
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    // Agregamos la accion que se quiere realizar en SQL es importante mantrener el orden, para esto es necesario crear un insert en BD para poder sacarlo mas fácil.
                    string query = "Insert into UsuarioPrueba values(@Nombre, @ApellidoPaterno)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        SqlParameter[] collection = new SqlParameter[2];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        //collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                        //collection[0].Value = usuario.UserName;
                        //collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        //collection[1].Value = usuario.Nombre;
                        //collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        //collection[2].Value = usuario.ApellidoPaterno;
                        //collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        //collection[3].Value = usuario.ApellidoMaterno;
                        //collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        //collection[4].Value = usuario.Email;
                        //collection[5] = new SqlParameter("Sexo", SqlDbType.VarChar);
                        //collection[5].Value = usuario.Sexo;
                        //collection[6] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        //collection[6].Value = usuario.Telefono;
                        //collection[7] = new SqlParameter("Celular", SqlDbType.VarChar);
                        //collection[7].Value = usuario.Celular;
                        //collection[8] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        //collection[8].Value = usuario.FechaNacimiento;
                        //collection[9] = new SqlParameter("CURP", SqlDbType.VarChar);
                        //collection[9].Value = usuario.CURP;
                        //collection[10] = new SqlParameter("Estatus", SqlDbType.Bit);
                        //collection[10].Value = usuario.Estatus;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "No se realizo la conexion a la base de datos";
            }
            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    string cadenaUpdate = "UPDATE Usuario SET (IdUsuario=@IdUsuario,UserName=@UserName,Nombre=@Nombre,ApellidoPaterno=@ApellidoPaterno,ApellidoMaterno=@ApellidoMaterno,Email=@Email,Sexo=@Sexo,Telefono=@Telefono,Celular=@Celular,FechaNacimiento=@FechaNacimiento,CURP=@CURP,Estatus=@Estatus,Sexo=@Sexo,Telefono=@Telefono,Celular=@Celular,FechaNacimiento=@FechaNacimiento,CURP=@CURP,Estatus=@Estatus)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = cadenaUpdate;
                        cmd.Connection = context;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[12];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;
                        collection[1] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[1].Value = usuario.UserName;
                        collection[2] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[2].Value = usuario.Nombre;
                        collection[3] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;
                        collection[4] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[4].Value = usuario.ApellidoMaterno;
                        collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;
                        collection[6] = new SqlParameter("Sexo", SqlDbType.VarChar);
                        collection[6].Value = usuario.Sexo;
                        collection[7] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[7].Value = usuario.Telefono;
                        collection[8] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[8].Value = usuario.Celular;
                        collection[9] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[9].Value = usuario.FechaNacimiento;
                        collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;
                        collection[11] = new SqlParameter("Estatus", SqlDbType.Bit);
                        collection[11].Value = usuario.Estatus;

                        cmd.Parameters.AddRange(collection);
                        int RowsAffects = cmd.ExecuteNonQuery();

                        if (RowsAffects > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ha ocurrido un error al actualizar"; ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }

            return result;
        }

        public static ML.Result Delete(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string delete = "DELETE FROM UsuarioPrueba Where IdUsuario = @IdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = delete;
                        cmd.Connection = context;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = idUsuario;

                        cmd.Parameters.AddRange(collection);

                        int RowsAffects = cmd.ExecuteNonQuery();

                        if (RowsAffects > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error borrar el registro";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;

        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string getAll = "SELECT [IdUsuario],[UserName],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[Sexo],[Telefono],[Celular],[FechaNacimiento],[CURP],[Estatus] FROM Usuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = getAll;
                        cmd.Connection = context;
                        cmd.Connection.Open();
                        DataTable usuarioTable = new DataTable();//instnacia de mi DataTable

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(usuarioTable);
                        result.Objects = new List<object>();

                        if (usuarioTable.Rows.Count > 0)
                        {

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.UserName = row[1].ToString();
                                usuario.Nombre = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.Sexo = row[6].ToString();
                                usuario.Telefono = row[7].ToString();
                                usuario.Celular = row[8].ToString();
                                usuario.FechaNacimiento = row[9].ToString();
                                usuario.CURP = row[10].ToString();
                                usuario.Estatus = bool.Parse(row[11].ToString());



                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }

            return result;
        }

        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string getId = "SELECT [IdUsuario],[UserName],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[Sexo],[Telefono],[Celular],[FechaNacimiento],[CURP],[Estatus] FROM Usuario WHERE IdUsuario =@IdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = getId;
                        cmd.Connection = context;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = idUsuario;
                        cmd.Parameters.AddRange(collection);

                        SqlDataReader registro = cmd.ExecuteReader();
                        if (registro != null)
                        {

                            if (registro.Read())
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(registro["IdUsuario"].ToString());
                                usuario.UserName = registro["UserName"].ToString();
                                usuario.Nombre = registro["Nombre"].ToString();
                                usuario.ApellidoPaterno = registro["ApellidoPaterno"].ToString();
                                usuario.ApellidoMaterno = registro["ApellidoMaterno"].ToString();
                                usuario.Email = registro["Email"].ToString();
                                usuario.Sexo = registro["Sexo"].ToString();
                                usuario.Telefono = registro["Telefono"].ToString();
                                usuario.Celular = registro["Celular"].ToString();
                                usuario.FechaNacimiento = registro["FechaNacimiento"].ToString();
                                usuario.CURP = registro["CURP"].ToString();
                                usuario.Estatus = bool.Parse(registro["Estatus"].ToString());

                                result.Object = usuario;//boxing 

                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }

            return result;
        }

        public static ML.Result GetAll2()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string getAll = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno] FROM UsuarioPrueba";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = getAll;
                        cmd.Connection = context;
                        cmd.Connection.Open();
                        DataTable usuarioTable = new DataTable();//instnacia de mi DataTable

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(usuarioTable);
                        result.Objects = new List<object>();

                        if (usuarioTable.Rows.Count > 0)
                        {

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                               



                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

            }

            return result;
        }

    }
}
