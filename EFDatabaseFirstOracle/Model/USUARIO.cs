using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirstOracle.Model;

[Table("USUARIO")]
public partial class USUARIO
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal ID_USUARIO { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NOME { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string SOBRENOME { get; set; } = null!;

    [Column(TypeName = "DATE")]
    public DateTime? DATA_NASCIMENTO { get; set; }
}
