using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Inventario
    {
        public Producto primero { private set; get; }

        public bool agregar(Producto nuevo)
        {
            if (primero == null)
                primero = nuevo;
            else
                agregar(nuevo, primero);
            return true;
        }

        /*
        public bool agregarAlInicio(Producto producto)
        {
            if (buscarProducto(producto.código) == null)
            {
                producto.siguiente = primero;
                primero = producto;
                return true;
            }
            else
                return false;
        }
        */

        public bool agregarAlFinal(Producto producto)
        {
            if (primero == null)
            {
                primero = producto;
                return true;
            }
            else if (buscarProducto(producto.código) == null)
            {
                Producto aux = primero;
                while (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                aux.siguiente = producto;
                return true;
            }
            else
                return false;
        }

        private void agregar(Producto nuevo, Producto último)
        {
            if (último.siguiente == null)
                último.siguiente = nuevo;
            else
                agregar(nuevo, último.siguiente);
        }

        public Producto buscarProducto(int código)
        {
            Producto aux = primero;
            while (aux != null)
            {
                if (aux.código == código)
                    return aux;
                aux = aux.siguiente;
            }
            return null;
        }

        public bool eliminar(int código)
        {
            if (buscarProducto(código) != null)
            {
                if (primero.código == código)
                {
                    primero = primero.siguiente;
                    return true;
                }
                else
                {
                    Producto aux = primero;
                    while (aux.siguiente != null)
                    {
                        if (aux.siguiente.código == código)
                        {
                            aux.siguiente = aux.siguiente.siguiente;
                            return true;
                        }
                        aux = aux.siguiente;
                    }
                    return false;
                }
            }
            else
                return false;
        }

        public bool insertar(Producto producto, int pos)
        {
            if (buscarProducto(producto.código) == null)
            {
                if (pos == 0)
                {
                    producto.siguiente = primero;
                    primero = producto;
                    return true;
                }
                else
                {
                    Producto aux = primero;
                    while (pos >= 2)
                    {
                        if (aux == null)
                            return false;
                        pos--;
                        aux = aux.siguiente;
                    }
                    producto.siguiente = aux.siguiente;
                    aux.siguiente = producto;
                    return true;
                }
            }
            else
                return false;
        }

        public override string ToString()
        {
            Producto aux = primero;
            string reporte = "";
            while (aux != null)
            {
                reporte += aux.ToString();
                aux = aux.siguiente;
            }
            return reporte;
        }

        public string reporteInverso()
        {
            if (primero == null)
                return "";
            else
                return reporteInverso(primero);
        }

        private string reporteInverso(Producto último)
        {
            if (último.siguiente == null)
                return último.ToString();
            else
                return reporteInverso(último.siguiente) + último.ToString();
        }
    }
}