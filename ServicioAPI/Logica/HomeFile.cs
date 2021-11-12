using AutoMapper;
using ServicioAPI.Models;
using ServicioAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Logica
{
    public class HomeFile
    {
        public List<ClientesDTO> GetClient()
        {
            List<ClientesDTO> respuesta = new List<ClientesDTO>();
            try
            {
                using (Database1Entities db = new Database1Entities())
                {

                    var data = (from t in db.Clientes
                                select new ClientesDTO
                                {
                                    Id = t.Id,
                                    Nombre = t.Nombre,
                                    Identificacion = t.Identificacion,
                                    email = t.email,
                                    Facturacion = 0,
                                }).ToList();
                    var total_fact = 0.0;
                    foreach (var item in data)
                    {
                        total_fact = db.Facturas.Where(x => x.Cliente == item.Id).Sum(x => (double?)x.Total) ?? 0;
                            
                            //(from f in db.Facturas
                            //        where f.Cliente == item.Id
                            //        select f).Sum(x => (double?)x.Total) ?? 0;
                        item.Facturacion = total_fact;
                    }
                    
                    return data;
                }
            }
            catch (Exception)
            {
                return respuesta;
                throw;
            }

        }

        public List<ItemsDTO> GetItems()
        {
            List<ItemsDTO> respuesta = new List<ItemsDTO>();
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Items
                                select new ItemsDTO
                                {
                                    Id = t.Id,
                                    Nombre = t.Nombre,
                                    Valor = t.Valor,
                                }).ToList();

                    return data;
                }
            }
            catch (Exception)
            {
                return respuesta;
                throw;
            }

        }

        public List<VentaDTO> GetVentas()
        {
            List<VentaDTO> respuesta = new List<VentaDTO>();
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Facturas
                                join cli in db.Clientes on t.Cliente equals cli.Id
                                select new VentaDTO
                                {
                                    Id = t.Id,
                                    IdCliente = t.Cliente,
                                    Cliente = cli.Nombre,
                                    Valor = t.Total,
                                }).ToList();

                    return data;
                }
            }
            catch (Exception)
            {
                return respuesta;
                throw;
            }

        }


        public List<VentaDTO> GetVentasCli(int id)
        {
            List<VentaDTO> respuesta = new List<VentaDTO>();
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Facturas
                                join cli in db.Clientes on t.Cliente equals cli.Id
                                where t.Cliente == id
                                select new VentaDTO
                                {
                                    Id = t.Id,
                                    IdCliente = t.Cliente,
                                    Cliente = cli.Nombre,
                                    Valor = t.Total,
                                }).ToList();

                    return data;
                }
            }
            catch (Exception)
            {
                return respuesta;
                throw;
            }

        }


        public List<ItemsFacturaDTO> GetItemsFact(int factura)
        {
            List<ItemsFacturaDTO> respuesta = new List<ItemsFacturaDTO>();
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Items_x_Factura
                                join i in db.Items on t.Item equals i.Id
                                where t.Factura == factura
                                select new ItemsFacturaDTO
                                {
                                    Id = t.Id,
                                    Factura = t.Factura,
                                    Nombre = i.Nombre,
                                    Cantidad = t.Cantidad,
                                    ValorUnidad = i.Valor,
                                    Total = t.Cantidad * i.Valor,
                                }).ToList();

                    return data;
                }
            }
            catch (Exception)
            {
                return respuesta;
                throw;
            }

        }

        public List<Clientes> GetClientId(int id)
        {
            List<Clientes> respuesta = new List<Clientes>();
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Clientes where t.Id == id select t).ToList();
                    return data;
                }
            }
            catch (Exception)
            {
                return respuesta;
                throw;
            }

        }

        public string SetClient(ClientesDTO c)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = new Clientes();
                    if (c.Id == 0)
                    {
                        data = db.Clientes.Add(new Clientes
                        {
                            Identificacion = c.Identificacion,
                            Nombre = c.Nombre,
                            email = c.email,
                        });
                    }
                    else
                    {
                        data = (from ppal in db.Clientes where ppal.Id == c.Id select ppal).FirstOrDefault();
                        data.Identificacion = c.Identificacion;
                        data.Nombre = c.Nombre;
                        data.email = c.email;
                    }
                    
                    db.SaveChanges();
                    return "Registro Guardado";
                }
            }
            catch (Exception)
            {
                return "Error al guardar";
                throw;
            }

        }


        public string DeleteClient(int id)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Clientes where t.Id == id select t).FirstOrDefault();
                    db.Clientes.Remove(data);
                    db.SaveChanges();
                    return "Regitro Eliminado";
                }
            }
            catch (Exception)
            {
                return "Error al eliminar";
                throw;
            }

        }


        public string UpdateClient(Clientes c)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Clientes where t.Id == c.Id select t).FirstOrDefault();
                    data.Identificacion = c.Identificacion;
                    data.Nombre = c.Nombre;
                    data.Direccion = c.Direccion;
                    data.Telefono = c.Telefono;
                    db.SaveChanges();
                    return "Cambios guardados";
                }
            }
            catch (Exception)
            {
                return "Error al guardar";
                throw;
            }

        }

        public string SetItem(ItemsDTO i)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = new Items();
                    if (i.Id == 0)
                    {
                        data = db.Items.Add(new Items
                        {
                            Nombre = i.Nombre,
                            Valor = i.Valor
                        });
                    }
                    else
                    {
                        data = (from ppal in db.Items where ppal.Id == i.Id select ppal).FirstOrDefault();
                        data.Nombre = i.Nombre;
                        data.Valor = i.Valor;
                    }

                    db.SaveChanges();
                    return "Registro Guardado";
                }
            }
            catch (Exception)
            {
                return "Error al guardar";
                throw;
            }

        }


        public string DeleteItem(int id)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    var data = (from t in db.Items where t.Id == id select t).FirstOrDefault();
                    db.Items.Remove(data);
                    db.SaveChanges();
                    return "Regitro Eliminado";
                }
            }
            catch (Exception)
            {
                return "Error al eliminar";
                throw;
            }

        }


        public string SetFactura(Dictionary<string,string> venta, List<Dictionary<string, string>> items)
        {
            try
            {
                using (Database1Entities db = new Database1Entities())
                {
                    //var data = new Items();
                    var data = db.Facturas.Add(new Facturas
                    {
                        Id = 0,
                        Cliente = int.Parse(venta["Cliente"]),
                        Total = int.Parse(venta["Total"]),
                    });
                    db.SaveChanges();

                    var factura = (from ppal in db.Facturas
                                orderby ppal.Id descending select ppal).FirstOrDefault();

                    foreach (var item in items)
                    {
                        var data2 = db.Items_x_Factura.Add(new Items_x_Factura
                        {
                            Id = 0,
                            Factura = factura.Id,
                            Item = int.Parse(item["Item"]),
                            Cantidad = int.Parse(item["Cantidad"]),
                        });
                    }

                    db.SaveChanges();
                    return "Registro Guardado";
                }
            }
            catch (Exception)
            {
                return "Error al guardar";
                throw;
            }

        }
    }
}