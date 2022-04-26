
namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Prestamos
    {
        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("nombrePrestamo")]
        public string NombrePrestamo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("tasaInteres")]
        public long TasaInteres { get; set; }

        [JsonProperty("codigoPlazo")]
        public long CodigoPlazo { get; set; }

        [JsonProperty("montoMin")]
        public long MontoMin { get; set; }

        [JsonProperty("montoMax")]
        public long MontoMax { get; set; }

        [JsonProperty("codigoCategoria")]
        public long CodigoCategoria { get; set; }

        [JsonProperty("categoriasPrestamos")]
        public PrestamoCategoriasPrestamos CategoriasPrestamos { get; set; }

        [JsonProperty("plazos")]
        public PrestamoPlazosClass Plazos { get; set; }

        [JsonProperty("solcitudCreditos")]
        public PrestamoSolcitudCreditoClass[] SolcitudCreditos { get; set; }


        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public partial class PrestamoCategoriasPrestamos
    {
        [JsonProperty("codigoCategoria")]
        public long CodigoCategoria { get; set; }

        [JsonProperty("nombreCategoria")]
        public string NombreCategoria { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("prestamos")]
        public CategoriasPrestamosPrestamo[] Prestamos { get; set; }
    }

    public partial class CategoriasPrestamosPrestamo
    {
        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("nombrePrestamo")]
        public string NombrePrestamo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("tasaInteres")]
        public long TasaInteres { get; set; }

        [JsonProperty("codigoPlazo")]
        public long CodigoPlazo { get; set; }

        [JsonProperty("montoMin")]
        public long MontoMin { get; set; }

        [JsonProperty("montoMax")]
        public long MontoMax { get; set; }

        [JsonProperty("codigoCategoria")]
        public long CodigoCategoria { get; set; }

        [JsonProperty("categoriasPrestamos")]
        public CategoriasPrestamos CategoriasPrestamos { get; set; }

        [JsonProperty("indicadores")]
        public PrestamoIndicadore[] Indicadores { get; set; }

        [JsonProperty("plazos")]
        public PrestamoPlazos Plazos { get; set; }

        [JsonProperty("solcitudCreditos")]
        public PrestamoSolcitudCredito[] SolcitudCreditos { get; set; }
    }

    public partial class CategoriasPrestamos
    {
    }

    public partial class PrestamoIndicadore
    {
        [JsonProperty("codigoIndicador")]
        public long CodigoIndicador { get; set; }

        [JsonProperty("fecha")]
        public DateTimeOffset Fecha { get; set; }

        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("codigotipoIndicador")]
        public long CodigotipoIndicador { get; set; }

        [JsonProperty("cantidad")]
        public long Cantidad { get; set; }

        [JsonProperty("prestamos")]
        public CategoriasPrestamos Prestamos { get; set; }

        [JsonProperty("tiposIndicadores")]
        public TiposIndicadores TiposIndicadores { get; set; }
    }

    public partial class TiposIndicadores
    {
        [JsonProperty("codigotipoIndicador")]
        public long CodigotipoIndicador { get; set; }

        [JsonProperty("nombreIndicador")]
        public string NombreIndicador { get; set; }

        [JsonProperty("indicadores")]
        public CategoriasPrestamos[] Indicadores { get; set; }
    }

    public partial class PrestamoPlazos
    {
        [JsonProperty("codigoPlazo")]
        public long CodigoPlazo { get; set; }

        [JsonProperty("plazoMin")]
        public long PlazoMin { get; set; }

        [JsonProperty("plazoMax")]
        public long PlazoMax { get; set; }

        [JsonProperty("prestamos")]
        public CategoriasPrestamos[] Prestamos { get; set; }
    }

    public partial class PrestamoSolcitudCredito
    {
        [JsonProperty("numSolicitud")]
        public long NumSolicitud { get; set; }

        [JsonProperty("tipoIdentificacion")]
        public long TipoIdentificacion { get; set; }

        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty("correoElectronico")]
        public string CorreoElectronico { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("moneda")]
        public long Moneda { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("montoSolicitado")]
        public long MontoSolicitado { get; set; }

        [JsonProperty("plazo")]
        public long Plazo { get; set; }

        [JsonProperty("salarioLiquido")]
        public long SalarioLiquido { get; set; }

        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("tasainteresactual")]
        public long Tasainteresactual { get; set; }

        [JsonProperty("porcentajeEndeudamiento")]
        public long PorcentajeEndeudamiento { get; set; }

        [JsonProperty("estadoSolicitud")]
        public string EstadoSolicitud { get; set; }

        [JsonProperty("moneda1")]
        public Moneda1 Moneda1 { get; set; }

        [JsonProperty("prestamos")]
        public CategoriasPrestamos Prestamos { get; set; }

        [JsonProperty("fechaSolicitud")]
        public DateTimeOffset FechaSolicitud { get; set; }

        [JsonProperty("tiposIdentificacion")]
        public TiposIdentificacion TiposIdentificacion { get; set; }

        [JsonProperty("solicitudesAnalistas")]
        public SolicitudesAnalista[] SolicitudesAnalistas { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public partial class Moneda1
    {
        [JsonProperty("codigoMoneda")]
        public long CodigoMoneda { get; set; }

        [JsonProperty("nombreMoneda")]
        public string NombreMoneda { get; set; }

        [JsonProperty("solcitudCreditos")]
        public CategoriasPrestamos[] SolcitudCreditos { get; set; }
    }

    public partial class SolicitudesAnalista
    {
        [JsonProperty("codigo")]
        public long Codigo { get; set; }

        [JsonProperty("numSolicitud")]
        public long NumSolicitud { get; set; }

        [JsonProperty("analistaEncargado")]
        public string AnalistaEncargado { get; set; }

        [JsonProperty("solcitudCreditos")]
        public CategoriasPrestamos SolcitudCreditos { get; set; }

        [JsonProperty("usuarios")]
        public Usuarios Usuarios { get; set; }
    }

    public partial class Usuarios
    {
        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty("nacionalidad")]
        public string Nacionalidad { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("correoElectronico")]
        public string CorreoElectronico { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("pass")]
        public string Pass { get; set; }

        [JsonProperty("tipoRol")]
        public long TipoRol { get; set; }


        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public partial class Roles
    {
        [JsonProperty("id_tipoRol")]
        public long IdTipoRol { get; set; }

        [JsonProperty("nombreRol")]
        public string NombreRol { get; set; }

        [JsonProperty("usuarios")]
        public CategoriasPrestamos[] Usuarios { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

    }
    public partial class SolicitudesTramitar
    {

        [JsonProperty("solicitud")]
        public int NumSolicitud { get; set; }


        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

    }

    public partial class TiposIdentificacion
    {
        [JsonProperty("codigoTipo")]
        public long CodigoTipo { get; set; }

        [JsonProperty("nombreTipo")]
        public string NombreTipo { get; set; }

        [JsonProperty("solcitudCreditos")]
        public CategoriasPrestamos[] SolcitudCreditos { get; set; }
    }

    public partial class Indicadores
    {
        [JsonProperty("codigoIndicador")]
        public int CodigoIndicador { get; set; }

        [JsonProperty("fecha")]
        public DateTimeOffset Fecha { get; set; }

        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("codigotipoIndicador")]
        public int CodigotipoIndicador { get; set; }

        [JsonProperty("cantidad")]
        public long Cantidad { get; set; }
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public partial class IndicadorePrestamos
    {
        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("nombrePrestamo")]
        public string NombrePrestamo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("tasaInteres")]
        public long TasaInteres { get; set; }

        [JsonProperty("codigoPlazo")]
        public long CodigoPlazo { get; set; }

        [JsonProperty("montoMin")]
        public long MontoMin { get; set; }

        [JsonProperty("montoMax")]
        public long MontoMax { get; set; }

        [JsonProperty("codigoCategoria")]
        public long CodigoCategoria { get; set; }

        [JsonProperty("categoriasPrestamos")]
        public PurpleCategoriasPrestamos CategoriasPrestamos { get; set; }

        [JsonProperty("indicadores")]
        public CategoriasPrestamos[] Indicadores { get; set; }

        [JsonProperty("plazos")]
        public PrestamoPlazos Plazos { get; set; }

        [JsonProperty("solcitudCreditos")]
        public PrestamoSolcitudCredito[] SolcitudCreditos { get; set; }
    }

    public partial class PurpleCategoriasPrestamos
    {
        [JsonProperty("codigoCategoria")]
        public long CodigoCategoria { get; set; }

        [JsonProperty("nombreCategoria")]
        public string NombreCategoria { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("prestamos")]
        public CategoriasPrestamos[] Prestamos { get; set; }
    }

    public partial class PrestamoPlazosClass
    {
        [JsonProperty("codigoPlazo")]
        public long CodigoPlazo { get; set; }

        [JsonProperty("plazoMin")]
        public long PlazoMin { get; set; }

        [JsonProperty("plazoMax")]
        public long PlazoMax { get; set; }

        [JsonProperty("prestamos")]
        public PlazosPrestamo[] Prestamos { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public partial class PlazosPrestamo
    {
        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("nombrePrestamo")]
        public string NombrePrestamo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("tasaInteres")]
        public long TasaInteres { get; set; }

        [JsonProperty("codigoPlazo")]
        public long CodigoPlazo { get; set; }

        [JsonProperty("montoMin")]
        public long MontoMin { get; set; }

        [JsonProperty("montoMax")]
        public long MontoMax { get; set; }

        [JsonProperty("codigoCategoria")]
        public long CodigoCategoria { get; set; }

        [JsonProperty("categoriasPrestamos")]
        public PurpleCategoriasPrestamos CategoriasPrestamos { get; set; }

        [JsonProperty("indicadores")]
        public PrestamoIndicadore[] Indicadores { get; set; }

        [JsonProperty("plazos")]
        public CategoriasPrestamos Plazos { get; set; }

        [JsonProperty("solcitudCreditos")]
        public PrestamoSolcitudCredito[] SolcitudCreditos { get; set; }
    }

    public partial class PrestamoSolcitudCreditoClass
    {
        [JsonProperty("numSolicitud")]
        public long NumSolicitud { get; set; }

        [JsonProperty("tipoIdentificacion")]
        public long TipoIdentificacion { get; set; }

        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty("correoElectronico")]
        public string CorreoElectronico { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("moneda")]
        public long Moneda { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("montoSolicitado")]
        public long MontoSolicitado { get; set; }

        [JsonProperty("plazo")]
        public long Plazo { get; set; }

        [JsonProperty("salarioLiquido")]
        public long SalarioLiquido { get; set; }

        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("tasainteresactual")]
        public long Tasainteresactual { get; set; }

        [JsonProperty("porcentajeEndeudamiento")]
        public long PorcentajeEndeudamiento { get; set; }

        [JsonProperty("estadoSolicitud")]
        public string EstadoSolicitud { get; set; }

        [JsonProperty("moneda1")]
        public Moneda1 Moneda1 { get; set; }

        [JsonProperty("fechaSolicitud")]
        public DateTime FechaSolicitud { get; set; }

        [JsonProperty("prestamos")]
        public SolcitudCreditoPrestamos Prestamos { get; set; }

        [JsonProperty("tiposIdentificacion")]
        public TiposIdentificacion TiposIdentificacion { get; set; }

        [JsonProperty("solicitudesAnalistas")]
        public SolicitudesAnalista[] SolicitudesAnalistas { get; set; }
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public partial class SolcitudCreditoPrestamos
    {
        [JsonProperty("codigoPrestamo")]
        public long CodigoPrestamo { get; set; }

        [JsonProperty("nombrePrestamo")]
        public string NombrePrestamo { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("tasaInteres")]
        public long TasaInteres { get; set; }

        [JsonProperty("codigoPlazo")]
        public long CodigoPlazo { get; set; }

        [JsonProperty("montoMin")]
        public long MontoMin { get; set; }

        [JsonProperty("montoMax")]
        public long MontoMax { get; set; }

        [JsonProperty("codigoCategoria")]
        public long CodigoCategoria { get; set; }

        [JsonProperty("categoriasPrestamos")]
        public PurpleCategoriasPrestamos CategoriasPrestamos { get; set; }

        [JsonProperty("indicadores")]
        public PrestamoIndicadore[] Indicadores { get; set; }

        [JsonProperty("plazos")]
        public PrestamoPlazos Plazos { get; set; }

        [JsonProperty("solcitudCreditos")]
        public CategoriasPrestamos[] SolcitudCreditos { get; set; }
    }
    public partial class InfoVistas
    {
        [JsonProperty("nombrePrestamo")]
        public string nombrePrestamo { get; set; }

        [JsonProperty("numeroSsolicitudes")]
        public long numeroSsolicitudes { get; set; }

        [JsonProperty("solicitudesPendientes")]
        public long solicitudesPendientes { get; set; }

        [JsonProperty("solicitudesAprobadas")]
        public long solicitudesAprobadas { get; set; }

        [JsonProperty("solicitudesDenegadas")]
        public long solicitudesDenegadas { get; set; }

    }

    public partial class VistaCompleta
    {
        [JsonProperty("nombrePrestamo")]
        public string nombrePrestamo { get; set; }

        [JsonProperty("numeroSsolicitudes")]
        public long numeroSsolicitudes { get; set; }

        [JsonProperty("solicitudesPendientes")]
        public long solicitudesPendientes { get; set; }

        [JsonProperty("solicitudesAprobadas")]
        public long solicitudesAprobadas { get; set; }

        [JsonProperty("solicitudesDenegadas")]
        public long solicitudesDenegadas { get; set; }

        [JsonProperty("soliciudestramitando")]
        public long solicitudestramitando { get; set; }


    }

    public partial class VistaTotales
    {
        [JsonProperty("nombrePrestamo")]
        public string nombrePrestamo { get; set; }

        [JsonProperty("numeroSsolicitudes")]
        public long numeroSsolicitudes { get; set; }

        [JsonProperty("fecha")]
        public DateTime fecha { get; set; }
    }
    public partial class VistaPendientes
    {
        [JsonProperty("nombrePrestamo")]
        public string nombrePrestamo { get; set; }

        [JsonProperty("pendientes")]
        public long solicitudespendientes { get; set; }

        [JsonProperty("solicitudesDenegadas")]
        public DateTime fecha { get; set; }
    }

    public partial class VistaDenegadas
    {
        [JsonProperty("nombrePrestamo")]
        public string nombrePrestamo { get; set; }

        [JsonProperty("pendientes")]
        public long solicitudesdenegadas { get; set; }

        [JsonProperty("solicitudesDenegadas")]
        public DateTime fecha { get; set; }
    }
    public partial class VistaTramitando
    {
        [JsonProperty("nombrePrestamo")]
        public string nombrePrestamo { get; set; }

        [JsonProperty("pendientes")]
        public long solicitudesTramitando { get; set; }

        [JsonProperty("solicitudesDenegadas")]
        public DateTime fecha { get; set; }
    }

    public partial class VistaAprobadas
    {
        [JsonProperty("nombrePrestamo")]
        public string nombrePrestamo { get; set; }

        [JsonProperty("pendientes")]
        public long solicitudesAprobadas { get; set; }

        [JsonProperty("solicitudesDenegadas")]
        public DateTime fecha { get; set; }
    }

    public partial class ModificarUsuarioRol
    {

        [JsonProperty("identificacion")]
        public string identificacion { get; set; }

        [JsonProperty("tipoRol")]
        public int tipoRol { get; set; }
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

    }
    public partial class SolicitudesXTramitadores
    {

        [JsonProperty("identificacion")]
        public string identificacionTramitador { get; set; }

        [JsonProperty("tipoRol")]
        public int NumeroSolicitud { get; set; }


    }
    public partial class ModificarUsuarios
    {
        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }

        [JsonProperty("nombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty("nacionalidad")]
        public string Nacionalidad { get; set; }

        [JsonProperty("telefono")]
        public string Telefono { get; set; }

        [JsonProperty("correoElectronico")]
        public string CorreoElectronico { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("pass")]
        public string Pass { get; set; }

        [JsonProperty("tipoRol")]
        public int TipoRol { get; set; }




        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }

    public partial class ModificarUsuarioRol
    {
        public static List<ModificarUsuarioRol> FromJson(string json) => JsonConvert.DeserializeObject<List<ModificarUsuarioRol>>(json);
    }

    public partial class Vistas
    {
        public static List<InfoVistas> FromJson(string json) => JsonConvert.DeserializeObject<List<InfoVistas>>(json);
    }

    public partial class Prestamos
    {
        public static List<Prestamos> FromJson(string json) => JsonConvert.DeserializeObject<List<Prestamos>>(json);
    }
    public partial class Indicadores
    {
        public static List<Indicadores> FromJson(string json) => JsonConvert.DeserializeObject<List<Indicadores>>(json);
    }

    public partial class Roles
    {
        public static List<Roles> FromJson(string json) => JsonConvert.DeserializeObject<List<Roles>>(json);
    }

    public partial class Usuarios
    {
        public static List<Usuarios> FromJson(string json) => JsonConvert.DeserializeObject<List<Usuarios>>(json);
    }

    public partial class SolicitudesTramitar
    {
        public static List<SolicitudesTramitar> FromJson(string json) => JsonConvert.DeserializeObject<List<SolicitudesTramitar>>(json);
    }
    public static class Serialize
    {

        public static string ToJson(this Prestamos[] self) => JsonConvert.SerializeObject(self, CapaDatos.Converter.Settings);
    }
    public partial class SolicitudesCredito
    {
        public static List<PrestamoSolcitudCredito> FromJson(string json) => JsonConvert.DeserializeObject<List<PrestamoSolcitudCredito>>(json);
    }
    public partial class ModificarUsuarios
    {
        public static List<ModificarUsuarios> FromJson(string json) => JsonConvert.DeserializeObject<List<ModificarUsuarios>>(json);
    }

    public partial class SolicitudesAnalista
    {
        public static List<SolicitudesAnalista> FromJson(string json) => JsonConvert.DeserializeObject<List<SolicitudesAnalista>>(json);
    }


public partial class PrestamoPlazosClass
    {
        public static List<PrestamoPlazosClass> FromJson(string json) => JsonConvert.DeserializeObject<List<PrestamoPlazosClass>>(json);
    }
    public partial class PurpleCategoriasPrestamos
    {
        public static List<PurpleCategoriasPrestamos> FromJson(string json) => JsonConvert.DeserializeObject<List<PurpleCategoriasPrestamos>>(json);
    }




    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
