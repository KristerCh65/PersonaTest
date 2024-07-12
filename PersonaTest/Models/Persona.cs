using System;
using System.Collections.Generic;

namespace PersonaTest.Models;

public partial class Persona
{
    public string Identidad { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }
}
