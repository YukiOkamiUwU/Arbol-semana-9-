using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionesABB
{
    class ArbolBB
    {
        int dato = 0;
        public Nodo raíz;
        public ArbolBB()
        {
            raíz = null;
        }
        public void InsertarEdad()
        {
            Nodo nuevo = new Nodo(dato);
            Console.Write("Ingrese edad: ");
            dato = int.Parse(Console.ReadLine());//10-20
            nuevo.dato = dato;
            if (raíz == null) raíz = nuevo;
            else
            {
                Nodo nAnte = null, nReco = raíz;//10
                while (nReco != null)
                {
                    nAnte = nReco;//10
                    if (nuevo.dato < nReco.dato) nReco = nReco.izq;
                    else nReco = nReco.der;
                }
                if (nuevo.dato < nAnte.dato) nAnte.izq = nuevo;
                else nAnte.der = nuevo;
            } 
        }
        private void RecorridoInOrden(Nodo nReco)//I-R-D
        {
            if (nReco!=null)
            {
                RecorridoInOrden(nReco.izq);//I
                Console.Write(nReco.dato+" ");//R
                RecorridoInOrden(nReco.der);//D
            }
        }
        public void RecorridoInOrden()
        {
            RecorridoInOrden(raíz);
            Console.WriteLine();
        }
        public Nodo Buscar(int dato)
        {
            Nodo nReco = raíz;
            while (nReco.dato!=dato)
            {
                if (dato < nReco.dato) nReco = nReco.izq;
                else nReco = nReco.der;
                if (nReco == null) return null;
            }
            return nReco;
        }
        public void BuscarEdad()
        {
            Console.Write("digite edad a buscar: ");
            int edad = int.Parse(Console.ReadLine());//15
            if (Buscar(edad) == null) Console.WriteLine("La edad no existe");
            else Console.WriteLine("La edad existe");
        }
        public Boolean EliminarEdad()
        {
            Console.Write("Digite edad a eliminar: ");
            dato = int.Parse(Console.ReadLine());//15
            Nodo nReco = raíz;
            Nodo nPadre = raíz;
            bool hijoizq = true;
            while (nReco.dato!=dato)
            {
                nPadre = nReco;
                if (dato < nReco.dato) { hijoizq = true;nReco = nReco.izq;}
                else { hijoizq = false;nReco = nReco.der; }
            }
            if(nReco.izq==null && nReco.der == null)
            {
                if (nReco == raíz) raíz = null;
                else if (hijoizq) nPadre.izq = null;
                else nPadre.der = null;
            }
            else if (nReco.der == null)
            {
                if (nReco == raíz) raíz = nReco.izq;
                else if (hijoizq) nPadre.izq = nReco.izq;
                else nPadre.der = nReco.izq;
            }
            else if (nReco.izq == null)
            {
                if (nReco == raíz) raíz = nReco.der;
                else if (hijoizq) nPadre.izq = nReco.der;
                else nPadre.der = nReco.izq;//nReco.der;
            }
            else
            {
                Nodo nReemp = ObtenerReemp(nReco);
                if (nReco == raíz) raíz = nReemp;
                else if (hijoizq) nPadre.izq = nReemp;
                else nPadre.der = nReemp;
            }
            return true;
        }
        public Nodo ObtenerReemp(Nodo NodoReemp)
        {
            Nodo nRpadre = NodoReemp;
            Nodo nReemp = NodoReemp;
            Nodo nReco = NodoReemp.der;
            while (nReco!=null)
            {
                nRpadre = nReemp;
                nReemp = nReco;
                nReco = nReco.izq;
            }
            if (nReemp!=NodoReemp.der)
            {
                nRpadre.izq = nReemp.der;
                nReemp.der = NodoReemp.der;
            }
            Console.WriteLine("\nLa edad que reemplazará al nodo eliminado es: " + nReemp.dato);
            return nReemp;
        }
    }
}
