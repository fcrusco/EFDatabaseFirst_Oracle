using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirstOracle.Model;

[Table("TB_CLIENTE")]
public partial class TB_CLIENTE
{
    [Key]
    [Column(TypeName = "NUMBER")]
    public decimal ID_CLIENTE { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NOME { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string SOBRENOME { get; set; } = null!;
}
