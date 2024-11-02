﻿using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Subasta : Publicacion,IValidable
    {
        private List<Oferta> _ofertas = new List<Oferta>();
        public Subasta(string nombre,
                       Estado estado,
                       Administrador usuario,
                       List<Articulo> articulos,
                       DateTime fechaPublicacion
                     ) : base(nombre, estado, usuario, articulos,fechaPublicacion)
        {
        }

        public List<Oferta> MostrarOfertas()
        {
            return _ofertas;
        }
        public override decimal ObtenerPrecio()
        {
            if (_ofertas.Count > 0)
            {
                return _ofertas[_ofertas.Count - 1].Precio;
            }
            return base.ObtenerPrecio();
        }
        public void CargarOferta(Oferta oferta)
        {
            if (oferta == null) throw new Exception("Parametro incorrecto para crear una oferta");
            oferta.Validar();
            _ofertas.Add(oferta);
        }
        public override void Validar()
        {
            base.Validar();
        }
    }
}