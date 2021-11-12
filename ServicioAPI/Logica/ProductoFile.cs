using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ServicioAPI.Models;

namespace ServicioAPI.Logica
{
    public class ProductoFile
    {
        //public List<Productos> GetProduct()
        //{
        //    List<Productos> respuesta = new List<Productos>();
        //    try
        //    {
        //        using (Database1Entities db = new Database1Entities())
        //        {
        //            var data = (from t in db.Productos select t).ToList();
        //            return data;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return respuesta;
        //        throw;
        //    }
            
        //}


        //public List<Productos> GetProductId(int id)
        //{
        //    List<Productos> respuesta = new List<Productos>();
        //    try
        //    {
        //        using (Database1Entities db = new Database1Entities())
        //        {
        //            var data = (from t in db.Productos where t.Id == id select t).ToList();
        //            return data;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return respuesta;
        //        throw;
        //    }

        //}


        //public string SetProduct(Productos p)
        //{
        //    try
        //    {
        //        using (Database1Entities db = new Database1Entities())
        //        {
        //            var data = db.Productos.Add(new Productos
        //            {
        //                Nombre = p.Nombre,
        //                Precio = p.Precio,
        //                Proveedor = p.Proveedor,
        //                Stock = p.Stock
        //            });
        //            db.SaveChanges();
        //            return "Registro Creado";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return "Error al guardar";
        //        throw;
        //    }

        //}


        //public string DeleteProduct(int id)
        //{
        //    try
        //    {
        //        using (Database1Entities db = new Database1Entities())
        //        {
        //            var data = (from t in db.Productos where t.Id == id select t).FirstOrDefault();
        //            db.Productos.Remove(data);
        //            return "Regitro Eliminado";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return "Error al eliminar";
        //        throw;
        //    }

        //}


        //public string UpdateProduct(Productos p)
        //{
        //    try
        //    {
        //        using (Database1Entities db = new Database1Entities())
        //        {
        //            var data = (from t in db.Productos where t.Id == p.Id select t).FirstOrDefault();
        //            data.Nombre = p.Nombre;
        //            data.Precio = p.Precio;
        //            data.Proveedor = p.Proveedor;
        //            data.Stock = p.Stock;
        //            db.SaveChanges();
        //            return "Cambios guardados";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return "Error al guardar";
        //        throw;
        //    }

        //}


    }
}